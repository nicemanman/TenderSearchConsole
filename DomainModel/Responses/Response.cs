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
        public Response(ValidationResult result)
        {
            ValidationResult = result;
        }
        public Response()
        {
            
        }
        public bool IsValid => ValidationResult == null ? true : ValidationResult.Messages.Count() == 0;
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        public Dictionary<string, object> Info { get; set; }
    }
}
