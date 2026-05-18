namespace SwissArmyKnife
{
    partial class AnalyticsDashboardForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Text = "Analytics Dashboard";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 38);

            rtbAnalytics = new RichTextBox();
            rtbAnalytics.Dock = DockStyle.Top;
            rtbAnalytics.Height = 500;
            rtbAnalytics.BackColor = Color.FromArgb(18, 18, 22);
            rtbAnalytics.ForeColor = Color.FromArgb(220, 220, 230);
            rtbAnalytics.Font = new Font("Consolas", 10F);
            rtbAnalytics.ReadOnly = true;

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.BackColor = Color.FromArgb(60, 60, 70);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(400, 520);
            btnClose.Click += (s, e) => Close();

            Controls.Add(btnClose);
            Controls.Add(rtbAnalytics);
        }

        #endregion

        private Button btnClose;
        private RichTextBox rtbAnalytics;
    }
}
