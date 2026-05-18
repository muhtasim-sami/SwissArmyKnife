namespace SwissArmyKnife
{
    public partial class CompareResultsForm : Form
    {
        private int userId;

        public CompareResultsForm(int userId)
        {
            this.userId = userId;
            InitializeComponent();
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            if (cboScan1.SelectedIndex == cboScan2.SelectedIndex)
            {
                MessageBox.Show("Please select two different scans to compare.", "Invalid Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Load actual scan data and compare
            rtbResults.Clear();
            rtbResults.AppendText("Comparison Report\n");
            rtbResults.AppendText(new string('=', 50) + "\n\n");
            rtbResults.AppendText($"Scan 1: {cboScan1.SelectedItem}\n");
            rtbResults.AppendText($"Scan 2: {cboScan2.SelectedItem}\n\n");
            rtbResults.AppendText("Differences detected:\n");
            rtbResults.AppendText("  - New hosts discovered: 2\n");
            rtbResults.AppendText("  - New open ports: 5\n");
            rtbResults.AppendText("  - Closed ports: 3\n");
            rtbResults.AppendText("  - Changed services: 2\n");
        }
    }
}

