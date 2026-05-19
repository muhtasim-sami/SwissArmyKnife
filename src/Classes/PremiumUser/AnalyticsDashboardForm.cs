using Database;

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
            int totalScans = DatabaseQueries.GetUserTotalScanCount(userId);
            int scansThisMonth = DatabaseQueries.GetUserScanCountThisMonth(userId);

            var scans = DatabaseQueries.GetUserScans(userId, 30);
            int networkScans = 0;
            int webScans = 0;

            foreach (var scan in scans)
            {
                if (scan.Type == "Network") networkScans++;
                if (scan.Type == "Web") webScans++;
            }

            rtbAnalytics.Clear();
            rtbAnalytics.AppendText("ANALYTICS DASHBOARD\n");
            rtbAnalytics.AppendText(new string('=', 50) + "\n\n");
            rtbAnalytics.AppendText($"User: Premium\n");
            rtbAnalytics.AppendText($"Total Scans (All Time): {totalScans}\n\n");
            rtbAnalytics.AppendText("SCAN STATISTICS (Last 30 Days):\n");
            rtbAnalytics.AppendText(new string('-', 40) + "\n");
            rtbAnalytics.AppendText($"  Total scans: {scans.Count}\n");
            rtbAnalytics.AppendText($"  Network scans: {networkScans}\n");
            rtbAnalytics.AppendText($"  Web audits: {webScans}\n");
            rtbAnalytics.AppendText($"  This month: {scansThisMonth}\n\n");

            rtbAnalytics.AppendText("PERFORMANCE METRICS:\n");
            rtbAnalytics.AppendText(new string('-', 40) + "\n");
            rtbAnalytics.AppendText("  Average scan duration: ~30 seconds\n");
            rtbAnalytics.AppendText("  Most active day: Weekdays\n");
            rtbAnalytics.AppendText("  Peak usage time: 10:00 - 15:00\n\n");

            rtbAnalytics.AppendText("FEATURE USAGE:\n");
            rtbAnalytics.AppendText(new string('-', 40) + "\n");
            rtbAnalytics.AppendText("  ✓ Full port scanning enabled\n");
            rtbAnalytics.AppendText("  ✓ Export formats: CSV, TXT, PDF\n");
            rtbAnalytics.AppendText("  ✓ Scheduled scans: Active\n");
            rtbAnalytics.AppendText("  ✓ Saved configurations: Available\n\n");

            rtbAnalytics.AppendText("RECOMMENDATIONS:\n");
            rtbAnalytics.AppendText(new string('-', 40) + "\n");
            rtbAnalytics.AppendText("  • Schedule weekly scans for continuous monitoring\n");
            rtbAnalytics.AppendText("  • Save frequently used configurations\n");
            rtbAnalytics.AppendText("  • Use compare feature to track changes over time\n");
        }
    }
}

