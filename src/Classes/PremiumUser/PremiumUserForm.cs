using System;
using System.Drawing;
using System.Windows.Forms;


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
            // TODO: Load actual scan statistics from database
            // For now, using sample data

            int totalScans = 247;
            int thisMonthScans = 42;
            int lastMonthScans = 38;

            lblTotalScans.Text = $"Total scans: {totalScans}";
            lblThisMonth.Text = $"This month: {thisMonthScans} scans";
            lblLastMonth.Text = $"Last month: {lastMonthScans} scans";
        }

        private void BtnNetworkScanner_Click(object sender, EventArgs e)
        {
            // Full Network Scanner with all features for Premium User
            NetworkScannerForm scanner = new NetworkScannerForm();

            // Premium features available:
            // - Unlimited hosts
            // - All port options (Top100, Top1000, Full 1-65535, Custom)
            // - CSV, TXT export
            // - Save configurations

            scanner.ShowDialog();
        }

        private void BtnWebAuditor_Click(object sender, EventArgs e)
        {
            // Full Web Security Auditor for Premium User
            WebSecurityAuditForm auditor = new WebSecurityAuditForm();

            // Premium features available:
            // - All tabs (Headers, TLS, Response, Tech Fingerprinter)
            // - Full TLS inspection
            // - Technology fingerprinting
            // - Export capabilities

            auditor.ShowDialog();
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
/*
 
    
    
 
 */