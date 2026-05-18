namespace SwissArmyKnife
{
    public partial class AnalyticsDashboardForm : Form
    {
        private int userId;
        public AnalyticsDashboardForm(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            LoadAnalytics();
        }

        private void LoadAnalytics()
        {
            rtbAnalytics.Clear();
            rtbAnalytics.AppendText("ANALYTICS DASHBOARD\n");
            rtbAnalytics.AppendText(new string('=', 50) + "\n\n");
            rtbAnalytics.AppendText("Scan Statistics (Last 30 Days):\n");
            rtbAnalytics.AppendText($"  Total scans: 42\n");
            rtbAnalytics.AppendText($"  Network scans: 28\n");
            rtbAnalytics.AppendText($"  Web audits: 14\n\n");
            rtbAnalytics.AppendText("Hosts Discovered:\n");
            rtbAnalytics.AppendText($"  Total unique hosts: 156\n");
            rtbAnalytics.AppendText($"  New this month: 23\n\n");
            rtbAnalytics.AppendText("Open Ports Statistics:\n");
            rtbAnalytics.AppendText($"  Most common port: 443 (HTTPS) - 89 hosts\n");
            rtbAnalytics.AppendText($"  Second most common: 80 (HTTP) - 76 hosts\n");
            rtbAnalytics.AppendText($"  Third most common: 22 (SSH) - 45 hosts\n\n");
            rtbAnalytics.AppendText("Vulnerability Summary:\n");
            rtbAnalytics.AppendText($"  Missing security headers: 67 findings\n");
            rtbAnalytics.AppendText($"  Weak TLS configurations: 12 findings\n");
            rtbAnalytics.AppendText($"  Information disclosure: 8 findings\n");
        }
    }
}

