using DomainModel.Requests;
using DomainModel.Requests.TenderServiceRequests;
using DomainModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Services.IServices
{
    public interface ITenderService
    {
        Task<ITenderGetResponse> GetTendersAsync(ITenderGetRequest request);
        Task<ITenderGetResponse> GetTenderDocumentationAsync(ITenderGetRequest request);
    }
}
