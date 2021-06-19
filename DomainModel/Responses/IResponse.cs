
using DomainModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Responses
{
    public interface IResponse<T> : IResponse
    {
        T payload { get; }
    }
    public interface IResponse
    {
        bool IsValid { get; }
        ValidationResult ValidationResult { get; set; }
        Dictionary<string, object> Info { get; }
        
    }
}
