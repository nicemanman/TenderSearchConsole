
namespace UILauncher
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChildPanel = new System.Windows.Forms.Panel();
            this.TenderPositions = new System.Windows.Forms.DataGridView();
            this.PositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllPagesCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CurrentPageCount = new System.Windows.Forms.TextBox();
            this.DocLabel = new System.Windows.Forms.Label();
            this.DocumentationList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PrevPage = new System.Windows.Forms.Button();
            this.NextPage = new System.Windows.Forms.Button();
            this.Tenders = new System.Windows.Forms.DataGridView();
            this.TenderNumber = new System.Windows.Forms.TextBox();
            this.SearchTender = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradeStateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitialPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublicationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FillingApplicationEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChildPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TenderPositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tenders)).BeginInit();
            this.SuspendLayout();
            // 
            // ChildPanel
            // 
            this.ChildPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ChildPanel.Controls.Add(this.TenderPositions);
            this.ChildPanel.Controls.Add(this.AllPagesCount);
            this.ChildPanel.Controls.Add(this.label2);
            this.ChildPanel.Controls.Add(this.CurrentPageCount);
            this.ChildPanel.Controls.Add(this.DocLabel);
            this.ChildPanel.Controls.Add(this.DocumentationList);
            this.ChildPanel.Controls.Add(this.label1);
            this.ChildPanel.Controls.Add(this.PrevPage);
            this.ChildPanel.Controls.Add(this.NextPage);
            this.ChildPanel.Controls.Add(this.Tenders);
            this.ChildPanel.Controls.Add(this.TenderNumber);
            this.ChildPanel.Controls.Add(this.SearchTender);
            this.ChildPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChildPanel.Location = new System.Drawing.Point(0, 0);
            this.ChildPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ChildPanel.Name = "ChildPanel";
            this.ChildPanel.Size = new System.Drawing.Size(940, 600);
            this.ChildPanel.TabIndex = 0;
            // 
            // TenderPositions
            // 
            this.TenderPositions.AllowUserToAddRows = false;
            this.TenderPositions.AllowUserToDeleteRows = false;
            this.TenderPositions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TenderPositions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TenderPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TenderPositions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PositionName,
            this.Unit,
            this.Count,
            this.Price,
            this.DeliveryAddress});
            this.TenderPositions.Location = new System.Drawing.Point(15, 369);
            this.TenderPositions.Name = "TenderPositions";
            this.TenderPositions.RowTemplate.Height = 25;
            this.TenderPositions.Size = new System.Drawing.Size(913, 219);
            this.TenderPositions.TabIndex = 11;
            // 
            // PositionName
            // 
            this.PositionName.HeaderText = "Наименование";
            this.PositionName.Name = "PositionName";
            this.PositionName.Width = 174;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Ед. изм.";
            this.Unit.Name = "Unit";
            this.Unit.Width = 174;
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            this.Count.Width = 174;
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена за единицу";
            this.Price.Name = "Price";
            this.Price.Width = 174;
            // 
            // DeliveryAddress
            // 
            this.DeliveryAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeliveryAddress.HeaderText = "Адрес поставки";
            this.DeliveryAddress.Name = "DeliveryAddress";
            // 
            // AllPagesCount
            // 
            this.AllPagesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AllPagesCount.AutoSize = true;
            this.AllPagesCount.Location = new System.Drawing.Point(261, 336);
            this.AllPagesCount.Name = "AllPagesCount";
            this.AllPagesCount.Size = new System.Drawing.Size(25, 15);
            this.AllPagesCount.TabIndex = 10;
            this.AllPagesCount.Text = "780";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "/";
            // 
            // CurrentPageCount
            // 
            this.CurrentPageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentPageCount.Enabled = false;
            this.CurrentPageCount.Location = new System.Drawing.Point(135, 333);
            this.CurrentPageCount.Name = "CurrentPageCount";
            this.CurrentPageCount.Size = new System.Drawing.Size(100, 23);
            this.CurrentPageCount.TabIndex = 8;
            // 
            // DocLabel
            // 
            this.DocLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DocLabel.Location = new System.Drawing.Point(647, 44);
            this.DocLabel.Name = "DocLabel";
            this.DocLabel.Size = new System.Drawing.Size(281, 32);
            this.DocLabel.TabIndex = 7;
            this.DocLabel.Text = "Связанная документация (Двойной клик для загрузки)";
            // 
            // DocumentationList
            // 
            this.DocumentationList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DocumentationList.FormattingEnabled = true;
            this.DocumentationList.ItemHeight = 15;
            this.DocumentationList.Location = new System.Drawing.Point(647, 83);
            this.DocumentationList.Name = "DocumentationList";
            this.DocumentationList.Size = new System.Drawing.Size(281, 229);
            this.DocumentationList.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 333);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Текущая страница:";
            // 
            // PrevPage
            // 
            this.PrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrevPage.Location = new System.Drawing.Point(453, 333);
            this.PrevPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PrevPage.Name = "PrevPage";
            this.PrevPage.Size = new System.Drawing.Size(88, 27);
            this.PrevPage.TabIndex = 4;
            this.PrevPage.Text = "<<";
            this.PrevPage.UseVisualStyleBackColor = true;
            // 
            // NextPage
            // 
            this.NextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextPage.Location = new System.Drawing.Point(549, 333);
            this.NextPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NextPage.Name = "NextPage";
            this.NextPage.Size = new System.Drawing.Size(88, 27);
            this.NextPage.TabIndex = 3;
            this.NextPage.Text = ">>";
            this.NextPage.UseVisualStyleBackColor = true;
            // 
            // Tenders
            // 
            this.Tenders.AllowUserToAddRows = false;
            this.Tenders.AllowUserToDeleteRows = false;
            this.Tenders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tenders.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Tenders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tenders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TradeName,
            this.TradeStateName,
            this.CustomerFullName,
            this.InitialPrice,
            this.PublicationDate,
            this.FillingApplicationEndDate});
            this.Tenders.Location = new System.Drawing.Point(15, 44);
            this.Tenders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Tenders.Name = "Tenders";
            this.Tenders.Size = new System.Drawing.Size(622, 276);
            this.Tenders.TabIndex = 2;
            // 
            // TenderNumber
            // 
            this.TenderNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TenderNumber.Location = new System.Drawing.Point(15, 14);
            this.TenderNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TenderNumber.Name = "TenderNumber";
            this.TenderNumber.PlaceholderText = "Номер тендера";
            this.TenderNumber.Size = new System.Drawing.Size(749, 23);
            this.TenderNumber.TabIndex = 1;
            // 
            // SearchTender
            // 
            this.SearchTender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTender.Location = new System.Drawing.Point(772, 12);
            this.SearchTender.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SearchTender.Name = "SearchTender";
            this.SearchTender.Size = new System.Drawing.Size(166, 27);
            this.SearchTender.TabIndex = 0;
            this.SearchTender.Text = "Поиск тендера";
            this.SearchTender.UseVisualStyleBackColor = true;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.HeaderText = "Номер тендера";
            this.Id.Name = "Id";
            // 
            // TradeName
            // 
            this.TradeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TradeName.HeaderText = "Наименование тендера";
            this.TradeName.Name = "TradeName";
            // 
            // TradeStateName
            // 
            this.TradeStateName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TradeStateName.HeaderText = "Текущий статус";
            this.TradeStateName.Name = "TradeStateName";
            // 
            // CustomerFullName
            // 
            this.CustomerFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CustomerFullName.HeaderText = "Наименование заказчика";
            this.CustomerFullName.Name = "CustomerFullName";
            // 
            // InitialPrice
            // 
            this.InitialPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InitialPrice.HeaderText = "НМЦ";
            this.InitialPrice.Name = "InitialPrice";
            // 
            // PublicationDate
            // 
            this.PublicationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PublicationDate.HeaderText = "Дата публикации";
            this.PublicationDate.Name = "PublicationDate";
            // 
            // FillingApplicationEndDate
            // 
            this.FillingApplicationEndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FillingApplicationEndDate.HeaderText = "Дата окончания подачи заявок";
            this.FillingApplicationEndDate.Name = "FillingApplicationEndDate";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 600);
            this.Controls.Add(this.ChildPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainView";
            this.Text = "Tender Win Soft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ChildPanel.ResumeLayout(false);
            this.ChildPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TenderPositions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tenders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ChildPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PrevPage;
        private System.Windows.Forms.Button NextPage;
        private System.Windows.Forms.DataGridView Tenders;
        private System.Windows.Forms.TextBox TenderNumber;
        private System.Windows.Forms.Button SearchTender;
        private System.Windows.Forms.Label DocLabel;
        private System.Windows.Forms.ListBox DocumentationList;
        private System.Windows.Forms.Label AllPagesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CurrentPageCount;
        private System.Windows.Forms.DataGridView TenderPositions;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveryAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradeStateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitialPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublicationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FillingApplicationEndDate;
    }
}

