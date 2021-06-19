using DomainModel.Requests.TenderServiceRequests;
using DomainModel.RestClients.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RestClients
{
    public interface ITenderNetClient
    {
        Task<TenderGetResponseModel> GetTenders(ITenderGetRequest request);
        Task<List<documentation>> GetTenderDocumentation(ITenderGetRequest request);
    }
}
