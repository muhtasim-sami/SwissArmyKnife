
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
        
    }
}
