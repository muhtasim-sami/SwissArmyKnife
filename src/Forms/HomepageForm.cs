

namespace SwissArmyKnife
{
    public partial class HomepageForm : Form
    {

        public HomepageForm()
        {
            InitializeComponent();
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Hide();

            LoginForm login = new LoginForm();
            login.ShowDialog();

            Show();

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
            Hide();

            ViewerForm viewerForm = new ViewerForm();
            viewerForm.ShowDialog();

            Show();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Hide();

            RegistrationForm registerForm = new RegistrationForm();
            registerForm.ShowDialog();
            Show();
        }
    }
}


