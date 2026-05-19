using Database;

namespace SwissArmyKnife
{
    public partial class EditUserForm : Form
    {
        private DatabaseQueries.UserManagementInfo user;
        private int adminUserId;
        private List<string> roles;

        public EditUserForm(DatabaseQueries.UserManagementInfo user, int adminUserId)
        {
            this.user = user;
            this.adminUserId = adminUserId;
            InitializeComponent();
            LoadRoles();
            LoadUserData();
        }
        private void LoadRoles()
        {
            roles = DatabaseQueries.GetAllRoles();
            foreach (string role in roles)
            {
                cboRole.Items.Add(role);
            }
        }

        private void LoadUserData()
        {
            for (int i = 0; i < cboRole.Items.Count; i++)
            {
                if (cboRole.Items[i].ToString() == user.Role)
                {
                    cboRole.SelectedIndex = i;
                    break;
                }
            }
            chkActive.Checked = user.IsActive;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string newRole = cboRole.SelectedItem.ToString();
            bool newStatus = chkActive.Checked;

            if (newRole != user.Role)
            {
                int newRoleId = DatabaseQueries.GetRoleId(newRole);
                DatabaseQueries.UpdateUserRole(user.UserId, newRoleId);
                DatabaseQueries.LogAudit(adminUserId, "EDIT_USER_ROLE", "User", user.UserId.ToString(),
                    $"Admin changed user {user.Username} role from {user.Role} to {newRole}");
            }

            if (newStatus != user.IsActive)
            {
                DatabaseQueries.UpdateUserStatus(user.UserId, newStatus);
                string action = newStatus ? "activated" : "deactivated";
                DatabaseQueries.LogAudit(adminUserId, "EDIT_USER_STATUS", "User", user.UserId.ToString(),
                    $"Admin {action} user {user.Username}");
            }

            MessageBox.Show("User updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}

