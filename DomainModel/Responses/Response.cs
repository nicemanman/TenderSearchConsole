using DomainModel.Common;
using DomainModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Responses
{
    public class Response<T> : Response, IResponse<T> 
    {
        public T payload { get; }
        public Response(T payload)
        {
            this.payload = payload;
        }
    }
    public class Response : IResponse
    {
        
        public Response(ValidationResult result, ResponseTypes type)
        {
            ValidationResult = result;
            this.Type = type;
        }
        public Response()
        {
            Type = ResponseTypes.OK;
        }
        public bool IsValid => ValidationResult == null ? true : ValidationResult.Messages.Count() == 0;
        public ValidationResult ValidationResult { get; } = new ValidationResult();

        public string Message { get; }

        public Dictionary<string, object> Info { get; set; }
        public ResponseTypes Type { get; set; } = ResponseTypes.OK;
    }
}
