using DomainModel.Requests;
using DomainModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Services.IServices
{
    
    public interface IService
    {
        Task<IResponse> GetAsync(IGetRequest request);
    }
}
