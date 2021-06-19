using DomainModel.RestClients.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Responses
{
    public class TenderGetResponse : Response, ITenderGetResponse
    {
        public List<documentation> TenderDocumentation { get; set; }
        public List<InvData> Tenders { get; set; }
    }
}
