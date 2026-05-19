using System;
using System.Drawing;
using System.Windows.Forms;

namespace SwissArmyKnife
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Validate input
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

            // Disable controls during login
            SetControlsEnabled(false);
            lblError.Visible = false;

            // TODO: Authenticate against database
            // For now, using demo credentials
            bool isValid = AuthenticateUser(username, password);

            if (isValid)
            {
                // Get user role from database
                string role = GetUserRole(username);
                int userId = GetUserId(username);

                // Redirect based on role
                OpenRoleBasedDashboard(role, username, userId);

                // Close login form
                this.Hide();
            }
            else
            {
                ShowError("Invalid username or password");
                SetControlsEnabled(true);
                txtPassword.Text = "";
                txtPassword.Focus();
            }
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

    }
}

