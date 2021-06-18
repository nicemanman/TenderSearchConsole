using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Requests.TenderServiceRequests
{
    public interface ITenderGetRequest : IGetRequest
    {
        int TenderID { get; set; }
        int TenderDate { get; set; }
    }
}
