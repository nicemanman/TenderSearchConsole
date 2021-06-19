using DomainModel.RestClients.Queries;
using Presentation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views
{
    public interface ITenderSearchView : IView
    {
        event Func<string, int, Task> UpdateTendersList;
        event Action<string> UpdateTenderDocumentationList;
        void UpdateTendersGrid(List<InvData> tenders, int pagesCount);
        void UpdateDocumentationsList(List<documentation> list);
        void SetOffInternetConnectionState();
        void SetOnInternetConnectionState();
    }
}
