namespace SwissArmyKnife
{
    partial class PremiumUserForm
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

            //
            // lblTitle
            //
            lblTitle = new Label();
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(117, 89, 179);
            lblTitle.Location = new Point(12, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(185, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Premium User";
            //
            // lblSubtitle
            //
            lblSubtitle = new Label();
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.FromArgb(164, 165, 169);
            lblSubtitle.Location = new Point(12, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(320, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Full access to all scanning tools and features";
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
            // btnNetworkScanner
            //
            btnNetworkScanner = new Button();
            btnNetworkScanner.BackColor = Color.FromArgb(34, 140, 60);
            btnNetworkScanner.Cursor = Cursors.Hand;
            btnNetworkScanner.FlatAppearance.BorderSize = 0;
            btnNetworkScanner.FlatStyle = FlatStyle.Flat;
            btnNetworkScanner.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNetworkScanner.ForeColor = Color.White;
            btnNetworkScanner.Location = new Point(12, 140);
            btnNetworkScanner.Name = "btnNetworkScanner";
            btnNetworkScanner.Size = new Size(200, 50);
            btnNetworkScanner.TabIndex = 3;
            btnNetworkScanner.Text = "Network Scanner";
            btnNetworkScanner.UseVisualStyleBackColor = false;
            btnNetworkScanner.Click += BtnNetworkScanner_Click;
            //
            // btnWebAuditor
            //
            btnWebAuditor = new Button();
            btnWebAuditor.BackColor = Color.FromArgb(34, 140, 60);
            btnWebAuditor.Cursor = Cursors.Hand;
            btnWebAuditor.FlatAppearance.BorderSize = 0;
            btnWebAuditor.FlatStyle = FlatStyle.Flat;
            btnWebAuditor.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWebAuditor.ForeColor = Color.White;
            btnWebAuditor.Location = new Point(230, 140);
            btnWebAuditor.Name = "btnWebAuditor";
            btnWebAuditor.Size = new Size(200, 50);
            btnWebAuditor.TabIndex = 4;
            btnWebAuditor.Text = "Web Security Auditor";
            btnWebAuditor.UseVisualStyleBackColor = false;
            btnWebAuditor.Click += BtnWebAuditor_Click;
            //
            // btnSavedConfigs
            //
            btnSavedConfigs = new Button();
            btnSavedConfigs.BackColor = Color.FromArgb(60, 60, 70);
            btnSavedConfigs.Cursor = Cursors.Hand;
            btnSavedConfigs.FlatAppearance.BorderSize = 0;
            btnSavedConfigs.FlatStyle = FlatStyle.Flat;
            btnSavedConfigs.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSavedConfigs.ForeColor = Color.White;
            btnSavedConfigs.Location = new Point(448, 140);
            btnSavedConfigs.Name = "btnSavedConfigs";
            btnSavedConfigs.Size = new Size(200, 50);
            btnSavedConfigs.TabIndex = 5;
            btnSavedConfigs.Text = "Saved Configurations";
            btnSavedConfigs.UseVisualStyleBackColor = false;
            btnSavedConfigs.Click += BtnSavedConfigs_Click;
            //
            // btnSchedule
            //
            btnSchedule = new Button();
            btnSchedule.BackColor = Color.FromArgb(60, 60, 70);
            btnSchedule.Cursor = Cursors.Hand;
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.FlatStyle = FlatStyle.Flat;
            btnSchedule.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSchedule.ForeColor = Color.White;
            btnSchedule.Location = new Point(666, 140);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(200, 50);
            btnSchedule.TabIndex = 6;
            btnSchedule.Text = "Scheduled Scans";
            btnSchedule.UseVisualStyleBackColor = false;
            btnSchedule.Click += BtnSchedule_Click;
            //
            // pnlStats
            //
            pnlStats = new Panel();
            pnlStats.BackColor = Color.FromArgb(35, 35, 43);
            pnlStats.BorderStyle = BorderStyle.FixedSingle;
            pnlStats.Location = new Point(12, 210);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(860, 150);
            pnlStats.TabIndex = 7;
            //
            // lblStatsTitle
            //
            lblStatsTitle = new Label();
            lblStatsTitle.AutoSize = true;
            lblStatsTitle.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatsTitle.ForeColor = Color.FromArgb(117, 89, 179);
            lblStatsTitle.Location = new Point(15, 190);
            lblStatsTitle.Name = "lblStatsTitle";
            lblStatsTitle.Size = new Size(100, 20);
            lblStatsTitle.TabIndex = 8;
            lblStatsTitle.Text = "Your Activity";
            //
            // lblTotalScans
            //
            lblTotalScans = new Label();
            lblTotalScans.AutoSize = true;
            lblTotalScans.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalScans.ForeColor = Color.FromArgb(80, 200, 130);
            lblTotalScans.Location = new Point(25, 230);
            lblTotalScans.Name = "lblTotalScans";
            lblTotalScans.Size = new Size(180, 20);
            lblTotalScans.TabIndex = 9;
            lblTotalScans.Text = "Total scans: 0";
            //
            // lblThisMonth
            //
            lblThisMonth = new Label();
            lblThisMonth.AutoSize = true;
            lblThisMonth.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThisMonth.ForeColor = Color.FromArgb(220, 220, 230);
            lblThisMonth.Location = new Point(25, 260);
            lblThisMonth.Name = "lblThisMonth";
            lblThisMonth.Size = new Size(160, 19);
            lblThisMonth.TabIndex = 10;
            lblThisMonth.Text = "This month: 0 scans";
            //
            // lblLastMonth
            //
            lblLastMonth = new Label();
            lblLastMonth.AutoSize = true;
            lblLastMonth.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastMonth.ForeColor = Color.FromArgb(220, 220, 230);
            lblLastMonth.Location = new Point(25, 290);
            lblLastMonth.Name = "lblLastMonth";
            lblLastMonth.Size = new Size(150, 19);
            lblLastMonth.TabIndex = 11;
            lblLastMonth.Text = "Last month: 0 scans";
            //
            // lblUnlimited
            //
            lblUnlimited = new Label();
            lblUnlimited.AutoSize = true;
            lblUnlimited.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUnlimited.ForeColor = Color.FromArgb(80, 200, 130);
            lblUnlimited.Location = new Point(500, 230);
            lblUnlimited.Name = "lblUnlimited";
            lblUnlimited.Size = new Size(180, 19);
            lblUnlimited.TabIndex = 12;
            lblUnlimited.Text = "✓ Unlimited scans";
            //
            // lblFullPorts
            //
            lblFullPorts = new Label();
            lblFullPorts.AutoSize = true;
            lblFullPorts.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFullPorts.ForeColor = Color.FromArgb(80, 200, 130);
            lblFullPorts.Location = new Point(500, 260);
            lblFullPorts.Name = "lblFullPorts";
            lblFullPorts.Size = new Size(230, 19);
            lblFullPorts.TabIndex = 13;
            lblFullPorts.Text = "✓ Full port range (1-65535)";
            //
            // lblExportAll
            //
            lblExportAll = new Label();
            lblExportAll.AutoSize = true;
            lblExportAll.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExportAll.ForeColor = Color.FromArgb(80, 200, 130);
            lblExportAll.Location = new Point(500, 290);
            lblExportAll.Name = "lblExportAll";
            lblExportAll.Size = new Size(210, 19);
            lblExportAll.TabIndex = 14;
            lblExportAll.Text = "✓ Export: CSV, TXT, PDF";
            //
            // btnScanHistory
            //
            btnScanHistory = new Button();
            btnScanHistory.BackColor = Color.FromArgb(60, 60, 70);
            btnScanHistory.Cursor = Cursors.Hand;
            btnScanHistory.FlatAppearance.BorderSize = 0;
            btnScanHistory.FlatStyle = FlatStyle.Flat;
            btnScanHistory.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnScanHistory.ForeColor = Color.White;
            btnScanHistory.Location = new Point(12, 380);
            btnScanHistory.Name = "btnScanHistory";
            btnScanHistory.Size = new Size(200, 40);
            btnScanHistory.TabIndex = 15;
            btnScanHistory.Text = "Full Scan History";
            btnScanHistory.UseVisualStyleBackColor = false;
            btnScanHistory.Click += BtnScanHistory_Click;
            //
            // btnCompare
            //
            btnCompare = new Button();
            btnCompare.BackColor = Color.FromArgb(60, 60, 70);
            btnCompare.Cursor = Cursors.Hand;
            btnCompare.FlatAppearance.BorderSize = 0;
            btnCompare.FlatStyle = FlatStyle.Flat;
            btnCompare.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCompare.ForeColor = Color.White;
            btnCompare.Location = new Point(230, 380);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(200, 40);
            btnCompare.TabIndex = 16;
            btnCompare.Text = "Compare Results";
            btnCompare.UseVisualStyleBackColor = false;
            btnCompare.Click += BtnCompare_Click;
            //
            // btnAnalytics
            //
            btnAnalytics = new Button();
            btnAnalytics.BackColor = Color.FromArgb(60, 60, 70);
            btnAnalytics.Cursor = Cursors.Hand;
            btnAnalytics.FlatAppearance.BorderSize = 0;
            btnAnalytics.FlatStyle = FlatStyle.Flat;
            btnAnalytics.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnalytics.ForeColor = Color.White;
            btnAnalytics.Location = new Point(448, 380);
            btnAnalytics.Name = "btnAnalytics";
            btnAnalytics.Size = new Size(200, 40);
            btnAnalytics.TabIndex = 17;
            btnAnalytics.Text = "Analytics Dashboard";
            btnAnalytics.UseVisualStyleBackColor = false;
            btnAnalytics.Click += BtnAnalytics_Click;
            //
            // btnLogout
            //
            btnLogout = new Button();
            btnLogout.BackColor = Color.FromArgb(160, 40, 40);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(772, 600);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 35);
            btnLogout.TabIndex = 18;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
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
            btnClose.TabIndex = 19;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            //
            // lblRoleBadge
            //
            lblRoleBadge = new Label();
            lblRoleBadge.AutoSize = true;
            lblRoleBadge.BackColor = Color.FromArgb(220, 170, 40);
            lblRoleBadge.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoleBadge.ForeColor = Color.FromArgb(30, 30, 38);
            lblRoleBadge.Location = new Point(700, 25);
            lblRoleBadge.Name = "lblRoleBadge";
            lblRoleBadge.Padding = new Padding(8, 4, 8, 4);
            lblRoleBadge.Size = new Size(90, 23);
            lblRoleBadge.TabIndex = 20;
            lblRoleBadge.Text = "PREMIUM";
            //
            // PremiumUserForm
            //
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 38);
            ClientSize = new Size(900, 660);
            Controls.Add(lblRoleBadge);
            Controls.Add(btnClose);
            Controls.Add(btnLogout);
            Controls.Add(btnAnalytics);
            Controls.Add(btnCompare);
            Controls.Add(btnScanHistory);
            Controls.Add(lblExportAll);
            Controls.Add(lblFullPorts);
            Controls.Add(lblUnlimited);
            Controls.Add(lblLastMonth);
            Controls.Add(lblThisMonth);
            Controls.Add(lblTotalScans);
            Controls.Add(lblStatsTitle);
            Controls.Add(pnlStats);
            Controls.Add(btnSchedule);
            Controls.Add(btnSavedConfigs);
            Controls.Add(btnWebAuditor);
            Controls.Add(btnNetworkScanner);
            Controls.Add(lblWelcome);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(900, 660);
            Name = "PremiumUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Premium User Dashboard";
            Load += PremiumUserForm_Load;

        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblWelcome;
        private Button btnNetworkScanner;
        private Button btnWebAuditor;
        private Button btnSavedConfigs;
        private Button btnSchedule;
        private Panel pnlStats;
        private Label lblStatsTitle;
        private Label lblTotalScans;
        private Label lblThisMonth;
        private Label lblLastMonth;
        private Label lblUnlimited;
        private Label lblFullPorts;
        private Label lblExportAll;
        private Button btnScanHistory;
        private Button btnCompare;
        private Button btnAnalytics;
        private Button btnLogout;
        private Label btnClose;
        private Label lblRoleBadge;

    }
}

/*
 
 namespace SwissArmyKnife
{
    partial class PremiumUserForm
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
        {}

        #endregion
    }
}
 
 
 */