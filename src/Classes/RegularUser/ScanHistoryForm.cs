using System;
using System.Drawing;
using System.Windows.Forms;

using DatabaseQueries = Database.DatabaseQueries;

namespace SwissArmyKnife
{
    public partial class ScanHistoryForm : Form
    {
        
        private int userId;
        private int daysLimit;

        public ScanHistoryForm(int userId, int daysLimit)
        {
            this.userId = userId;
            this.daysLimit = daysLimit;
            InitializeComponent();
            LoadHistory();
        }

        private void LoadHistory()
        {
            lvHistory.Items.Clear();

            // Get scans from database for last X days
            var scans = DatabaseQueries.GetUserScans(userId, daysLimit);

            foreach (var scan in scans)
            {
                ListViewItem item = new ListViewItem(scan.Type);
                item.SubItems.Add(scan.Target);
                item.SubItems.Add(scan.Mode ?? "Default");
                item.SubItems.Add(scan.StartTime?.ToString("yyyy-MM-dd HH:mm") ?? scan.CreatedAt.ToString("yyyy-MM-dd HH:mm"));

                // Calculate duration if available
                string duration = "";
                if (scan.StartTime.HasValue && scan.EndTime.HasValue)
                {
                    TimeSpan ts = scan.EndTime.Value - scan.StartTime.Value;
                    duration = $"{ts.TotalSeconds:F0} seconds";
                }
                else
                {
                    duration = "N/A";
                }
                item.SubItems.Add(duration);

                // Set status color
                if (scan.Status == "Completed")
                    item.ForeColor = Color.FromArgb(60, 180, 100);
                else if (scan.Status == "Error")
                    item.ForeColor = Color.FromArgb(210, 70, 70);
                else if (scan.Status == "Running")
                    item.ForeColor = Color.FromArgb(220, 170, 40);
                else
                    item.ForeColor = Color.FromArgb(220, 220, 230);

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
                lvHistory.Items.Add(emptyItem);
            }

        }

    }

}

/*
 
 
    public partial class ScanHistoryForm : Form
    {
        

        private void InitializeComponent()
        {
            }

        
    }
}


 
 */