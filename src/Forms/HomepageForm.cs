using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using Database;

namespace SwissArmyKnife
{
    public partial class HomepageForm : Form
    {
        private int loginAttempts = 0;
        private bool isLocked = false;

        public HomepageForm()
        {
            InitializeComponent();
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
            this.Hide();
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


        private void ViewerButton_Click(object sender, EventArgs e)
        {
            ViewerForm viewerForm = new ViewerForm();
            viewerForm.ShowDialog();
            this.Hide();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegistrationForm registerForm = new RegistrationForm();
            registerForm.ShowDialog();
            this.Hide();
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