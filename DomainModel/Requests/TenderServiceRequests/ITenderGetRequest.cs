using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Requests.TenderServiceRequests
{
    public interface ITenderGetRequest : IGetRequest
    {
        string TenderNumber { get; set; }
        int Page { get; set; }
        bool WithDocumentation { get; set; }
        bool WithTenderNotice { get; set; }
    }
}
