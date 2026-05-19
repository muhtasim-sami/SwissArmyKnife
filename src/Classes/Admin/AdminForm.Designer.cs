namespace SwissArmyKnife
{
    partial class AdminForm
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
            lblTitle.Size = new Size(120, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Admin";
            //
            // lblSubtitle
            //
            lblSubtitle = new Label();
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.FromArgb(164, 165, 169);
            lblSubtitle.Location = new Point(12, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(280, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "System Administration and User Management";
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
            // tabControl
            //
            tabControl = new TabControl();
            tabControl.Location = new Point(12, 130);
            tabControl.Size = new Size(1060, 560);
            tabControl.TabIndex = 3;
            //
            // tabUsers
            //
            tabUsers = new TabPage();
            tabUsers.BackColor = Color.FromArgb(30, 30, 38);
            tabUsers.Text = "  User Management  ";
            //
            // pnlUsersToolbar
            //
            pnlUsersToolbar = new Panel();
            pnlUsersToolbar.BackColor = Color.FromArgb(26, 26, 34);
            pnlUsersToolbar.Dock = DockStyle.Top;
            pnlUsersToolbar.Height = 50;
            pnlUsersToolbar.Padding = new Padding(8);
            //
            // btnRefreshUsers
            //
            btnRefreshUsers = new Button();
            btnRefreshUsers.BackColor = Color.FromArgb(60, 60, 70);
            btnRefreshUsers.Cursor = Cursors.Hand;
            btnRefreshUsers.FlatAppearance.BorderSize = 0;
            btnRefreshUsers.FlatStyle = FlatStyle.Flat;
            btnRefreshUsers.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            btnRefreshUsers.ForeColor = Color.White;
            btnRefreshUsers.Location = new Point(8, 8);
            btnRefreshUsers.Name = "btnRefreshUsers";
            btnRefreshUsers.Size = new Size(100, 34);
            btnRefreshUsers.TabIndex = 0;
            btnRefreshUsers.Text = "Refresh";
            btnRefreshUsers.UseVisualStyleBackColor = false;
            btnRefreshUsers.Click += BtnRefreshUsers_Click;
            //
            // btnEditUser
            //
            btnEditUser = new Button();
            btnEditUser.BackColor = Color.FromArgb(40, 80, 140);
            btnEditUser.Cursor = Cursors.Hand;
            btnEditUser.FlatAppearance.BorderSize = 0;
            btnEditUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            btnEditUser.ForeColor = Color.White;
            btnEditUser.Location = new Point(118, 8);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(100, 34);
            btnEditUser.TabIndex = 1;
            btnEditUser.Text = "Edit User";
            btnEditUser.UseVisualStyleBackColor = false;
            btnEditUser.Click += BtnEditUser_Click;
            //
            // btnDeleteUser
            //
            btnDeleteUser = new Button();
            btnDeleteUser.BackColor = Color.FromArgb(160, 40, 40);
            btnDeleteUser.Cursor = Cursors.Hand;
            btnDeleteUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(228, 8);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(100, 34);
            btnDeleteUser.TabIndex = 2;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += BtnDeleteUser_Click;
            //
            // btnToggleActive
            //
            btnToggleActive = new Button();
            btnToggleActive.BackColor = Color.FromArgb(220, 170, 40);
            btnToggleActive.Cursor = Cursors.Hand;
            btnToggleActive.FlatAppearance.BorderSize = 0;
            btnToggleActive.FlatStyle = FlatStyle.Flat;
            btnToggleActive.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            btnToggleActive.ForeColor = Color.FromArgb(30, 30, 38);
            btnToggleActive.Location = new Point(338, 8);
            btnToggleActive.Name = "btnToggleActive";
            btnToggleActive.Size = new Size(130, 34);
            btnToggleActive.TabIndex = 3;
            btnToggleActive.Text = "Toggle Status";
            btnToggleActive.UseVisualStyleBackColor = false;
            btnToggleActive.Click += BtnToggleActive_Click;
            //
            // lblSearch
            //
            lblSearch = new Label();
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(164, 165, 169);
            lblSearch.Location = new Point(500, 16);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(55, 19);
            lblSearch.TabIndex = 4;
            lblSearch.Text = "Search:";
            //
            // txtSearch
            //
            txtSearch = new TextBox();
            txtSearch.BackColor = Color.FromArgb(44, 44, 56);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Consolas", 10F);
            txtSearch.ForeColor = Color.FromArgb(80, 200, 130);
            txtSearch.Location = new Point(565, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 20);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            //
            pnlUsersToolbar.Controls.Add(lblSearch);
            pnlUsersToolbar.Controls.Add(txtSearch);
            pnlUsersToolbar.Controls.Add(btnRefreshUsers);
            pnlUsersToolbar.Controls.Add(btnEditUser);
            pnlUsersToolbar.Controls.Add(btnDeleteUser);
            pnlUsersToolbar.Controls.Add(btnToggleActive);
            //
            // lvUsers
            //
            lvUsers = new ListView();
            lvUsers.Dock = DockStyle.Fill;
            lvUsers.View = View.Details;
            lvUsers.FullRowSelect = true;
            lvUsers.GridLines = false;
            lvUsers.BackColor = Color.FromArgb(35, 35, 43);
            lvUsers.ForeColor = Color.FromArgb(220, 220, 230);
            lvUsers.Font = new Font("Consolas", 9F);
            lvUsers.Columns.Add("ID", 50);
            lvUsers.Columns.Add("Username", 150);
            lvUsers.Columns.Add("Email", 200);
            lvUsers.Columns.Add("Role", 120);
            lvUsers.Columns.Add("Status", 80);
            lvUsers.Columns.Add("Created", 150);
            lvUsers.Columns.Add("Last Login", 150);
            lvUsers.SelectedIndexChanged += LvUsers_SelectedIndexChanged;
            //
            tabUsers.Controls.Add(pnlUsersToolbar);
            tabUsers.Controls.Add(lvUsers);
            //
            // tabRequests
            //
            tabRequests = new TabPage();
            tabRequests.BackColor = Color.FromArgb(30, 30, 38);
            tabRequests.Text = "  Upgrade Requests  ";
            //
            // pnlRequestsToolbar
            //
            pnlRequestsToolbar = new Panel();
            pnlRequestsToolbar.BackColor = Color.FromArgb(26, 26, 34);
            pnlRequestsToolbar.Dock = DockStyle.Top;
            pnlRequestsToolbar.Height = 50;
            pnlRequestsToolbar.Padding = new Padding(8);
            //
            // btnRefreshRequests
            //
            btnRefreshRequests = new Button();
            btnRefreshRequests.BackColor = Color.FromArgb(60, 60, 70);
            btnRefreshRequests.Cursor = Cursors.Hand;
            btnRefreshRequests.FlatAppearance.BorderSize = 0;
            btnRefreshRequests.FlatStyle = FlatStyle.Flat;
            btnRefreshRequests.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            btnRefreshRequests.ForeColor = Color.White;
            btnRefreshRequests.Location = new Point(8, 8);
            btnRefreshRequests.Name = "btnRefreshRequests";
            btnRefreshRequests.Size = new Size(100, 34);
            btnRefreshRequests.TabIndex = 0;
            btnRefreshRequests.Text = "Refresh";
            btnRefreshRequests.UseVisualStyleBackColor = false;
            btnRefreshRequests.Click += BtnRefreshRequests_Click;
            //
            // btnApproveRequest
            //
            btnApproveRequest = new Button();
            btnApproveRequest.BackColor = Color.FromArgb(34, 140, 60);
            btnApproveRequest.Cursor = Cursors.Hand;
            btnApproveRequest.FlatAppearance.BorderSize = 0;
            btnApproveRequest.FlatStyle = FlatStyle.Flat;
            btnApproveRequest.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            btnApproveRequest.ForeColor = Color.White;
            btnApproveRequest.Location = new Point(118, 8);
            btnApproveRequest.Name = "btnApproveRequest";
            btnApproveRequest.Size = new Size(130, 34);
            btnApproveRequest.TabIndex = 1;
            btnApproveRequest.Text = "Approve Upgrade";
            btnApproveRequest.UseVisualStyleBackColor = false;
            btnApproveRequest.Click += BtnApproveRequest_Click;
            //
            // btnDenyRequest
            //
            btnDenyRequest = new Button();
            btnDenyRequest.BackColor = Color.FromArgb(160, 40, 40);
            btnDenyRequest.Cursor = Cursors.Hand;
            btnDenyRequest.FlatAppearance.BorderSize = 0;
            btnDenyRequest.FlatStyle = FlatStyle.Flat;
            btnDenyRequest.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            btnDenyRequest.ForeColor = Color.White;
            btnDenyRequest.Location = new Point(258, 8);
            btnDenyRequest.Name = "btnDenyRequest";
            btnDenyRequest.Size = new Size(100, 34);
            btnDenyRequest.TabIndex = 2;
            btnDenyRequest.Text = "Deny";
            btnDenyRequest.UseVisualStyleBackColor = false;
            btnDenyRequest.Click += BtnDenyRequest_Click;
            //
            pnlRequestsToolbar.Controls.Add(btnRefreshRequests);
            pnlRequestsToolbar.Controls.Add(btnApproveRequest);
            pnlRequestsToolbar.Controls.Add(btnDenyRequest);
            //
            // lvRequests
            //
            lvRequests = new ListView();
            lvRequests.Dock = DockStyle.Fill;
            lvRequests.View = View.Details;
            lvRequests.FullRowSelect = true;
            lvRequests.GridLines = false;
            lvRequests.BackColor = Color.FromArgb(35, 35, 43);
            lvRequests.ForeColor = Color.FromArgb(220, 220, 230);
            lvRequests.Font = new Font("Consolas", 9F);
            lvRequests.Columns.Add("User ID", 60);
            lvRequests.Columns.Add("Username", 150);
            lvRequests.Columns.Add("Email", 200);
            lvRequests.Columns.Add("Request Date", 150);
            lvRequests.Columns.Add("Payment Method", 120);
            lvRequests.Columns.Add("Transaction ID", 200);
            lvRequests.SelectedIndexChanged += LvRequests_SelectedIndexChanged;
            //
            tabRequests.Controls.Add(pnlRequestsToolbar);
            tabRequests.Controls.Add(lvRequests);
            //
            // tabAudit
            //
            tabAudit = new TabPage();
            tabAudit.BackColor = Color.FromArgb(30, 30, 38);
            tabAudit.Text = "  Audit Logs  ";
            //
            // pnlAuditToolbar
            //
            pnlAuditToolbar = new Panel();
            pnlAuditToolbar.BackColor = Color.FromArgb(26, 26, 34);
            pnlAuditToolbar.Dock = DockStyle.Top;
            pnlAuditToolbar.Height = 50;
            pnlAuditToolbar.Padding = new Padding(8);
            //
            // btnRefreshAudit
            //
            btnRefreshAudit = new Button();
            btnRefreshAudit.BackColor = Color.FromArgb(60, 60, 70);
            btnRefreshAudit.Cursor = Cursors.Hand;
            btnRefreshAudit.FlatAppearance.BorderSize = 0;
            btnRefreshAudit.FlatStyle = FlatStyle.Flat;
            btnRefreshAudit.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            btnRefreshAudit.ForeColor = Color.White;
            btnRefreshAudit.Location = new Point(8, 8);
            btnRefreshAudit.Name = "btnRefreshAudit";
            btnRefreshAudit.Size = new Size(100, 34);
            btnRefreshAudit.TabIndex = 0;
            btnRefreshAudit.Text = "Refresh";
            btnRefreshAudit.UseVisualStyleBackColor = false;
            btnRefreshAudit.Click += BtnRefreshAudit_Click;
            //
            // btnExportAudit
            //
            btnExportAudit = new Button();
            btnExportAudit.BackColor = Color.FromArgb(40, 80, 140);
            btnExportAudit.Cursor = Cursors.Hand;
            btnExportAudit.FlatAppearance.BorderSize = 0;
            btnExportAudit.FlatStyle = FlatStyle.Flat;
            btnExportAudit.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            btnExportAudit.ForeColor = Color.White;
            btnExportAudit.Location = new Point(118, 8);
            btnExportAudit.Name = "btnExportAudit";
            btnExportAudit.Size = new Size(100, 34);
            btnExportAudit.TabIndex = 1;
            btnExportAudit.Text = "Export CSV";
            btnExportAudit.UseVisualStyleBackColor = false;
            btnExportAudit.Click += BtnExportAudit_Click;
            //
            // cmbAuditFilter
            //
            cmbAuditFilter = new ComboBox();
            cmbAuditFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAuditFilter.BackColor = Color.FromArgb(44, 44, 56);
            cmbAuditFilter.ForeColor = Color.FromArgb(220, 220, 230);
            cmbAuditFilter.Font = new Font("Nirmala UI", 9F);
            cmbAuditFilter.Location = new Point(240, 12);
            cmbAuditFilter.Name = "cmbAuditFilter";
            cmbAuditFilter.Size = new Size(150, 23);
            cmbAuditFilter.TabIndex = 2;
            cmbAuditFilter.Items.AddRange(new object[] { "All Actions", "LOGIN_SUCCESS", "LOGIN_FAILED", "UPGRADE_REQUEST", "UPGRADE_APPROVED", "SCAN_STARTED", "LOGOUT" });
            cmbAuditFilter.SelectedIndex = 0;
            cmbAuditFilter.SelectedIndexChanged += CmbAuditFilter_SelectedIndexChanged;
            //
            pnlAuditToolbar.Controls.Add(btnRefreshAudit);
            pnlAuditToolbar.Controls.Add(btnExportAudit);
            pnlAuditToolbar.Controls.Add(cmbAuditFilter);
            //
            // lvAudit
            //
            lvAudit = new ListView();
            lvAudit.Dock = DockStyle.Fill;
            lvAudit.View = View.Details;
            lvAudit.FullRowSelect = true;
            lvAudit.GridLines = false;
            lvAudit.BackColor = Color.FromArgb(35, 35, 43);
            lvAudit.ForeColor = Color.FromArgb(220, 220, 230);
            lvAudit.Font = new Font("Consolas", 9F);
            lvAudit.Columns.Add("ID", 50);
            lvAudit.Columns.Add("User ID", 60);
            lvAudit.Columns.Add("Username", 120);
            lvAudit.Columns.Add("Action", 150);
            lvAudit.Columns.Add("Target Type", 120);
            lvAudit.Columns.Add("Target ID", 100);
            lvAudit.Columns.Add("Details", 300);
            lvAudit.Columns.Add("Date", 150);
            //
            tabAudit.Controls.Add(pnlAuditToolbar);
            tabAudit.Controls.Add(lvAudit);
            //
            // tabStats
            //
            tabStats = new TabPage();
            tabStats.BackColor = Color.FromArgb(30, 30, 38);
            tabStats.Text = "  System Stats  ";
            //
            // rtbStats
            //
            rtbStats = new RichTextBox();
            rtbStats.Dock = DockStyle.Fill;
            rtbStats.BackColor = Color.FromArgb(18, 18, 22);
            rtbStats.ForeColor = Color.FromArgb(220, 220, 230);
            rtbStats.Font = new Font("Consolas", 10F);
            rtbStats.ReadOnly = true;
            rtbStats.ScrollBars = RichTextBoxScrollBars.Vertical;
            //
            // btnRefreshStats
            //
            btnRefreshStats = new Button();
            btnRefreshStats.BackColor = Color.FromArgb(34, 140, 60);
            btnRefreshStats.Cursor = Cursors.Hand;
            btnRefreshStats.FlatAppearance.BorderSize = 0;
            btnRefreshStats.FlatStyle = FlatStyle.Flat;
            btnRefreshStats.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            btnRefreshStats.ForeColor = Color.White;
            btnRefreshStats.Location = new Point(12, 8);
            btnRefreshStats.Name = "btnRefreshStats";
            btnRefreshStats.Size = new Size(100, 34);
            btnRefreshStats.TabIndex = 0;
            btnRefreshStats.Text = "Refresh";
            btnRefreshStats.UseVisualStyleBackColor = false;
            btnRefreshStats.Click += BtnRefreshStats_Click;
            //
            tabStats.Controls.Add(rtbStats);
            tabStats.Controls.Add(btnRefreshStats);
            //
            // Add tabs to tabControl
            //
            tabControl.Controls.Add(tabUsers);
            tabControl.Controls.Add(tabRequests);
            tabControl.Controls.Add(tabAudit);
            tabControl.Controls.Add(tabStats);
            //
            // btnLogout
            //
            btnLogout = new Button();
            btnLogout.BackColor = Color.FromArgb(160, 40, 40);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Nirmala UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(972, 700);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 35);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            //
            // btnClose
            //
            btnClose = new Label();
            btnClose.AutoSize = true;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Nirmala UI", 14F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(164, 165, 169);
            btnClose.Location = new Point(1050, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(29, 25);
            btnClose.TabIndex = 5;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            //
            // lblRoleBadge
            //
            lblRoleBadge = new Label();
            lblRoleBadge.AutoSize = true;
            lblRoleBadge.BackColor = Color.FromArgb(160, 40, 40);
            lblRoleBadge.Font = new Font("Nirmala UI", 9F, FontStyle.Bold);
            lblRoleBadge.ForeColor = Color.White;
            lblRoleBadge.Location = new Point(900, 25);
            lblRoleBadge.Name = "lblRoleBadge";
            lblRoleBadge.Padding = new Padding(8, 4, 8, 4);
            lblRoleBadge.Size = new Size(80, 23);
            lblRoleBadge.TabIndex = 6;
            lblRoleBadge.Text = "ADMIN";
            //
            // AdminForm
            //
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 38);
            ClientSize = new Size(1100, 750);
            Controls.Add(lblRoleBadge);
            Controls.Add(btnClose);
            Controls.Add(btnLogout);
            Controls.Add(tabControl);
            Controls.Add(lblWelcome);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1100, 750);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            Load += AdminForm_Load;

        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblWelcome;
        private TabControl tabControl;
        private TabPage tabUsers;
        private TabPage tabRequests;
        private TabPage tabAudit;
        private TabPage tabStats;
        private Panel pnlUsersToolbar;
        private Button btnRefreshUsers;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnToggleActive;
        private Label lblSearch;
        private TextBox txtSearch;
        private ListView lvUsers;
        private Panel pnlRequestsToolbar;
        private Button btnRefreshRequests;
        private Button btnApproveRequest;
        private Button btnDenyRequest;
        private ListView lvRequests;
        private Panel pnlAuditToolbar;
        private Button btnRefreshAudit;
        private Button btnExportAudit;
        private ComboBox cmbAuditFilter;
        private ListView lvAudit;
        private RichTextBox rtbStats;
        private Button btnRefreshStats;
        private Button btnLogout;
        private Label btnClose;
        private Label lblRoleBadge;
    }
}
