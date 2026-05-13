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
    }
}
