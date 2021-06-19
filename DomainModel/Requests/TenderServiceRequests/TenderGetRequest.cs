using DomainModel.RestClients.Queries;
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
        public TenderGetRequest(string tenderNumber)
        {
            this.TenderNumber = tenderNumber;
        }
        public Dictionary<string, object> Info { get; set; }
        public string ServiceName { get; } = ServiceNames.TenderService;
        public string TenderNumber { get; set; }

        /// <summary>
        /// Если флаг true, то при загрузке тендеров они будут загружены вместе с информацией о документации
        /// </summary>
        public bool WithDocumentation { get; set; } = false;
    }
}
