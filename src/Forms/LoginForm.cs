using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using Database;

namespace SwissArmyKnife
{
    public partial class LoginForm : Form
    {
        private int loginAttempts = 0;
        private bool isLocked = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '•';
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
        /*
        private bool AuthenticateUser(string username, string password, out int userId, out string role, out bool isActive)
        {
            userId = 0;
            role = "";
            isActive = false;

            string hashedPassword = HashPassword(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT u.UserId, u.Username, u.RoleId, r.Name as RoleName, u.IsActive, u.PasswordHash
                    FROM dbo.Users u
                    INNER JOIN dbo.Roles r ON u.RoleId = r.RoleId
                    WHERE u.Username = @Username AND u.PasswordHash = @PasswordHash";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32(0);
                            role = reader.GetString(3);
                            isActive = reader.GetBoolean(4);
                            return true;
                        }
                    }
                }
            }
            return false;
        }*/

        /*
        private void UpdateLastLogin(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE dbo.Users SET LastLogin = @LastLogin WHERE UserId = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LastLogin", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        */

        /*
        private void LogAudit(int userId, string action, string targetType, string targetId, string details)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO dbo.AuditLog (UserId, Action, TargetType, TargetId, Details, CreatedAt)
                    VALUES (@UserId, @Action, @TargetType, @TargetId, @Details, @CreatedAt)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId > 0 ? (object)userId : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@TargetType", targetType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TargetId", targetId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Details", details ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        */
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (isLocked)
            {
                ShowError("Account temporarily locked. Please try again later.");
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                ShowError("Please enter username");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ShowError("Please enter password");
                txtPassword.Focus();
                return;
            }

            SetControlsEnabled(false);
            lblError.Visible = false;

            var user = DatabaseQueries.AuthenticateUser(username, password);

            if (user != null && user.IsActive)
            {
                loginAttempts = 0;
                DatabaseQueries.UpdateLastLogin(user.UserId);
                DatabaseQueries.LogAudit(user.UserId, "LOGIN_SUCCESS", "User", user.UserId.ToString(), $"User {username} logged in successfully");

                OpenRoleBasedDashboard(user.Role, username, user.UserId);
                this.Hide();
            }
            else if (user != null && !user.IsActive)
            {
                loginAttempts++;
                ShowError("Account is deactivated. Please contact administrator.");
                DatabaseQueries.LogAudit(user.UserId, "LOGIN_FAILED_INACTIVE", "User", user.UserId.ToString(), $"Inactive account attempted login: {username}");
                SetControlsEnabled(true);
                txtPassword.Text = "";
                txtPassword.Focus();

                if (loginAttempts >= 5) isLocked = true;
            }
            else
            {
                loginAttempts++;
                ShowError("Invalid username or password");
                DatabaseQueries.LogAudit(0, "LOGIN_FAILED", "User", username, $"Failed login attempt for {username}");
                SetControlsEnabled(true);
                txtPassword.Text = "";
                txtPassword.Focus();

                if (loginAttempts >= 5) isLocked = true;
            }
        }

        private void OpenRoleBasedDashboard(string role, string username, int userId)
        {
            Form dashboard = null;

            switch (role)
            {
                case "Admin":
                    //dashboard = new AdminForm(username, userId);
                    break;
                case "PremiumUser":
                    dashboard = new PremiumUserForm(username, userId);
                    break;
                case "RegularUser":
                    dashboard = new RegularUserForm(username, userId);
                    break;
                case "Viewer":
                    dashboard = new ViewerForm(username, userId);
                    break;
                default:
                    dashboard = new RegularUserForm(username, userId);
                    break;
            }

            dashboard.FormClosed += (s, args) =>
            {
                this.Show();
                this.txtUsername.Text = "";
                this.txtPassword.Text = "";
                this.lblError.Visible = false;
                SetControlsEnabled(true);
            };

            dashboard.Show();
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void SetControlsEnabled(bool enabled)
        {
            txtUsername.Enabled = enabled;
            txtPassword.Enabled = enabled;
            btnLogin.Enabled = enabled;
            btnClear.Enabled = enabled;
            chkShowPassword.Enabled = enabled;
            llRegister.Enabled = enabled;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            lblError.Visible = false;
            txtUsername.Focus();
        }

        private void LlRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registerForm = new RegistrationForm();
            registerForm.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Clear any saved credentials
            txtUsername.Text = "";
            txtPassword.Text = "";
            lblError.Visible = false;

            // Set focus to username field
            txtUsername.Focus();
        }

        private bool AuthenticateUser(string username, string password)
        {
            // TODO: Implement actual database authentication
            // This is temporary demo authentication

            // Demo credentials:
            // admin / admin123
            // premium / premium123
            // regular / regular123
            // viewer / viewer123

            if (username == "admin" && password == "admin123")
                return true;
            if (username == "premium" && password == "premium123")
                return true;
            if (username == "regular" && password == "regular123")
                return true;
            if (username == "viewer" && password == "viewer123")
                return true;

            return false;
        }

        private string GetUserRole(string username)
        {
            // TODO: Get role from database
            // Temporary role assignment based on username
            switch (username.ToLower())
            {
                case "admin":
                    return "Admin";
                case "premium":
                    return "PremiumUser";
                case "regular":
                    return "RegularUser";
                case "viewer":
                    return "Viewer";
                default:
                    return "RegularUser";
            }
        }

        private int GetUserId(string username)
        {
            // TODO: Get user ID from database
            // Temporary ID assignment
            switch (username.ToLower())
            {
                case "admin":
                    return 1;
                case "premium":
                    return 2;
                case "regular":
                    return 3;
                case "viewer":
                    return 4;
                default:
                    return 0;
            }
        }

    }
}


/*
 
using System;
using System.Windows.Forms;

namespace SwissArmyKnife
{
    public partial class LoginForm : Form
    {
        

        public LoginForm()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents() { }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            lblError.Visible = false;
            txtUsername.Focus();
        }

        

        
        private void OpenRoleBasedDashboard(string role, string username, int userId)
        {
            Form dashboard = null;

            switch (role)
            {
                case "Admin": dashboard = new AdminForm(username, userId); break;
                case "PremiumUser": dashboard = new PremiumUserForm(username, userId); break;
                case "RegularUser": dashboard = new RegularUserForm(username, userId); break;
                case "Viewer": dashboard = new ViewerForm(username, userId); break;
                default: dashboard = new RegularUserForm(username, userId); break;
            }

            dashboard.FormClosed += (s, args) =>
            {
                this.Show();
                txtUsername.Text = "";
                txtPassword.Text = "";
                lblError.Visible = false;
                SetControlsEnabled(true);
            };

            dashboard.Show();
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void SetControlsEnabled(bool enabled)
        {
            txtUsername.Enabled = enabled;
            txtPassword.Enabled = enabled;
            btnLogin.Enabled = enabled;
            btnClear.Enabled = enabled;
            chkShowPassword.Enabled = enabled;
            llRegister.Enabled = enabled;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            lblError.Visible = false;
            txtUsername.Focus();
        }

        private void LlRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registerForm = new RegistrationForm();
            registerForm.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) Application.Exit();
        }
    }
} 

 
 */