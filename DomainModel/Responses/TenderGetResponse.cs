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
        public TenderGetResponse(ValidationResult validationResult) : base(validationResult)
        {

        }
        public TenderGetResponse()
        {

        }
        public int PagesCount { get; set; }
        public List<documentation> TenderDocumentation { get; set; }
        public List<InvData> Tenders { get; set; }
    }
}
