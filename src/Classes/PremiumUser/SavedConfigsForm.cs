namespace SwissArmyKnife
{
    public partial class SavedConfigsForm : Form
    {
        private int userId;

        public SavedConfigsForm(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            LoadConfigs();
        }

        private void LoadConfigs()
        {
            lvConfigs.Items.Clear();

            // TODO: Load saved configs from database
            // Sample data
            ListViewItem item1 = new ListViewItem("Production Network Scan");
            item1.SubItems.Add("Network Scanner");
            item1.SubItems.Add("192.168.1.0/24");
            item1.SubItems.Add("2024-01-15");
            lvConfigs.Items.Add(item1);

            ListViewItem item2 = new ListViewItem("API Security Audit");
            item2.SubItems.Add("Web Auditor");
            item2.SubItems.Add("https://api.example.com");
            item2.SubItems.Add("2024-01-14");
            lvConfigs.Items.Add(item2);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (lvConfigs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a configuration to load.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Load and apply selected configuration
            MessageBox.Show("Configuration loaded successfully.", "Loaded",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lvConfigs.SelectedItems.Count == 0) return;

            DialogResult result = MessageBox.Show("Delete selected configuration?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // TODO: Delete from database
                lvConfigs.SelectedItems[0].Remove();
            }
        }
    }
}

