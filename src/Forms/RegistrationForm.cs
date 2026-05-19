using Database;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using DatabaseQueries = Database.DatabaseQueries;

namespace SwissArmyKnife
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            txtPassword.TextChanged += TxtPassword_TextChanged;
        }

        private void LoginForm_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";

            HideAllErrors();

            txtUsername.Focus();
        }

        private void HideAllErrors()
        {
            lblError.Visible = false;
            lblUsernameError.Visible = false;
            lblEmailError.Visible = false;
            lblPasswordStrength.Visible = false;
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private bool ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                lblUsernameError.Text = "Username is required";
                lblUsernameError.Visible = true;
                return false;
            }

            if (username.Length < 3)
            {
                lblUsernameError.Text = "Username must be at least 3 characters";
                lblUsernameError.Visible = true;
                return false;
            }

            if (username.Length > 20)
            {
                lblUsernameError.Text = "Username must be less than 20 characters";
                lblUsernameError.Visible = true;
                return false;
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                lblUsernameError.Text = "Username can only contain letters, numbers and underscore";
                lblUsernameError.Visible = true;
                return false;
            }

            lblUsernameError.Visible = false;
            return true;
        }

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                lblEmailError.Text = "Email is required";
                lblEmailError.Visible = true;
                return false;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblEmailError.Text = "Please enter a valid email address";
                lblEmailError.Visible = true;
                return false;
            }

            lblEmailError.Visible = false;
            return true;
        }

        private bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                ShowError("Password is required");
                return false;
            }

            if (password.Length < 8)
            {
                ShowError("Password must be at least 8 characters");
                return false;
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                ShowError("Password must contain at least one uppercase letter");
                return false;
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                ShowError("Password must contain at least one lowercase letter");
                return false;
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                ShowError("Password must contain at least one number");
                return false;
            }

            if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?"":{}|<>]"))
            {
                ShowError("Password must contain at least one special character");
                return false;
            }

            return true;
        }

        private bool ValidateConfirmPassword(string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ShowError("Passwords do not match");
                return false;
            }

            return true;
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0)
            {
                ValidateUsername(txtUsername.Text);
            }
            else
            {
                lblUsernameError.Visible = false;
            }
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(password))
            {
                lblPasswordStrength.Visible = false;
                return;
            }

            int strength = 0;

            if (password.Length >= 8) strength++;
            if (password.Length >= 12) strength++;
            if (Regex.IsMatch(password, @"[A-Z]")) strength++;
            if (Regex.IsMatch(password, @"[a-z]")) strength++;
            if (Regex.IsMatch(password, @"[0-9]")) strength++;
            if (Regex.IsMatch(password, @"[!@#$%^&*(),.?"":{}|<>]")) strength++;

            lblPasswordStrength.Visible = true;

            if (strength <= 2)
            {
                lblPasswordStrength.Text = "Password strength: Weak";
                lblPasswordStrength.ForeColor = Color.FromArgb(210, 70, 70);
            }
            else if (strength <= 4)
            {
                lblPasswordStrength.Text = "Password strength: Medium";
                lblPasswordStrength.ForeColor = Color.FromArgb(220, 170, 40);
            }
            else
            {
                lblPasswordStrength.Text = "Password strength: Strong";
                lblPasswordStrength.ForeColor = Color.FromArgb(60, 180, 100);
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtConfirmPassword.PasswordChar = '•';
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            HideAllErrors();

            bool isValid = true;
            if (!ValidateUsername(username)) isValid = false;
            if (!ValidateEmail(email)) isValid = false;
            if (!ValidatePassword(password)) isValid = false;
            if (!ValidateConfirmPassword(password, confirmPassword)) isValid = false;

            if (!isValid) return;

            if (DatabaseQueries.UsernameExists(username))
            {
                ShowError("Username already exists. Please choose another.");
                txtUsername.Focus();
                return;
            }

            if (DatabaseQueries.EmailExists(email))
            {
                ShowError("Email already registered. Please use another or login.");
                txtEmail.Focus();
                return;
            }

            int roleId = DatabaseQueries.GetRoleId("RegularUser");
            bool registered = DatabaseQueries.RegisterUser(username, email, password, roleId);

            if (registered)
            {
                MessageBox.Show($"Registration successful!\n\nUsername: {username}\n\nYou can now login with your credentials.",
                    "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                ShowError("Registration failed. Please try again.");
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            HideAllErrors();
            txtUsername.Focus();
        }

        private void LlLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
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

/*


namespace SwissArmyKnife
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            txtPassword.TextChanged += TxtPassword_TextChanged;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            HideAllErrors();
            txtUsername.Focus();
        }

        private void HideAllErrors()
        {
            lblError.Visible = false;
            lblUsernameError.Visible = false;
            lblEmailError.Visible = false;
            lblPasswordStrength.Visible = false;
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private bool ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                lblUsernameError.Text = "Username is required";
                lblUsernameError.Visible = true;
                return false;
            }

            if (username.Length < 3)
            {
                lblUsernameError.Text = "Username must be at least 3 characters";
                lblUsernameError.Visible = true;
                return false;
            }

            if (username.Length > 100)
            {
                lblUsernameError.Text = "Username must be less than 100 characters";
                lblUsernameError.Visible = true;
                return false;
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                lblUsernameError.Text = "Username can only contain letters, numbers and underscore";
                lblUsernameError.Visible = true;
                return false;
            }

            lblUsernameError.Visible = false;
            return true;
        }

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                lblEmailError.Text = "Email is required";
                lblEmailError.Visible = true;
                return false;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblEmailError.Text = "Please enter a valid email address";
                lblEmailError.Visible = true;
                return false;
            }

            lblEmailError.Visible = false;
            return true;
        }

        private bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                ShowError("Password is required");
                return false;
            }

            if (password.Length < 8)
            {
                ShowError("Password must be at least 8 characters");
                return false;
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                ShowError("Password must contain at least one uppercase letter");
                return false;
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                ShowError("Password must contain at least one lowercase letter");
                return false;
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                ShowError("Password must contain at least one number");
                return false;
            }

            if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?"":{}|<>]"))
            {
                ShowError("Password must contain at least one special character");
                return false;
            }

            return true;
        }

        private bool ValidateConfirmPassword(string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ShowError("Passwords do not match");
                return false;
            }
            return true;
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0)
                ValidateUsername(txtUsername.Text);
            else
                lblUsernameError.Visible = false;
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            
            if (string.IsNullOrEmpty(password))
            {
                lblPasswordStrength.Visible = false;
                return;
            }

            int strength = 0;
            if (password.Length >= 8) strength++;
            if (password.Length >= 12) strength++;
            if (Regex.IsMatch(password, @"[A-Z]")) strength++;
            if (Regex.IsMatch(password, @"[a-z]")) strength++;
            if (Regex.IsMatch(password, @"[0-9]")) strength++;
            if (Regex.IsMatch(password, @"[!@#$%^&*(),.?"":{}|<>]")) strength++;

            lblPasswordStrength.Visible = true;
            
            if (strength <= 2)
            {
                lblPasswordStrength.Text = "Password strength: Weak";
                lblPasswordStrength.ForeColor = Color.FromArgb(210, 70, 70);
            }
            else if (strength <= 4)
            {
                lblPasswordStrength.Text = "Password strength: Medium";
                lblPasswordStrength.ForeColor = Color.FromArgb(220, 170, 40);
            }
            else
            {
                lblPasswordStrength.Text = "Password strength: Strong";
                lblPasswordStrength.ForeColor = Color.FromArgb(60, 180, 100);
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '•';
            txtConfirmPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '•';
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            HideAllErrors();
            txtUsername.Focus();
        }

        private void LlLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) Application.Exit();
        }
    }
}
 
 
 */
