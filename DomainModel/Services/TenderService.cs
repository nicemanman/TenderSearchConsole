
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
        private readonly ITenderNetClient client;

        public TenderService(ITenderNetClient client)
        {
            this.client = client;
        }
        public async Task<ITenderGetResponse> GetTenderDocumentationAsync(ITenderGetRequest request)
        {
            var documentation = await client.GetTenderDocumentation(request);
            return new TenderGetResponse()
            {
                TenderDocumentation = documentation
            };
        }

        public async Task<ITenderGetResponse> GetTendersAsync(ITenderGetRequest request)
        {
            var tenderResponse = await client.GetTenders(request);
            return new TenderGetResponse()
            {
                Tenders = tenderResponse.invData,
                PagesCount = tenderResponse.totalpages
            };
        }
    }
}
