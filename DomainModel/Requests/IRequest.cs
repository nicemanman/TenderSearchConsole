using DomainModel.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Requests
{

    public interface IRequest
    {
        string ServiceID { get; }
        Dictionary<string, object> Info { get; set; }
    }
}
