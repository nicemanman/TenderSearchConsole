using DomainModel.Models;
using DomainModel.Requests;
using DomainModel.Requests.TenderServiceRequests;
using DomainModel.Responses;
using DomainModel.RestClients.Queries;
using DomainModel.Services.IServices;
using Presentation.Common;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Presenters
{
    public class TenderSearchPresenter : BasePresenter<ITenderSearchView>
    {
        private readonly ITenderService service;
        private List<InvData> CurrentTendersPage = new List<InvData>();
        public TenderSearchPresenter(IApplicationController controller, ITenderSearchView view, ITenderService service) : base(controller, view)
        {
            View.UpdateTendersList += View_UpdateTendersList;
            View.UpdateTenderDocumentationList += View_UpdateTenderDocumentationList;
            View.UpdateTenderNotice += View_UpdateTenderNotice;
            this.service = service;
            if (!CheckInternetConnection()) 
            {
                View.SetOffInternetConnectionState();
            }
        }

        private void View_UpdateTenderNotice(string tenderNumber)
        {
            View.UpdateTenderNoticeGrid(CurrentTendersPage.Where(x => x.Id.ToString().Equals(tenderNumber)).FirstOrDefault()?.notice);
        }

        private void View_UpdateTenderDocumentationList(string tenderNumber)
        {
            View.UpdateDocumentationsList(CurrentTendersPage.Where(x => x.Id.ToString().Equals(tenderNumber)).FirstOrDefault()?.documentation);
        }
        private bool CheckInternetConnection() 
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
        private async Task View_UpdateTendersList(string tenderNumber, int pageNumber)
        {
            if (!CheckInternetConnection())
            {
                View.SetOffInternetConnectionState();
                return;
            }
            else
            {
                View.SetOnInternetConnectionState();
            }
            using (new LongOperation(View, "Загрузка последних тендеров...")) 
            {
                var tenders = await service.GetTendersAsync(new TenderGetRequest(tenderNumber)
                {
                    Page = pageNumber,
                    WithDocumentation = true,
                    WithTenderNotice = true
                });
                CurrentTendersPage.Clear();
                CurrentTendersPage.AddRange(tenders.Tenders);
                View.UpdateTendersGrid(tenders);
            }
        }
    }
}
