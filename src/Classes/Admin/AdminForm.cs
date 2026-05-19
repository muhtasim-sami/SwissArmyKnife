using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Database;

namespace SwissArmyKnife
{
    public partial class AdminForm : Form
    {
        
        private string currentUsername;
        private int currentUserId;
        private List<DatabaseQueries.UserManagementInfo> allUsers;

        public AdminForm()
        {
            InitializeComponent();
        }

        public AdminForm(string username, int userId) : this()
        {
            currentUsername = username;
            currentUserId = userId;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {currentUsername}";
            DatabaseQueries.LogAudit(currentUserId, "ADMIN_LOGIN", "Admin", currentUserId.ToString(), $"Admin {currentUsername} logged in");
            LoadUsers();
            LoadUpgradeRequests();
            LoadAuditLogs();
            LoadSystemStats();
        }

        #region User Management

        private void LoadUsers()
        {
            allUsers = DatabaseQueries.GetAllUsers();
            DisplayUsers(allUsers);
        }

        private void DisplayUsers(List<DatabaseQueries.UserManagementInfo> users)
        {
            lvUsers.Items.Clear();

            foreach (var user in users)
            {
                ListViewItem item = new ListViewItem(user.UserId.ToString());
                item.SubItems.Add(user.Username);
                item.SubItems.Add(user.Email ?? "-");
                item.SubItems.Add(user.Role);
                item.SubItems.Add(user.IsActive ? "Active" : "Inactive");
                item.SubItems.Add(user.CreatedAt.ToString("yyyy-MM-dd HH:mm"));
                item.SubItems.Add(user.LastLogin?.ToString("yyyy-MM-dd HH:mm") ?? "Never");

                if (!user.IsActive)
                    item.ForeColor = Color.FromArgb(130, 130, 145);
                else if (user.Role == "Admin")
                    item.ForeColor = Color.FromArgb(220, 170, 40);
                else if (user.Role == "PremiumUser")
                    item.ForeColor = Color.FromArgb(60, 180, 100);
                else
                    item.ForeColor = Color.FromArgb(220, 220, 230);

                item.Tag = user;
                lvUsers.Items.Add(item);
            }

            if (users.Count == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No users found");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                lvUsers.Items.Add(emptyItem);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                DisplayUsers(allUsers);
            }
            else
            {
                var filtered = allUsers.FindAll(u =>
                    u.Username.ToLower().Contains(searchText) ||
                    (u.Email != null && u.Email.ToLower().Contains(searchText)));
                DisplayUsers(filtered);
            }
        }

        private void LvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hasSelection = lvUsers.SelectedItems.Count > 0;
            btnEditUser.Enabled = hasSelection;
            btnDeleteUser.Enabled = hasSelection;
            btnToggleActive.Enabled = hasSelection;
        }

        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0) return;

            DatabaseQueries.UserManagementInfo user = (DatabaseQueries.UserManagementInfo)lvUsers.SelectedItems[0].Tag;
            EditUserForm editForm = new EditUserForm(user, currentUserId);
            editForm.ShowDialog();
            LoadUsers();
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0) return;

            DatabaseQueries.UserManagementInfo user = (DatabaseQueries.UserManagementInfo)lvUsers.SelectedItems[0].Tag;

            if (user.UserId == currentUserId)
            {
                MessageBox.Show("You cannot delete your own account.", "Cannot Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Delete user '{user.Username}'?\n\nThis action cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DatabaseQueries.DeleteUser(user.UserId);
                DatabaseQueries.LogAudit(currentUserId, "DELETE_USER", "User", user.UserId.ToString(), $"Admin deleted user {user.Username}");
                LoadUsers();
                LoadUpgradeRequests();
            }
        }

        private void BtnToggleActive_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0) return;

            DatabaseQueries.UserManagementInfo user = (DatabaseQueries.UserManagementInfo)lvUsers.SelectedItems[0].Tag;

            if (user.UserId == currentUserId)
            {
                MessageBox.Show("You cannot deactivate your own account.", "Cannot Deactivate",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool newStatus = !user.IsActive;
            string action = newStatus ? "activated" : "deactivated";

            DialogResult result = MessageBox.Show($"{action.ToUpper()} user '{user.Username}'?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DatabaseQueries.UpdateUserStatus(user.UserId, newStatus);
                DatabaseQueries.LogAudit(currentUserId, "TOGGLE_USER_STATUS", "User", user.UserId.ToString(),
                    $"Admin {action} user {user.Username}");
                LoadUsers();
            }
        }

        private void BtnRefreshUsers_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        #endregion

        #region Upgrade Requests

        private void LoadUpgradeRequests()
        {
            var requests = DatabaseQueries.GetUpgradeRequests();

            lvRequests.Items.Clear();

            foreach (var request in requests)
            {
                ListViewItem item = new ListViewItem(request.UserId.ToString());
                item.SubItems.Add(request.Username);
                item.SubItems.Add(request.Email ?? "-");
                item.SubItems.Add(request.RequestDate.ToString("yyyy-MM-dd HH:mm"));
                item.SubItems.Add(request.PaymentMethod ?? "Demo");
                item.SubItems.Add(request.TransactionId);
                item.Tag = request;
                lvRequests.Items.Add(item);
            }

            if (requests.Count == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No pending upgrade requests");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                lvRequests.Items.Add(emptyItem);
            }
        }

        private void LvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hasSelection = lvRequests.SelectedItems.Count > 0 && lvRequests.SelectedItems[0].Tag is DatabaseQueries.UpgradeRequest;
            btnApproveRequest.Enabled = hasSelection;
            btnDenyRequest.Enabled = hasSelection;
        }

        private void BtnApproveRequest_Click(object sender, EventArgs e)
        {
            if (lvRequests.SelectedItems.Count == 0) return;

            DatabaseQueries.UpgradeRequest request = (DatabaseQueries.UpgradeRequest)lvRequests.SelectedItems[0].Tag;

            DialogResult result = MessageBox.Show($"Approve premium upgrade for '{request.Username}'?",
                "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = DatabaseQueries.ApprovePremiumUpgrade(request.UserId, currentUserId);

                if (success)
                {
                    MessageBox.Show($"User '{request.Username}' has been upgraded to Premium!",
                        "Upgrade Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    LoadUpgradeRequests();
                }
                else
                {
                    MessageBox.Show("Failed to approve upgrade.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDenyRequest_Click(object sender, EventArgs e)
        {
            if (lvRequests.SelectedItems.Count == 0) return;

            DatabaseQueries.UpgradeRequest request = (DatabaseQueries.UpgradeRequest)lvRequests.SelectedItems[0].Tag;

            DialogResult result = MessageBox.Show($"Deny upgrade request for '{request.Username}'?",
                "Confirm Denial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DatabaseQueries.LogAudit(currentUserId, "UPGRADE_DENIED", "User", request.UserId.ToString(),
                    $"Admin denied premium upgrade for {request.Username}");
                LoadUpgradeRequests();
            }
        }

        private void BtnRefreshRequests_Click(object sender, EventArgs e)
        {
            LoadUpgradeRequests();
        }

        #endregion

        #region Audit Logs

        private void LoadAuditLogs()
        {
            var logs = DatabaseQueries.GetAuditLogs(500);
            DisplayAuditLogs(logs);
        }

        private void DisplayAuditLogs(List<DatabaseQueries.AuditEntry> logs)
        {
            lvAudit.Items.Clear();

            string filter = cmbAuditFilter.SelectedItem?.ToString();

            foreach (var log in logs)
            {
                if (filter != "All Actions" && log.Action != filter)
                    continue;

                ListViewItem item = new ListViewItem(log.AuditId.ToString());
                item.SubItems.Add(log.UserId?.ToString() ?? "-");
                item.SubItems.Add(log.Username ?? "System");
                item.SubItems.Add(log.Action);
                item.SubItems.Add(log.TargetType ?? "-");
                item.SubItems.Add(log.TargetId ?? "-");
                item.SubItems.Add(log.Details ?? "-");
                item.SubItems.Add(log.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                lvAudit.Items.Add(item);
            }

            if (logs.Count == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No audit logs found");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                lvAudit.Items.Add(emptyItem);
            }
        }

        private void CmbAuditFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAuditLogs();
        }

        private void BtnRefreshAudit_Click(object sender, EventArgs e)
        {
            LoadAuditLogs();
        }

        private void BtnExportAudit_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Export Audit Logs";
            dlg.Filter = "CSV Files (*.csv)|*.csv";
            dlg.FileName = $"audit_logs_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ID,User ID,Username,Action,Target Type,Target ID,Details,Date");

                foreach (ListViewItem item in lvAudit.Items)
                {
                    sb.AppendLine($"\"{item.Text}\",\"{item.SubItems[1].Text}\",\"{item.SubItems[2].Text}\",\"{item.SubItems[3].Text}\",\"{item.SubItems[4].Text}\",\"{item.SubItems[5].Text}\",\"{item.SubItems[6].Text}\",\"{item.SubItems[7].Text}\"");
                }

                File.WriteAllText(dlg.FileName, sb.ToString());
                DatabaseQueries.LogAudit(currentUserId, "EXPORT_AUDIT", "Admin", null, "Admin exported audit logs");
                MessageBox.Show($"Exported to:\n{dlg.FileName}", "Export Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region System Statistics

        private void LoadSystemStats()
        {
            var stats = DatabaseQueries.GetSystemStatistics();
            var users = DatabaseQueries.GetAllUsers();

            int totalUsers = users.Count;
            int activeUsers = 0;
            int premiumUsers = 0;
            int regularUsers = 0;
            int adminUsers = 0;

            foreach (var user in users)
            {
                if (user.IsActive) activeUsers++;
                if (user.Role == "PremiumUser") premiumUsers++;
                if (user.Role == "RegularUser") regularUsers++;
                if (user.Role == "Admin") adminUsers++;
            }

            rtbStats.Clear();
            rtbStats.AppendText("SYSTEM STATISTICS\n");
            rtbStats.AppendText(new string('=', 50) + "\n\n");

            rtbStats.AppendText("USER STATISTICS:\n");
            rtbStats.AppendText(new string('-', 30) + "\n");
            rtbStats.AppendText($"  Total Users:     {totalUsers}\n");
            rtbStats.AppendText($"  Active Users:    {activeUsers}\n");
            rtbStats.AppendText($"  Inactive Users:  {totalUsers - activeUsers}\n\n");

            rtbStats.AppendText("  Admin:           {adminUsers}\n");
            rtbStats.AppendText($"  Premium Users:   {premiumUsers}\n");
            rtbStats.AppendText($"  Regular Users:   {regularUsers}\n\n");

            rtbStats.AppendText("SCAN STATISTICS:\n");
            rtbStats.AppendText(new string('-', 30) + "\n");
            rtbStats.AppendText($"  Total Scans:           {stats["TotalScans"]}\n");
            rtbStats.AppendText($"  Scans (Last 30 Days):  {stats["ScansLast30Days"]}\n\n");

            rtbStats.AppendText("FINDINGS STATISTICS:\n");
            rtbStats.AppendText(new string('-', 30) + "\n");
            rtbStats.AppendText($"  High Severity:   {stats["HighFindings"]}\n");
            rtbStats.AppendText($"  Medium Severity: {stats["MediumFindings"]}\n");
            rtbStats.AppendText($"  Low Severity:    {stats["LowFindings"]}\n");
        }

        private void BtnRefreshStats_Click(object sender, EventArgs e)
        {
            LoadSystemStats();
        }

        #endregion

        #region Logout and Close

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DatabaseQueries.LogAudit(currentUserId, "LOGOUT", "Admin", currentUserId.ToString(),
                    $"Admin {currentUsername} logged out");

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
                DatabaseQueries.LogAudit(currentUserId, "APPLICATION_EXIT", "Admin", currentUserId.ToString(),
                    $"Admin {currentUsername} exited application");
                Application.Exit();
            }
        }

        #endregion
    }

}


