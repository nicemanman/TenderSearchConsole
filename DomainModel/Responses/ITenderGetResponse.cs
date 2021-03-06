using DomainModel.Models;
using DomainModel.RestClients.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Responses
{
    public interface ITenderGetResponse : IResponse
    {
        List<documentation> TenderDocumentation { get; set; }
        List<InvData> Tenders { get; set; }
        TenderNotice Notice { get; set; }
        int PagesCount { get; set; }
        int CurrentPage { get; set; }
    }
}
