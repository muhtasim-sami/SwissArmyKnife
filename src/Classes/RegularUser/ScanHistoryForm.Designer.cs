namespace SwissArmyKnife
{
    partial class ScanHistoryForm
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
            //
            // lblTitle
            //
            this.Text = $"Scan History (Last {daysLimit} Days)";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 38);

            lvHistory = new ListView();
            lvHistory.Dock = DockStyle.Top;
            lvHistory.Height = 380;
            lvHistory.View = View.Details;
            lvHistory.FullRowSelect = true;
            lvHistory.BackColor = Color.FromArgb(35, 35, 43);
            lvHistory.ForeColor = Color.FromArgb(220, 220, 230);
            lvHistory.Columns.Add("Scan Type", 150);
            lvHistory.Columns.Add("Target", 200);
            lvHistory.Columns.Add("Date", 150);
            lvHistory.Columns.Add("Duration", 100);
            lvHistory.Columns.Add("Status", 100);

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.BackColor = Color.FromArgb(60, 60, 70);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(350, 410);
            btnClose.Click += (s, e) => Close();

            Controls.Add(btnClose);
            Controls.Add(lvHistory);
            this.Text = $"Scan History (Last {daysLimit} Days)";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 38);

            lvHistory = new ListView();
            lvHistory.Dock = DockStyle.Top;
            lvHistory.Height = 380;
            lvHistory.View = View.Details;
            lvHistory.FullRowSelect = true;
            lvHistory.BackColor = Color.FromArgb(35, 35, 43);
            lvHistory.ForeColor = Color.FromArgb(220, 220, 230);
            lvHistory.Columns.Add("Scan Type", 150);
            lvHistory.Columns.Add("Target", 200);
            lvHistory.Columns.Add("Date", 150);
            lvHistory.Columns.Add("Duration", 100);
            lvHistory.Columns.Add("Status", 100);

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.BackColor = Color.FromArgb(60, 60, 70);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(350, 410);
            btnClose.Click += (s, e) => Close();

            Controls.Add(btnClose);
            Controls.Add(lvHistory);

        }

        #endregion

        private ListView lvHistory;
        private Button btnClose;
    }
}

