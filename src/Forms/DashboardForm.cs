
namespace SwissArmyKnife
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void NerworkScannerForm_Click(object sender, EventArgs e)
        {

            NetworkScannerForm networkScannerForm = new NetworkScannerForm();
            this.Hide();
            networkScannerForm.ShowDialog();
            this.Show();
        }

        private void NerworkScannerForm_Load(object sender, EventArgs e)
        {

        }

        private void WebSecurityAuditButton_Click(object sender, EventArgs e)
        {
            WebSecurityAuditForm webSecurityAuditForm = new WebSecurityAuditForm();
            this.Hide();
            webSecurityAuditForm.ShowDialog();
            this.Show();
        }
    }
}
