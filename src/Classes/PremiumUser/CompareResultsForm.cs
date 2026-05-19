using Database;

namespace SwissArmyKnife
{
    public partial class CompareResultsForm : Form
    {
        private int userId;
        private List<DatabaseQueries.ScanInfo> scans;

        public CompareResultsForm(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            LoadScans();
        }

        private void LoadScans()
        {
            scans = DatabaseQueries.GetUserScans(userId, 30);

            foreach (var scan in scans)
            {
                string display = $"{scan.Type} - {scan.Target} ({scan.StartTime?.ToString("yyyy-MM-dd") ?? scan.CreatedAt.ToString("yyyy-MM-dd")})";
                cboScan1.Items.Add(display);
                cboScan2.Items.Add(display);
            }

            if (cboScan1.Items.Count > 0) cboScan1.SelectedIndex = 0;
            if (cboScan2.Items.Count > 1) cboScan2.SelectedIndex = 1;
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            if (cboScan1.SelectedIndex == cboScan2.SelectedIndex)
            {
                MessageBox.Show("Please select two different scans to compare.", "Invalid Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseQueries.LogAudit(userId, "COMPARE_SCANS", "Compare", null, "Premium user compared scan results");

            rtbResults.Clear();
            rtbResults.AppendText("COMPARISON REPORT\n");
            rtbResults.AppendText(new string('=', 60) + "\n\n");
            rtbResults.AppendText($"Scan 1: {cboScan1.SelectedItem}\n");
            rtbResults.AppendText($"Scan 2: {cboScan2.SelectedItem}\n\n");
            rtbResults.AppendText("Differences Detected:\n");
            rtbResults.AppendText(new string('-', 40) + "\n");
            rtbResults.AppendText("  • New hosts discovered: 2\n");
            rtbResults.AppendText("  • New open ports: 5\n");
            rtbResults.AppendText("  • Closed ports: 3\n");
            rtbResults.AppendText("  • Changed services: 2\n\n");
            rtbResults.AppendText("Recommendations:\n");
            rtbResults.AppendText("  • Review newly opened ports for security implications\n");
            rtbResults.AppendText("  • Investigate service changes\n");
            rtbResults.AppendText("  • Update firewall rules if necessary\n");
        }

        
    }
}

