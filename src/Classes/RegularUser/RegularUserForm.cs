using System;
using System.Drawing;
using System.Windows.Forms;

using DatabaseQueries = Database.DatabaseQueries;

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
            scansToday = DatabaseQueries.GetUserScanCountToday(currentUserId);
            int totalScans = DatabaseQueries.GetUserTotalScanCount(currentUserId);
            int scansThisMonth = DatabaseQueries.GetUserScanCountThisMonth(currentUserId);

            int remainingScans = MAX_SCANS_PER_DAY - scansToday;
            remainingScans = remainingScans < 0 ? 0 : remainingScans;

            lblScansToday.Text = $"Scans today: {scansToday} / {MAX_SCANS_PER_DAY}";
            lblRemaining.Text = $"Scans remaining today: {remainingScans}";
            lblTotalScans.Text = $"Total scans this month: {totalScansThisMonth}";

            if (scansToday >= MAX_SCANS_PER_DAY)
            {
                lblScansToday.ForeColor = Color.FromArgb(210, 70, 70);
                lblRemaining.ForeColor = Color.FromArgb(210, 70, 70);
            }
            else if (scansToday >= MAX_SCANS_PER_DAY - 2)
            {
                lblScansToday.ForeColor = Color.FromArgb(220, 170, 40);
                lblRemaining.ForeColor = Color.FromArgb(220, 170, 40);
            }
            else
            {
                lblScansToday.ForeColor = Color.FromArgb(220, 220, 230);
                lblRemaining.ForeColor = Color.FromArgb(220, 220, 230);
            }


        }

        private bool CanPerformScan()
        {
            if (scansToday >= MAX_SCANS_PER_DAY)
            {
                MessageBox.Show($"You have reached your daily scan limit of {MAX_SCANS_PER_DAY}.\n\nUpgrade to Premium for unlimited scans.",
                    "Daily Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnNetworkScanner_Click(object sender, EventArgs e)
        {
            if (!CanPerformScan()) return;

            // Show limited Network Scanner for Regular User
            NetworkScannerForm scanner = new NetworkScannerForm();
            scanner.ShowDialog();

            // Log the scan and update stats
            int scanId = DatabaseQueries.InsertScan(currentUserId, "Network", "Manual Scan", "Basic", null, "Completed");
            DatabaseQueries.LogAudit(currentUserId, "SCAN_STARTED", "Network", scanId.ToString(), "Regular user started network scan");

            LoadUserStats();
        }

        private void BtnWebAuditor_Click(object sender, EventArgs e)
        {
            if (!CanPerformScan()) return;

            // Show limited Web Security Auditor for Regular User
            WebSecurityAuditForm auditor = new WebSecurityAuditForm();
            auditor.ShowDialog();

            // Log the scan and update stats
            int scanId = DatabaseQueries.InsertScan(currentUserId, "Web", "Web Audit", "Basic", null, "Completed");
            DatabaseQueries.LogAudit(currentUserId, "SCAN_STARTED", "Web", scanId.ToString(), "Regular user started web audit");

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
                DatabaseQueries.LogAudit(currentUserId, "UPGRADE_INTEREST", "Subscription", null, "Regular user showed interest in Premium upgrade");

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
                DatabaseQueries.LogAudit(currentUserId, "LOGOUT", "User", currentUserId.ToString(), $"User {currentUsername} logged out");

                //LoginForm frmLogin = new LoginForm();
                //frmLogin.Show();
                this.Close();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DatabaseQueries.LogAudit(currentUserId, "APPLICATION_EXIT", "User", currentUserId.ToString(), $"User {currentUsername} exited application");

                Application.Exit();
            }
        }
    }
}    