using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SwissArmyKnife
{
    public partial class ViewerForm : Form
    {
        private string currentUsername;
        private int currentUserId;

        public ViewerForm()
        {
            InitializeComponent();
        }

        public ViewerForm(string username, int userId) : this()
        {
            currentUsername = username;
            currentUserId = userId;
        }

        private void WireEvents()
        {
            
        }

        private void ViewerForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {currentUsername}";
            LoadAssignedReports();
        }

        private void LoadAssignedReports()
        {
            lvReports.Items.Clear();

            // TODO: Load reports from database assigned to this viewer
            // For now, adding sample data

            ListViewItem item1 = new ListViewItem("Network Scan - Production");
            item1.SubItems.Add("Network Scanner");
            item1.SubItems.Add("192.168.1.0/24");
            item1.SubItems.Add("2024-01-15 14:30:00");
            item1.SubItems.Add("Completed");
            item1.Tag = "report_1.txt";
            lvReports.Items.Add(item1);

            ListViewItem item2 = new ListViewItem("Web Audit - Corporate Site");
            item2.SubItems.Add("Web Auditor");
            item2.SubItems.Add("https://example.com");
            item2.SubItems.Add("2024-01-14 10:15:00");
            item2.SubItems.Add("Completed");
            item2.Tag = "report_2.txt";
            lvReports.Items.Add(item2);

            ListViewItem item3 = new ListViewItem("TLS Inspection - API Server");
            item3.SubItems.Add("Web Auditor");
            item3.SubItems.Add("https://api.example.com");
            item3.SubItems.Add("2024-01-13 09:45:00");
            item3.SubItems.Add("Completed");
            item3.Tag = "report_3.txt";
            lvReports.Items.Add(item3);
        }

        private void LvReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hasSelection = lvReports.SelectedItems.Count > 0;
            btnViewReport.Enabled = hasSelection;
            btnExportPDF.Enabled = hasSelection;
        }

        private void LvReports_DoubleClick(object sender, EventArgs e)
        {
            if (lvReports.SelectedItems.Count > 0)
            {
                ViewSelectedReport();
            }
        }

        private void BtnViewReport_Click(object sender, EventArgs e)
        {
            ViewSelectedReport();
        }

        private void ViewSelectedReport()
        {
            if (lvReports.SelectedItems.Count == 0) return;

            ListViewItem selected = lvReports.SelectedItems[0];
            string reportName = selected.Text;
            string reportPath = selected.Tag?.ToString();

            if (string.IsNullOrEmpty(reportPath))
            {
                MessageBox.Show("Report file not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO: Load actual report content from file/database
            string reportContent = $"Report: {reportName}\n";
            reportContent += $"Generated: {selected.SubItems[3].Text}\n";
            reportContent += $"Target: {selected.SubItems[2].Text}\n";
            reportContent += new string('-', 50) + "\n\n";
            reportContent += "This is a sample report content.\n";
            reportContent += "Full report data would be loaded from the actual file.\n";

            ReportViewerForm viewer = new ReportViewerForm(reportName, reportContent);
            viewer.ShowDialog();
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            if (lvReports.SelectedItems.Count == 0) return;

            ListViewItem selected = lvReports.SelectedItems[0];
            string reportName = selected.Text;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Export Report as PDF";
            dlg.Filter = "PDF Files (*.pdf)|*.pdf";
            dlg.FileName = $"{reportName.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            // TODO: Generate actual PDF
            // For now, create a text file as placeholder
            string tempFile = Path.GetTempFileName() + ".txt";
            File.WriteAllText(tempFile, $"Report: {reportName}\nExported: {DateTime.Now}");

            MessageBox.Show($"Report exported to:\n{dlg.FileName}", "Export Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAssignedReports();
            SetStatus("Reports refreshed");
        }

        private void SetStatus(string msg)
        {
            // Status bar can be added later
            Console.WriteLine($"[{DateTime.Now}] {msg}");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

    }
}

