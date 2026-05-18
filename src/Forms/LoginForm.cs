namespace SwissArmyKnife
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            this.Hide();
            registrationForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            this.Hide();
            dashboardForm.ShowDialog();
            this.Show();
        }

        private void ViewerButton_Click(object sender, EventArgs e)
        {
            ViewerForm ViewerForm = new ViewerForm();
            this.Hide();
            ViewerForm.ShowDialog();
            this.Show();
        }

        private void RegularUserButton_Click(object sender, EventArgs e)
        {
            RegularUserForm RegularUserForm = new RegularUserForm();
            this.Hide();
            RegularUserForm.ShowDialog();
            this.Show();
        }
    }
}
