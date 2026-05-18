namespace SwissArmyKnife
{
    public partial class FullScanHistoryForm : Form
    {
        private int userId;

        public FullScanHistoryForm(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            LoadHistory();
        }

        private void LoadHistory()
        {
            lvHistory.Items.Clear();

            // TODO: Load full scan history from database
            // Sample data
            ListViewItem item1 = new ListViewItem("Network Scan");
            item1.SubItems.Add("192.168.1.0/24");
            item1.SubItems.Add(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm"));
            item1.SubItems.Add("45 seconds");
            item1.SubItems.Add("12");
            item1.SubItems.Add("156");
            item1.SubItems.Add("Completed");
            lvHistory.Items.Add(item1);

            ListViewItem item2 = new ListViewItem("Web Audit");
            item2.SubItems.Add("https://example.com");
            item2.SubItems.Add(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm"));
            item2.SubItems.Add("12 seconds");
            item2.SubItems.Add("N/A");
            item2.SubItems.Add("N/A");
            item2.SubItems.Add("Completed");
            lvHistory.Items.Add(item2);
        }
    }
}
