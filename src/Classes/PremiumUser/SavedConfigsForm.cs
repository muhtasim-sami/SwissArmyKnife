using Database;

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
            var configs = DatabaseQueries.GetUserConfigurations(userId);

            foreach (var config in configs)
            {
                ListViewItem item = new ListViewItem(config.Name);
                item.SubItems.Add("Network Scanner");

                // Parse options preview
                string preview = config.Options.Length > 50 ? config.Options.Substring(0, 50) + "..." : config.Options;
                item.SubItems.Add(preview);
                item.SubItems.Add(config.CreatedAt.ToString("yyyy-MM-dd HH:mm"));
                item.Tag = config.ConfigId;
                lvConfigs.Items.Add(item);
            }

            if (configs.Count == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No saved configurations");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                emptyItem.SubItems.Add("");
                lvConfigs.Items.Add(emptyItem);
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (lvConfigs.SelectedItems.Count == 0 || lvConfigs.SelectedItems[0].Tag == null)
            {
                MessageBox.Show("Please select a configuration to load.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int configId = (int)lvConfigs.SelectedItems[0].Tag;

            DatabaseQueries.LogAudit(userId, "LOAD_CONFIG", "SavedConfig", configId.ToString(), "Premium user loaded saved configuration");


            MessageBox.Show("Configuration loaded successfully.", "Loaded",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lvConfigs.SelectedItems.Count == 0 || lvConfigs.SelectedItems[0].Tag == null) return;



            DialogResult result = MessageBox.Show("Delete selected configuration?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int configId = (int)lvConfigs.SelectedItems[0].Tag;
                DatabaseQueries.DeleteConfiguration(configId, userId);
                DatabaseQueries.LogAudit(userId, "DELETE_CONFIG", "SavedConfig", configId.ToString(), "Premium user deleted saved configuration");
                LoadConfigs();
            }
        }
    }
}

