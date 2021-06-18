using DomainModel.Services;
using DomainModel.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Requests.TenderServiceRequests
{
    public class TenderGetRequest : ITenderGetRequest
    {
        public Dictionary<string, object> Info { get; set; }
        public int TenderID { get; set; }
        public int TenderDate { get; set; }
        public string ServiceID { get; } = ServiceIdentificators.TenderService + "123";
    }
}
