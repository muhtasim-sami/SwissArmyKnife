namespace SwissArmyKnife
{
    partial class FullScanHistoryForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Text = "Full Scan History";
            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 38);

            // Filter panel
            Panel filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 45;
            filterPanel.BackColor = Color.FromArgb(35, 35, 43);
            filterPanel.Padding = new Padding(10);

            Label lblFilter = new Label();
            lblFilter.Text = "Filter:";
            lblFilter.ForeColor = Color.FromArgb(220, 220, 230);
            lblFilter.Location = new Point(10, 12);
            lblFilter.Size = new Size(45, 25);

            cboFilter = new ComboBox();
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.BackColor = Color.FromArgb(44, 44, 56);
            cboFilter.ForeColor = Color.FromArgb(220, 220, 230);
            cboFilter.Location = new Point(60, 10);
            cboFilter.Size = new Size(120, 25);
            cboFilter.Items.AddRange(new object[] { "All", "Network", "Web", "SSH" });
            cboFilter.SelectedIndex = 0;

            Label lblDateRange = new Label();
            lblDateRange.Text = "Date Range:";
            lblDateRange.ForeColor = Color.FromArgb(220, 220, 230);
            lblDateRange.Location = new Point(200, 12);
            lblDateRange.Size = new Size(80, 25);

            dtpStart = new DateTimePicker();
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(285, 10);
            dtpStart.Size = new Size(100, 25);
            dtpStart.Value = DateTime.Now.AddDays(-30);

            Label lblTo = new Label();
            lblTo.Text = "to";
            lblTo.ForeColor = Color.FromArgb(220, 220, 230);
            lblTo.Location = new Point(395, 12);
            lblTo.Size = new Size(25, 25);

            dtpEnd = new DateTimePicker();
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(425, 10);
            dtpEnd.Size = new Size(100, 25);
            dtpEnd.Value = DateTime.Now;

            btnFilter = new Button();
            btnFilter.Text = "Apply Filter";
            btnFilter.BackColor = Color.FromArgb(34, 140, 60);
            btnFilter.ForeColor = Color.White;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Size = new Size(100, 28);
            btnFilter.Location = new Point(540, 8);
            btnFilter.Click += BtnFilter_Click;

            filterPanel.Controls.Add(lblFilter);
            filterPanel.Controls.Add(cboFilter);
            filterPanel.Controls.Add(lblDateRange);
            filterPanel.Controls.Add(dtpStart);
            filterPanel.Controls.Add(lblTo);
            filterPanel.Controls.Add(dtpEnd);
            filterPanel.Controls.Add(btnFilter);

            // ListView
            lvHistory = new ListView();
            lvHistory.Dock = DockStyle.Top;
            lvHistory.Height = 500;
            lvHistory.View = View.Details;
            lvHistory.FullRowSelect = true;
            lvHistory.BackColor = Color.FromArgb(35, 35, 43);
            lvHistory.ForeColor = Color.FromArgb(220, 220, 230);
            lvHistory.Columns.Add("Scan Type", 100);
            lvHistory.Columns.Add("Target", 250);
            lvHistory.Columns.Add("Mode", 100);
            lvHistory.Columns.Add("Date", 150);
            lvHistory.Columns.Add("Duration", 100);
            lvHistory.Columns.Add("Hosts Up", 80);
            lvHistory.Columns.Add("Open Ports", 80);
            lvHistory.Columns.Add("Status", 100);

            // Button panel
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 50;
            buttonPanel.BackColor = Color.FromArgb(35, 35, 43);

            btnExport = new Button();
            btnExport.Text = "Export to CSV";
            btnExport.BackColor = Color.FromArgb(40, 80, 140);
            btnExport.ForeColor = Color.White;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Size = new Size(120, 35);
            btnExport.Location = new Point(750, 8);
            btnExport.Click += BtnExport_Click;

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.BackColor = Color.FromArgb(60, 60, 70);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(880, 8);
            btnClose.Click += (s, e) => Close();

            buttonPanel.Controls.Add(btnExport);
            buttonPanel.Controls.Add(btnClose);

            Controls.Add(buttonPanel);
            Controls.Add(lvHistory);
            Controls.Add(filterPanel);

        }

        #endregion

        private ListView lvHistory;
        private ComboBox cboFilter;
        private Button btnFilter;
        private Button btnExport;
        private Button btnClose;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
    }
}
