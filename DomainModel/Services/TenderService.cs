
using Core;
using DomainModel.Models;
using DomainModel.Requests;
using DomainModel.Requests.TenderServiceRequests;
using DomainModel.Responses;
using DomainModel.RestClients;
using DomainModel.RestClients.Queries;
using DomainModel.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Services
{
    public class TenderService : ITenderService
    {
        public async Task<IResponse> GetAsync(IGetRequest request)
        {
            if (!(request is ITenderGetRequest tenderGetRequest)) 
                return new Response(new ValidationResult("Для данного вида запроса передан неправильный запрос"));
            var restClient = LightInjectContainer.Current.Resolve<INetClient>(request.ServiceName);
            if (!(restClient is ITenderNetClient tenderNetClient)) 
                return new Response(new ValidationResult("Для данного сервиса неправильно установлен rest client"));
            var tenderResponse = await tenderNetClient.GetTenders(tenderGetRequest);
            return new Response<TenderGetResponseModel>(tenderResponse);
        }

        public async Task<ITenderGetResponse> GetTenderDocumentationAsync(ITenderGetRequest request)
        {
            var restClient = LightInjectContainer.Current.Resolve<INetClient>(request.ServiceName);
            if (!(restClient is ITenderNetClient tenderNetClient))
                return new TenderGetResponse()
                {
                    ValidationResult = new ValidationResult("Для данного сервиса неправильно установлен rest client")
                };
            var documentation = await tenderNetClient.GetTenderDocumentation(request);
            return new TenderGetResponse()
            {
                TenderDocumentation = documentation
            };
        }

        public async Task<ITenderGetResponse> GetTendersAsync(ITenderGetRequest request)
        {
            var restClient = LightInjectContainer.Current.Resolve<INetClient>(request.ServiceName);
            if (!(restClient is ITenderNetClient tenderNetClient))
                return new TenderGetResponse()
                {
                    ValidationResult = new ValidationResult("Для данного сервиса неправильно установлен rest client")
                };
            var tenderResponse = await tenderNetClient.GetTenders(request);
            return new TenderGetResponse()
            {
                Tenders = tenderResponse.invData
            };
        }
    }
}
