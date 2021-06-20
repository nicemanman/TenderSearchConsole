using DomainModel.Models;
using DomainModel.Responses;
using DomainModel.RestClients.Queries;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UILauncher
{
    public partial class MainView : Form, ITenderSearchView
    {
        private readonly ApplicationContext context;
        private int CurrentPage = 1;
        private int AllPages = 1;
        public MainView(ApplicationContext context)
        {
            InitializeComponent();
            this.context = context;
            
            Shown += MainView_Shown;
            NextPage.Click += NextPage_Click;
            PrevPage.Click += PrevPage_Click;
            CurrentPageCount.Text = CurrentPage.ToString();
            Tenders.CellClick += Tenders_CellClick;
            DocumentationList.MouseDoubleClick += DocumentationList_MouseDoubleClick;
            SearchTender.Click += SearchTender_Click;
        }

        private void SearchTender_Click(object sender, EventArgs e)
        {
            UpdateTendersList?.Invoke(TenderNumber.Text, 1);
        }

        private void DocumentationList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DownloadDocumentFromDocumentList(e.Location);
        }
        private void DownloadDocumentFromDocumentList(Point p) 
        {
            int index = this.DocumentationList.IndexFromPoint(p);
            if (index != ListBox.NoMatches)
            {
                var item = DocumentationList.SelectedItem as documentation;
                if (item != null)
                {
                    OpenUrl(item.Url);
                }
            }
        }
        private void Tenders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TendersCellClick();
        }
        private void TendersCellClick()
        {
            var active = Tenders.CurrentRow;
            var id = active?.Cells["Id"].Value;
            if (id != null)
            {
                UpdateTenderDocumentationList?.Invoke(id.ToString());
                UpdateTenderNotice?.Invoke(id.ToString());
            }
            else 
            {
                DocumentationList.Items.Clear();
                TenderPositions.Rows.Clear();
            }
        }
        private void PrevPage_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1) 
            {
                Tenders.Rows.Clear();
                UpdateTendersList(TenderNumber.Text, --CurrentPage);
            }
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            if (CurrentPage < AllPages) 
            {
                Tenders.Rows.Clear();
                UpdateTendersList(TenderNumber.Text, ++CurrentPage);
            }
            
        }

        private void MainView_Shown(object sender, EventArgs e)
        {
            UpdateTendersList(TenderNumber.Text, 1);
        }

        public event Func<string, int, Task> UpdateTendersList;
        public event Action<string> UpdateTenderDocumentationList;
        public event Action<string> UpdateTenderNotice;

        public new void Show()
        {
            if (context.MainForm == null)
            {
                context.MainForm = this;
                Application.Run(context);
                return;
            }
            context.MainForm = this;
            base.Show();
        }

        public void UpdateTendersGrid(ITenderGetResponse model)
        {
            Tenders.Rows.Clear();
            foreach (var tender in model.Tenders)
            {
                Tenders.Rows.Add(
                    tender.Id, 
                    tender.TradeName, 
                    tender.TradeStateName, 
                    tender.CustomerFullName, 
                    tender.InitialPrice, 
                    tender.PublicationDateTime, 
                    tender.FillingApplicationEndDateTime);
            }
            AllPages = model.PagesCount;
            AllPagesCount.Text = AllPages.ToString();
            CurrentPage = model.CurrentPage;
            CurrentPageCount.Text = CurrentPage.ToString();
            TendersCellClick();
        }

        public void Wait(Progress<string> progress)
        {
            OpenChildPanel(new WaitView(progress));
        }

        public void Wait(string text)
        {
            OpenChildPanel(new WaitView(text));
        }

        public void StopWaiting()
        {
            if (activeForm != null)
                activeForm.Close();
        }

        private Form activeForm = null;
        private void OpenChildPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ChildPanel.Controls.Add(childForm);
            ChildPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void UpdateDocumentationsList(List<documentation> list)
        {
            DocumentationList.DisplayMember = "FileName";
            DocumentationList.Items.Clear();
            if (list == null) return;
            foreach (var document in list)
            {
                DocumentationList.Items.Add(document);
            }
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        public void SetOffInternetConnectionState()
        {
            Text = "Tender Win Soft";
            Text = Text + "(Отсутствует интернет-соединение!)";
        }

        public void SetOnInternetConnectionState()
        {
            Text = "Tender Win Soft";
        }

        public void UpdateTenderNoticeGrid(TenderNotice notice)
        {
            TenderPositions.Rows.Clear();
            foreach (var noticePosition in notice.Positions)
            {
                TenderPositions.Rows.Add(
                    noticePosition.Name, 
                    noticePosition.Unit, 
                    noticePosition.Count,
                    noticePosition.Price, 
                    notice.DeliveryAddress);
            }
        }
    }
}
