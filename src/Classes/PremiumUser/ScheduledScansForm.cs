using Database;

namespace SwissArmyKnife
{
    public partial class ScheduledScansForm : Form
    {
        private int userId;

        public ScheduledScansForm(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            LoadSchedules();
        }

        private void LoadSchedules()
        {
            lvSchedules.Items.Clear();
            var schedules = DatabaseQueries.GetUserScheduledScans(userId);

            foreach (var schedule in schedules)
            {
                ListViewItem item = new ListViewItem(schedule.Name);
                item.SubItems.Add("Network Scanner");
                item.SubItems.Add("Scheduled Target");
                item.SubItems.Add(schedule.CronExpression ?? "Daily");
                item.SubItems.Add(schedule.NextRun?.ToString("yyyy-MM-dd HH:mm") ?? "Not scheduled");
                item.SubItems.Add(schedule.Enabled ? "Active" : "Disabled");

                if (!schedule.Enabled)
                    item.ForeColor = Color.FromArgb(130, 130, 145);

                item.Tag = schedule.ScheduleId;
                lvSchedules.Items.Add(item);
            }

            if (schedules.Count == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No scheduled scans");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                lvSchedules.Items.Add(emptyItem);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // TODO: Open add schedule dialog
            MessageBox.Show("Schedule creation feature:\n\n" +
                "• Daily scans at specific time\n" +
                "• Weekly scans on selected days\n" +
                "• Monthly scans on specific date\n" +
                "• Custom cron expressions\n\n" +
                "Coming soon in next update.",
                "Add Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (lvSchedules.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a schedule to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Edit schedule feature coming soon.", "Edit Schedule",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lvSchedules.SelectedItems.Count == 0) return;

            DialogResult result = MessageBox.Show("Delete selected schedule?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int scheduleId = (int)lvSchedules.SelectedItems[0].Tag;
                DatabaseQueries.DeleteScheduledScan(scheduleId, userId);
                DatabaseQueries.LogAudit(userId, "DELETE_SCHEDULE", "ScheduledScan", scheduleId.ToString(), "Premium user deleted scheduled scan");
                LoadSchedules();
            }
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            if (lvSchedules.SelectedItems.Count == 0) return;

            MessageBox.Show("Toggle schedule status feature coming soon.", "Toggle Status",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

