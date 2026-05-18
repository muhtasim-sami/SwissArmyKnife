using System;
using System.Drawing;
using System.Windows.Forms;


namespace SwissArmyKnife
{
    public partial class RegularUserForm : Form
    {
        private string currentUsername = "";
        private int currentUserId = 0;
        private int scansToday = 0;
        private int totalScansThisMonth = 0;
        private const int MAX_SCANS_PER_DAY = 5;
        public RegularUserForm()
        {
            InitializeComponent();
        }


        public RegularUserForm(string username, int userId) : this()
        {
            currentUsername = username;
            currentUserId = userId;
        }

        private void WireEvents()
        {
            // Events are wired in Designer
        }

        private void RegularUserForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {currentUsername}";
            LoadUserStats();
        }

        private void LoadUserStats()
        {
            // TODO: Load actual scan counts from database
            // For now, using sample data
            scansToday = 2;
            totalScansThisMonth = 15;

            int remainingScans = MAX_SCANS_PER_DAY - scansToday;
            remainingScans = remainingScans < 0 ? 0 : remainingScans;

            lblScansToday.Text = $"Scans today: {scansToday} / {MAX_SCANS_PER_DAY}";
            lblRemaining.Text = $"Scans remaining today: {remainingScans}";
            lblTotalScans.Text = $"Total scans this month: {totalScansThisMonth}";
        }

        private void BtnNetworkScanner_Click(object sender, EventArgs e)
        {
            if (scansToday >= MAX_SCANS_PER_DAY)
            {
                MessageBox.Show($"You have reached your daily scan limit of {MAX_SCANS_PER_DAY}.\nUpgrade to Premium for unlimited scans.",
                    "Daily Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show limited Network Scanner for Regular User
            NetworkScannerForm scanner = new NetworkScannerForm();

            // Apply regular user restrictions
            // TODO: Pass user role to restrict features
            // - Limit to 10 hosts
            // - Only Top 100 ports
            // - TXT export only

            scanner.ShowDialog();

            // Increment scan count after scan completes
            scansToday++;
            LoadUserStats();
        }

        private void BtnWebAuditor_Click(object sender, EventArgs e)
        {
            if (scansToday >= MAX_SCANS_PER_DAY)
            {
                MessageBox.Show($"You have reached your daily scan limit of {MAX_SCANS_PER_DAY}.\nUpgrade to Premium for unlimited scans.",
                    "Daily Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show limited Web Security Auditor for Regular User
            WebSecurityAuditForm auditor = new WebSecurityAuditForm();

            // Apply regular user restrictions
            // TODO: Pass user role to restrict features
            // - Basic header checks only
            // - No advanced TLS inspection
            // - No tech fingerprinting

            auditor.ShowDialog();

            scansToday++;
            LoadUserStats();
        }

        private void BtnScanHistory_Click(object sender, EventArgs e)
        {
            // Show scan history for last 7 days only
            ScanHistoryForm history = new ScanHistoryForm(currentUserId, 7);
            history.ShowDialog();
        }

        private void BtnUpgrade_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Upgrade to Premium User to get:\n\n" +
                "✓ Unlimited scans\n" +
                "✓ Unlimited hosts per scan\n" +
                "✓ Full port scanning (1-65535)\n" +
                "✓ CSV and PDF export\n" +
                "✓ Save scan configurations\n" +
                "✓ Schedule recurring scans\n" +
                "✓ Compare scan results\n\n" +
                "Would you like to proceed?",
                "Upgrade to Premium",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // TODO: Open payment/upgrade page
                MessageBox.Show("Upgrade feature coming soon.\nContact administrator for premium access.",
                    "Upgrade", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm frmLogin = new LoginForm();
                frmLogin.Show();
                this.Close();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }

    // Simple Scan History Form for Regular Users
    public partial class ScanHistoryForm : Form
    {
        private ListView lvHistory;
        private Button btnClose;
        private int userId;
        private int daysLimit;

        public ScanHistoryForm(int userId, int daysLimit)
        {
            this.userId = userId;
            this.daysLimit = daysLimit;
            InitializeComponent();
            LoadHistory();
        }

        private void InitializeComponent()
        {
            this.Text = $"Scan History (Last {daysLimit} Days)";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 38);

            lvHistory = new ListView();
            lvHistory.Dock = DockStyle.Top;
            lvHistory.Height = 380;
            lvHistory.View = View.Details;
            lvHistory.FullRowSelect = true;
            lvHistory.BackColor = Color.FromArgb(35, 35, 43);
            lvHistory.ForeColor = Color.FromArgb(220, 220, 230);
            lvHistory.Columns.Add("Scan Type", 150);
            lvHistory.Columns.Add("Target", 200);
            lvHistory.Columns.Add("Date", 150);
            lvHistory.Columns.Add("Duration", 100);
            lvHistory.Columns.Add("Status", 100);

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.BackColor = Color.FromArgb(60, 60, 70);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(350, 410);
            btnClose.Click += (s, e) => Close();

            Controls.Add(btnClose);
            Controls.Add(lvHistory);
        }

        private void LoadHistory()
        {
            lvHistory.Items.Clear();

            // TODO: Load actual scan history from database for this user
            // For now, adding sample data

            ListViewItem item1 = new ListViewItem("Network Scan");
            item1.SubItems.Add("192.168.1.0/24");
            item1.SubItems.Add(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm"));
            item1.SubItems.Add("45 seconds");
            item1.SubItems.Add("Completed");
            lvHistory.Items.Add(item1);

            ListViewItem item2 = new ListViewItem("Web Audit");
            item2.SubItems.Add("https://example.com");
            item2.SubItems.Add(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm"));
            item2.SubItems.Add("12 seconds");
            item2.SubItems.Add("Completed");
            lvHistory.Items.Add(item2);

            ListViewItem item3 = new ListViewItem("Network Scan");
            item3.SubItems.Add("10.0.0.1");
            item3.SubItems.Add(DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd HH:mm"));
            item3.SubItems.Add("8 seconds");
            item3.SubItems.Add("Completed");
            lvHistory.Items.Add(item3);
        }

    }
}

