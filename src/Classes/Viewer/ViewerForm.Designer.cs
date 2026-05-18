namespace SwissArmyKnife
{
    partial class ViewerForm
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
            //SuspendLayout();
            //
            // lblTitle
            //
            lblTitle = new Label();
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(117, 89, 179);
            lblTitle.Location = new Point(12, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(175, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Viewer Portal";
            //
            // lblSubtitle
            //
            lblSubtitle = new Label();
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.FromArgb(164, 165, 169);
            lblSubtitle.Location = new Point(12, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(260, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Read-only access to assigned reports";
            //
            // lblWelcome
            //
            lblWelcome = new Label();
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Nirmala UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.FromArgb(220, 220, 230);
            lblWelcome.Location = new Point(12, 100);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 21);
            lblWelcome.TabIndex = 2;
            //
            // pnlReports
            //
            pnlReports = new Panel();
            pnlReports.BackColor = Color.FromArgb(30, 30, 38);
            pnlReports.BorderStyle = BorderStyle.FixedSingle;
            pnlReports.Location = new Point(12, 140);
            pnlReports.Name = "pnlReports";
            pnlReports.Size = new Size(860, 400);
            pnlReports.TabIndex = 3;
            //
            // lblReportsHeader
            //
            lblReportsHeader = new Label();
            lblReportsHeader.AutoSize = true;
            lblReportsHeader.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReportsHeader.ForeColor = Color.FromArgb(117, 89, 179);
            lblReportsHeader.Location = new Point(15, 118);
            lblReportsHeader.Name = "lblReportsHeader";
            lblReportsHeader.Size = new Size(120, 20);
            lblReportsHeader.TabIndex = 4;
            lblReportsHeader.Text = "Assigned Reports";
            //
            // lvReports
            //
            lvReports = new ListView();
            lvReports.BackColor = Color.FromArgb(35, 35, 43);
            lvReports.BorderStyle = BorderStyle.None;
            lvReports.Dock = DockStyle.Fill;
            lvReports.ForeColor = Color.FromArgb(220, 220, 230);
            lvReports.FullRowSelect = true;
            lvReports.GridLines = false;
            lvReports.View = View.Details;
            lvReports.Columns.Add("Report Name", 250);
            lvReports.Columns.Add("Scan Type", 120);
            lvReports.Columns.Add("Target", 180);
            lvReports.Columns.Add("Date", 150);
            lvReports.Columns.Add("Status", 100);
            lvReports.Location = new Point(0, 0);
            lvReports.Name = "lvReports";
            lvReports.Size = new Size(858, 398);
            lvReports.TabIndex = 0;
            lvReports.UseCompatibleStateImageBehavior = false;
            lvReports.DoubleClick += LvReports_DoubleClick;
            lvReports.SelectedIndexChanged += LvReports_SelectedIndexChanged;
            //
            // pnlReports
            //
            pnlReports.Controls.Add(lvReports);
            //
            // btnViewReport
            //
            btnViewReport = new Button();
            btnViewReport.BackColor = Color.FromArgb(34, 140, 60);
            btnViewReport.Cursor = Cursors.Hand;
            btnViewReport.Enabled = false;
            btnViewReport.FlatAppearance.BorderSize = 0;
            btnViewReport.FlatStyle = FlatStyle.Flat;
            btnViewReport.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewReport.ForeColor = Color.White;
            btnViewReport.Location = new Point(12, 555);
            btnViewReport.Name = "btnViewReport";
            btnViewReport.Size = new Size(120, 35);
            btnViewReport.TabIndex = 5;
            btnViewReport.Text = "View Report";
            btnViewReport.UseVisualStyleBackColor = false;
            btnViewReport.Click += BtnViewReport_Click;
            //
            // btnExportPDF
            //
            btnExportPDF = new Button();
            btnExportPDF.BackColor = Color.FromArgb(40, 80, 140);
            btnExportPDF.Cursor = Cursors.Hand;
            btnExportPDF.Enabled = false;
            btnExportPDF.FlatAppearance.BorderSize = 0;
            btnExportPDF.FlatStyle = FlatStyle.Flat;
            btnExportPDF.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportPDF.ForeColor = Color.White;
            btnExportPDF.Location = new Point(140, 555);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(120, 35);
            btnExportPDF.TabIndex = 6;
            btnExportPDF.Text = "Export PDF";
            btnExportPDF.UseVisualStyleBackColor = false;
            btnExportPDF.Click += BtnExportPDF_Click;
            //
            // btnRefresh
            //
            btnRefresh = new Button();
            btnRefresh.BackColor = Color.FromArgb(60, 60, 70);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(270, 555);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            //
            // btnClose
            //
            btnClose = new Label();
            btnClose.AutoSize = true;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(164, 165, 169);
            btnClose.Location = new Point(850, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(29, 25);
            btnClose.TabIndex = 8;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            //
            // lblRoleBadge
            //
            lblRoleBadge = new Label();
            lblRoleBadge.AutoSize = true;
            lblRoleBadge.BackColor = Color.FromArgb(117, 89, 179);
            lblRoleBadge.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoleBadge.ForeColor = Color.White;
            lblRoleBadge.Location = new Point(750, 25);
            lblRoleBadge.Name = "lblRoleBadge";
            lblRoleBadge.Padding = new Padding(8, 4, 8, 4);
            lblRoleBadge.Size = new Size(70, 23);
            lblRoleBadge.TabIndex = 9;
            lblRoleBadge.Text = "VIEWER";

            //
            // ViewerForm
            //
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 38);
            ClientSize = new Size(900, 620);
            Controls.Add(lblRoleBadge);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Controls.Add(btnExportPDF);
            Controls.Add(btnViewReport);
            Controls.Add(pnlReports);
            Controls.Add(lblReportsHeader);
            Controls.Add(lblWelcome);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(900, 620);
            Name = "ViewerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Viewer Portal";
            Load += ViewerForm_Load;
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblWelcome;
        private Panel pnlReports;
        private Label lblReportsHeader;
        private ListView lvReports;
        private Button btnViewReport;
        private Button btnExportPDF;
        private Button btnRefresh;
        private Label btnClose;
        private Label lblRoleBadge;
    }
}


/*
 
 namespace SwissArmyKnife
{
    partial class ViewerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
        }

        #endregion

        
    }
}
 
 */