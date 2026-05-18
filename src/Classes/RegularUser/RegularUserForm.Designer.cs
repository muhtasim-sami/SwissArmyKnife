namespace SwissArmyKnife
{
    partial class RegularUserForm
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
            lblTitle.Size = new Size(175, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Regular User";
            //
            // lblSubtitle
            //
            lblSubtitle = new Label();
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.FromArgb(164, 165, 169);
            lblSubtitle.Location = new Point(12, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(310, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Basic scanning tools (limited to 10 hosts)";
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
            // btnScanHistory
            //
            btnScanHistory = new Button();
            btnScanHistory.BackColor = Color.FromArgb(60, 60, 70);
            btnScanHistory.Cursor = Cursors.Hand;
            btnScanHistory.FlatAppearance.BorderSize = 0;
            btnScanHistory.FlatStyle = FlatStyle.Flat;
            btnScanHistory.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnScanHistory.ForeColor = Color.White;
            btnScanHistory.Location = new Point(448, 140);
            btnScanHistory.Name = "btnScanHistory";
            btnScanHistory.Size = new Size(200, 50);
            btnScanHistory.TabIndex = 5;
            btnScanHistory.Text = "Scan History (7 days)";
            btnScanHistory.UseVisualStyleBackColor = false;
            btnScanHistory.Click += BtnScanHistory_Click;
            //
            // btnUpgrade
            //
            btnUpgrade = new Button();
            btnUpgrade.BackColor = Color.FromArgb(220, 170, 40);
            btnUpgrade.Cursor = Cursors.Hand;
            btnUpgrade.FlatAppearance.BorderSize = 0;
            btnUpgrade.FlatStyle = FlatStyle.Flat;
            btnUpgrade.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpgrade.ForeColor = Color.FromArgb(30, 30, 38);
            btnUpgrade.Location = new Point(666, 140);
            btnUpgrade.Name = "btnUpgrade";
            btnUpgrade.Size = new Size(200, 50);
            btnUpgrade.TabIndex = 6;
            btnUpgrade.Text = "Upgrade to Premium";
            btnUpgrade.UseVisualStyleBackColor = false;
            btnUpgrade.Click += BtnUpgrade_Click;
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
            // lblScansToday
            //
            lblScansToday = new Label();
            lblScansToday.AutoSize = true;
            lblScansToday.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScansToday.ForeColor = Color.FromArgb(220, 220, 230);
            lblScansToday.Location = new Point(25, 230);
            lblScansToday.Name = "lblScansToday";
            lblScansToday.Size = new Size(150, 19);
            lblScansToday.TabIndex = 9;
            lblScansToday.Text = "Scans today: 0 / 5";
            //
            // lblRemaining
            //
            lblRemaining = new Label();
            lblRemaining.AutoSize = true;
            lblRemaining.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRemaining.ForeColor = Color.FromArgb(164, 165, 169);
            lblRemaining.Location = new Point(25, 260);
            lblRemaining.Name = "lblRemaining";
            lblRemaining.Size = new Size(200, 19);
            lblRemaining.TabIndex = 10;
            lblRemaining.Text = "Scans remaining today: 5";
            //
            // lblTotalScans
            //
            lblTotalScans = new Label();
            lblTotalScans.AutoSize = true;
            lblTotalScans.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalScans.ForeColor = Color.FromArgb(220, 220, 230);
            lblTotalScans.Location = new Point(25, 290);
            lblTotalScans.Name = "lblTotalScans";
            lblTotalScans.Size = new Size(200, 19);
            lblTotalScans.TabIndex = 11;
            lblTotalScans.Text = "Total scans this month: 0";
            //
            // lblHostLimit
            //
            lblHostLimit = new Label();
            lblHostLimit.AutoSize = true;
            lblHostLimit.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHostLimit.ForeColor = Color.FromArgb(220, 170, 40);
            lblHostLimit.Location = new Point(500, 230);
            lblHostLimit.Name = "lblHostLimit";
            lblHostLimit.Size = new Size(250, 19);
            lblHostLimit.TabIndex = 12;
            lblHostLimit.Text = "Host limit per scan: 10 hosts";
            //
            // lblPortLimit
            //
            lblPortLimit = new Label();
            lblPortLimit.AutoSize = true;
            lblPortLimit.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPortLimit.ForeColor = Color.FromArgb(220, 170, 40);
            lblPortLimit.Location = new Point(500, 260);
            lblPortLimit.Name = "lblPortLimit";
            lblPortLimit.Size = new Size(280, 19);
            lblPortLimit.TabIndex = 13;
            lblPortLimit.Text = "Port scan limited to Top 100 ports";
            //
            // lblExportLimit
            //
            lblExportLimit = new Label();
            lblExportLimit.AutoSize = true;
            lblExportLimit.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExportLimit.ForeColor = Color.FromArgb(220, 170, 40);
            lblExportLimit.Location = new Point(500, 290);
            lblExportLimit.Name = "lblExportLimit";
            lblExportLimit.Size = new Size(250, 19);
            lblExportLimit.TabIndex = 14;
            lblExportLimit.Text = "Export format: TXT only";
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
            btnLogout.TabIndex = 15;
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
            btnClose.TabIndex = 16;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            //
            // lblRoleBadge
            //
            lblRoleBadge = new Label();
            lblRoleBadge.AutoSize = true;
            lblRoleBadge.BackColor = Color.FromArgb(60, 60, 70);
            lblRoleBadge.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoleBadge.ForeColor = Color.White;
            lblRoleBadge.Location = new Point(700, 25);
            lblRoleBadge.Name = "lblRoleBadge";
            lblRoleBadge.Padding = new Padding(8, 4, 8, 4);
            lblRoleBadge.Size = new Size(90, 23);
            lblRoleBadge.TabIndex = 17;
            lblRoleBadge.Text = "REGULAR";
            //
            // RegularUserForm
            //
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 38);
            ClientSize = new Size(900, 660);
            Controls.Add(lblRoleBadge);
            Controls.Add(btnClose);
            Controls.Add(btnLogout);
            Controls.Add(lblExportLimit);
            Controls.Add(lblPortLimit);
            Controls.Add(lblHostLimit);
            Controls.Add(lblTotalScans);
            Controls.Add(lblRemaining);
            Controls.Add(lblScansToday);
            Controls.Add(lblStatsTitle);
            Controls.Add(pnlStats);
            Controls.Add(btnUpgrade);
            Controls.Add(btnScanHistory);
            Controls.Add(btnWebAuditor);
            Controls.Add(btnNetworkScanner);
            Controls.Add(lblWelcome);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(900, 660);
            Name = "RegularUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Regular User Dashboard";
            Load += RegularUserForm_Load;

        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblWelcome;
        private Button btnNetworkScanner;
        private Button btnWebAuditor;
        private Button btnScanHistory;
        private Button btnUpgrade;
        private Panel pnlStats;
        private Label lblStatsTitle;
        private Label lblScansToday;
        private Label lblRemaining;
        private Label lblTotalScans;
        private Label lblHostLimit;
        private Label lblPortLimit;
        private Label lblExportLimit;
        private Button btnLogout;
        private Label btnClose;
        private Label lblRoleBadge;
    }
}

