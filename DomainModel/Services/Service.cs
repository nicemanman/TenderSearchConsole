using DomainModel.Requests;
using DomainModel.Responses;
using DomainModel.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
namespace DomainModel.Services
{
    public class Service : IService
    {
        
        public async Task<IResponse> GetAsync(IGetRequest request)
        {
            var response = await ValidateRequest(request);
            if (response.IsValid)
            {
                var service = ((IResponse<IService>)response).payload;
                return await service.GetAsync(request);
            }
            else return response;
        }

        public async Task<IResponse> RequestAsync(IRequest request)
        {
            var response = await ValidateRequest(request);
            if (response.IsValid)
            {
                var service = ((IResponse<IService>)response).payload;
                return await service.RequestAsync(request);
            }
            else
                return response;
        }
        private async Task<IResponse> ValidateRequest(IRequest request) 
        {
            var service = await TryResolveRequestService(request);
            if (service == null) return new Response(new ValidationResult($"Сервис с идентификатором {request.ServiceID} не найден"), Common.ResponseTypes.NOT_FOUND);
            else return new Response<IService>(service);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private Task<IService> TryResolveRequestService(IRequest request) 
        {
            if (LightInjectContainer.Current.IsRegistered<IService>(request.ServiceID))
            {
                var service = LightInjectContainer.Current.Resolve<IService>(request.ServiceID);
                return Task.FromResult(service);
            }
            else
                return Task.FromResult<IService>(null);
        }
    }
}
