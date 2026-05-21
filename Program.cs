namespace SwissArmyKnife
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new HomepageForm());
        }

        static void HomepageForm_LoginClick(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        static void HomepageForm_ViewerClick(object sender, EventArgs e)
        {
            ViewerForm viewerForm = new ViewerForm();
            viewerForm.ShowDialog();
        }

        static void HomepageForm_RegisterClick(object sender, EventArgs e)
        {
            RegistrationForm registerForm = new RegistrationForm();
            registerForm.ShowDialog();
        }
    }
}