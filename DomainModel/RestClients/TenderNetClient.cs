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
            var tenders = await QueryTender(new TenderGetRequestModel() 
            {
                Id = request.TenderNumber
            });
            if (request.WithDocumentation) 
            {
                foreach (var tender in tenders.invData)
                {
                    var documentation =await QueryDocumentation(tender.Id.ToString());
                    tender.documentation = documentation;
                }
            }
            return tenders;
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
