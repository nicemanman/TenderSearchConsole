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
    /// <summary>
    /// Данный сервис не взаимодействует с непосредственно сервисами исполнения запросов напрямую,
    /// об этих сервисах знает только контейнер. В запросе передается идентификатор сервиса, который
    /// должен выполнить запрос, в данном сервисе исходя из этого идентификатора из контейнера резолвится
    /// нужный нам сервис, и когда запрос попадает в целевой сервис, происходит еще одна проверка, например,
    /// для сервиса ITenderService допустимы запросы ITenderGetRequest
    /// </summary>
    public class Service : IService
    {
        public async Task<IResponse> GetAsync(IGetRequest request)
        {
            var response = await ValidateRequest(request);
            if (response.IsValid && response is IResponse<IService> responseWithPayload)
            {
                var service = responseWithPayload.payload;
                return await service.GetAsync(request);
            }
            else return response;
        }
       
        private async Task<IResponse> ValidateRequest(IRequest request) 
        {
            var service = await TryResolveRequestService(request);
            if (service == null) return new Response(new ValidationResult($"Сервис с идентификатором {request.ServiceName} не найден"));
            else return new Response<IService>(service);
        }
        
        private Task<IService> TryResolveRequestService(IRequest request) 
        {
            if (LightInjectContainer.Current.IsRegistered<IService>(request.ServiceName))
            {
                var service = LightInjectContainer.Current.Resolve<IService>(request.ServiceName);
                return Task.FromResult(service);
            }
            else
                return Task.FromResult<IService>(null);
        }

        
    }
}
