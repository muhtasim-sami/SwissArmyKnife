using Database;

namespace SwissArmyKnife
{
    public partial class FullScanHistoryForm : Form
    {
        private int userId;

        public FullScanHistoryForm(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            LoadHistory();
        }

        private void LoadHistory()
        {
            lvHistory.Items.Clear();
            string filter = cboFilter.SelectedItem.ToString();

            var scans = DatabaseQueries.GetUserScans(userId, 0);

            foreach (var scan in scans)
            {
                // Apply filter
                if (filter != "All" && scan.Type != filter) continue;

                // Apply date filter
                if (scan.StartTime.HasValue)
                {
                    if (scan.StartTime.Value.Date < dtpStart.Value.Date ||
                        scan.StartTime.Value.Date > dtpEnd.Value.Date)
                        continue;
                }

                ListViewItem item = new ListViewItem(scan.Type);
                item.SubItems.Add(scan.Target);
                item.SubItems.Add(scan.Mode ?? "Default");
                item.SubItems.Add(scan.StartTime?.ToString("yyyy-MM-dd HH:mm") ?? scan.CreatedAt.ToString("yyyy-MM-dd HH:mm"));

                string duration = "";
                if (scan.StartTime.HasValue && scan.EndTime.HasValue)
                {
                    TimeSpan ts = scan.EndTime.Value - scan.StartTime.Value;
                    duration = $"{ts.TotalSeconds:F0} sec";
                }
                else
                {
                    duration = "N/A";
                }
                item.SubItems.Add(duration);
                item.SubItems.Add("N/A");
                item.SubItems.Add("N/A");

                if (scan.Status == "Completed")
                    item.ForeColor = Color.FromArgb(60, 180, 100);
                else if (scan.Status == "Error")
                    item.ForeColor = Color.FromArgb(210, 70, 70);
                else if (scan.Status == "Running")
                    item.ForeColor = Color.FromArgb(220, 170, 40);

                item.SubItems.Add(scan.Status);
                lvHistory.Items.Add(item);
            }

            if (scans.Count == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No scans found");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                lvHistory.Items.Add(emptyItem);
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Export Scan History";
            dlg.Filter = "CSV Files (*.csv)|*.csv";
            dlg.FileName = $"scan_history_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(dlg.FileName);
                writer.WriteLine("Scan Type,Target,Mode,Date,Duration,Status");

                foreach (ListViewItem item in lvHistory.Items)
                {
                    writer.WriteLine($"\"{item.Text}\",\"{item.SubItems[1].Text}\",\"{item.SubItems[2].Text}\",\"{item.SubItems[3].Text}\",\"{item.SubItems[4].Text}\",\"{item.SubItems[7].Text}\"");
                }

                writer.Close();
                DatabaseQueries.LogAudit(userId, "EXPORT_HISTORY", "ScanHistory", null, "Premium user exported scan history to CSV");
                MessageBox.Show($"Exported to:\n{dlg.FileName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
