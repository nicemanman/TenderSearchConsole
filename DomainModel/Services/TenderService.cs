using DomainModel.Requests;
using DomainModel.Responses;
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
        public Task<IResponse> GetAsync(IGetRequest request)
        {
            return Task.FromResult<IResponse>(new Response());
        }

        public Task<IResponse> RequestAsync(IRequest request)
        {
            return Task.FromResult<IResponse>(new Response());
        }
    }
}
