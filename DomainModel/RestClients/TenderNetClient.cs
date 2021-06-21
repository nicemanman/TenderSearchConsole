using DomainModel.Models;
using DomainModel.Parsers;
using DomainModel.Requests.TenderServiceRequests;
using DomainModel.RestClients.Queries;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RestClients
{
    /// <summary>
    /// Работает непосредственно с веб ресурсом тендеров
    /// </summary>
    public class TenderNetClient : NetClient, ITenderNetClient
    {
        
        public const string TENDER_RESOURCE = "https://api.market.mosreg.ru/api/Trade/";
        public const string TENDER_GET_POSTFIX = "GetTradesForParticipantOrAnonymous";
        public const string TENDER_DOCUMENTATION_RESOURCE_POSTFIX = "{0}/GetTradeDocuments";
        public TenderNetClient()
        {
            client = new RestClient(TENDER_RESOURCE);
        }
        public TenderNetClient(string token, string url) : base(token, url) 
        { }
        public async Task<TenderGetResponseModel> GetTenders(ITenderGetRequest request)
        {
            //1. Загрузка тендеров
            TenderGetResponseModel response;
            if (string.IsNullOrWhiteSpace(request.TenderNumber))
            {
                response = await QueryTender(new TenderGetRequestModel() 
                {
                    page = request.Page
                });
            }
            else 
            {
                response = await QueryTender(new TenderGetRequestModel()
                {
                    Id = request.TenderNumber,
                    page = request.Page,
                    itemsPerPage = 10
                });
            }

            //2. Парсим страницы извещения
            //TODO: Api для парсинга страницы. Не хватило на него времени.
            if (request.WithTenderNotice)
            foreach (var tender in response.invData)
            {
                try
                {
                    var parser = new AngleSharpHtmlParser();
                    var document = await parser.GetDocumentAsync(string.Format("https://market.mosreg.ru/Trade/ViewTrade/{0}", tender.Id));
                    var informationAboutCustomerTable = await parser.SelectFromDocument(document, "div > .informationAboutCustomer__informationPurchase");
                    if (informationAboutCustomerTable == null) continue;

                    var deliveryAddressText = informationAboutCustomerTable
                        .Children.Where(x => x.ClassName == "informationAboutCustomer__informationPurchase-infoBlock infoBlock").ElementAt(5)
                        .Children.Where(x => x.ClassName == "infoBlock__text").FirstOrDefault().TextContent.Replace("\n", "").Replace("\r", "");
                    tender.notice.DeliveryAddress = deliveryAddressText;
                    var lotsTable = await parser.SelectFromDocument(document, "div > .objectPurchase");
                    if (lotsTable == null) continue;
                    var lots = lotsTable.Children.ElementAt(1).Children;

                    foreach (var lot in lots)
                    {
                        var name = lot.Children.Where(x => x.ClassName == "outputResults__oneResult-leftPart leftPart").ElementAt(0).ChildNodes.ElementAt(1).ChildNodes.ElementAt(2).TextContent.Replace("\n", "").Replace("\r", "") ;
                        var centerPart = lot.Children.Where(x => x.ClassName == "outputResults__oneResult-centerPart centerPart");
                        var unit = centerPart.ElementAt(0).ChildNodes.ElementAt(1).ChildNodes.ElementAt(1).ChildNodes.ElementAt(2).TextContent.Replace("\n", "").Replace("\r", "");
                        var count = centerPart.ElementAt(0).ChildNodes.ElementAt(1).ChildNodes.ElementAt(3).ChildNodes.ElementAt(2).TextContent.Replace("\n", "").Replace("\r", "");
                        var rightPart = lot.Children.Where(x => x.ClassName == "outputResults__oneResult-rightPart rightPart");
                        var price = rightPart.ElementAt(0).ChildNodes.ElementAt(1).ChildNodes.ElementAt(1).ChildNodes.ElementAt(2).TextContent.Replace("\n", "").Replace("\r", "");

                        var newLot = new TenderPosition();
                        newLot.Name = name;
                        newLot.Unit = unit;
                        newLot.Count = count;
                        newLot.Price = price;

                        tender.notice.Positions.Add(newLot);
                    }
                }
                catch (Exception ex) 
                {
                    //TODO: Здесь по правильному надо это логгировать
                    continue;
                }
            }

            //3. Загрузка документации
            if (request.WithDocumentation) 
            {
                foreach (var tender in response.invData)
                {
                    var documentation =await QueryDocumentation(tender.Id.ToString());
                    tender.documentation = documentation;
                }
            }

            return response;
        }
        public async Task<List<documentation>> GetTenderDocumentation(ITenderGetRequest request)
        {
            return await QueryDocumentation(request.TenderNumber);
        }
        private async Task<TenderGetResponseModel> QueryTender(TenderGetRequestModel query)
        {
            var request = new RestRequest(TENDER_GET_POSTFIX, Method.POST);
            return await Execute<TenderGetResponseModel>(request, query);
        }
        private async Task<List<documentation>> QueryDocumentation(string tenderNumber)
        {
            var url = string.Format(TENDER_DOCUMENTATION_RESOURCE_POSTFIX, tenderNumber);
            var request = new RestRequest(url, Method.GET);
            return await Execute<List<documentation>>(request);
        }
    }
}
