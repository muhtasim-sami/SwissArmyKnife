using System;
using System.Drawing;
using System.Windows.Forms;

using DatabaseQueries = Database.DatabaseQueries;

namespace SwissArmyKnife
{
    public partial class PremiumUserForm : Form
    {
        private string currentUsername = "";
        private int currentUserId = 0;
        public PremiumUserForm()
        {
            InitializeComponent();
        }


        public PremiumUserForm(string username, int userId) : this()
        {
            currentUsername = username;
            currentUserId = userId;
        }

        

        private void PremiumUserForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {currentUsername}";
            LoadUserStats();
        }

        private void LoadUserStats()
        {

            int totalScans = DatabaseQueries.GetUserTotalScanCount(currentUserId);
            int scansThisMonth = DatabaseQueries.GetUserScanCountThisMonth(currentUserId);

            // Get last month's scans
            DateTime firstDayLastMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            DateTime lastDayLastMonth = firstDayLastMonth.AddMonths(1).AddDays(-1);
            int scansLastMonth = DatabaseQueries.GetUserScanCountByDateRange(currentUserId, firstDayLastMonth, lastDayLastMonth);

            lblTotalScans.Text = $"Total scans: {totalScans}";
            lblThisMonth.Text = $"This month: {scansThisMonth} scans";
            lblLastMonth.Text = $"Last month: {scansLastMonth} scans";

            // Calculate trend
            if (scansLastMonth > 0)
            {
                int trend = scansThisMonth - scansLastMonth;
                if (trend > 0)
                    lblThisMonth.Text += $" (↑ +{trend})";
                else if (trend < 0)
                    lblThisMonth.Text += $" (↓ {trend})";
            }

        }

        private void BtnNetworkScanner_Click(object sender, EventArgs e)
        {
            NetworkScannerForm scanner = new NetworkScannerForm();

            scanner.ShowDialog();

            // Log the scan
            int scanId = DatabaseQueries.InsertScan(currentUserId, "Network", "Manual Scan", "Full", null, "Completed");
            DatabaseQueries.LogAudit(currentUserId, "SCAN_STARTED", "Network", scanId.ToString(), "Premium user started full network scan");

            LoadUserStats();
        }

        private void BtnWebAuditor_Click(object sender, EventArgs e)
        {
            WebSecurityAuditForm auditor = new WebSecurityAuditForm();

            auditor.ShowDialog();

            // Log the scan
            int scanId = DatabaseQueries.InsertScan(currentUserId, "Web", "Web Audit", "Full", null, "Completed");
            DatabaseQueries.LogAudit(currentUserId, "SCAN_STARTED", "Web", scanId.ToString(), "Premium user started full web audit");

            LoadUserStats();
        }

        private void BtnSavedConfigs_Click(object sender, EventArgs e)
        {
            SavedConfigsForm configs = new SavedConfigsForm(currentUserId);
            configs.ShowDialog();
        }

        private void BtnSchedule_Click(object sender, EventArgs e)
        {
            ScheduledScansForm scheduled = new ScheduledScansForm(currentUserId);
            scheduled.ShowDialog();
        }

        private void BtnScanHistory_Click(object sender, EventArgs e)
        {
            // Full scan history (unlimited days)
            FullScanHistoryForm history = new FullScanHistoryForm(currentUserId);
            history.ShowDialog();
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            CompareResultsForm compare = new CompareResultsForm(currentUserId);
            compare.ShowDialog();
        }

        private void BtnAnalytics_Click(object sender, EventArgs e)
        {
            AnalyticsDashboardForm analytics = new AnalyticsDashboardForm(currentUserId);
            analytics.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
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
}
