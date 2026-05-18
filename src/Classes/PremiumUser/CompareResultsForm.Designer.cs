namespace SwissArmyKnife
{
    partial class CompareResultsForm
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
            this.Text = "Compare Scan Results";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 38);

            Label lblScan1 = new Label();
            lblScan1.Text = "Scan 1:";
            lblScan1.ForeColor = Color.FromArgb(220, 220, 230);
            lblScan1.Location = new Point(20, 20);
            lblScan1.Size = new Size(60, 25);

            cboScan1 = new ComboBox();
            cboScan1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboScan1.BackColor = Color.FromArgb(35, 35, 43);
            cboScan1.ForeColor = Color.FromArgb(220, 220, 230);
            cboScan1.Location = new Point(90, 18);
            cboScan1.Size = new Size(300, 25);
            cboScan1.Items.AddRange(new object[] { "Network Scan - 2024-01-15", "Network Scan - 2024-01-08", "Web Audit - 2024-01-14" });
            cboScan1.SelectedIndex = 0;

            Label lblScan2 = new Label();
            lblScan2.Text = "Scan 2:";
            lblScan2.ForeColor = Color.FromArgb(220, 220, 230);
            lblScan2.Location = new Point(20, 60);
            lblScan2.Size = new Size(60, 25);

            cboScan2 = new ComboBox();
            cboScan2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboScan2.BackColor = Color.FromArgb(35, 35, 43);
            cboScan2.ForeColor = Color.FromArgb(220, 220, 230);
            cboScan2.Location = new Point(90, 58);
            cboScan2.Size = new Size(300, 25);
            cboScan2.Items.AddRange(new object[] { "Network Scan - 2024-01-15", "Network Scan - 2024-01-08", "Web Audit - 2024-01-14" });
            cboScan2.SelectedIndex = 1;

            btnCompare = new Button();
            btnCompare.Text = "Compare";
            btnCompare.BackColor = Color.FromArgb(34, 140, 60);
            btnCompare.ForeColor = Color.White;
            btnCompare.FlatStyle = FlatStyle.Flat;
            btnCompare.Size = new Size(100, 35);
            btnCompare.Location = new Point(410, 35);
            btnCompare.Click += BtnCompare_Click;

            rtbResults = new RichTextBox();
            rtbResults.BackColor = Color.FromArgb(18, 18, 22);
            rtbResults.ForeColor = Color.FromArgb(220, 220, 230);
            rtbResults.Font = new Font("Consolas", 9F);
            rtbResults.ReadOnly = true;
            rtbResults.Location = new Point(20, 110);
            rtbResults.Size = new Size(750, 430);

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.BackColor = Color.FromArgb(60, 60, 70);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(350, 555);
            btnClose.Click += (s, e) => Close();

            Controls.Add(btnClose);
            Controls.Add(rtbResults);
            Controls.Add(btnCompare);
            Controls.Add(cboScan2);
            Controls.Add(lblScan2);
            Controls.Add(cboScan1);
            Controls.Add(lblScan1);
        }

        #endregion

        private ComboBox cboScan1;
        private ComboBox cboScan2;
        private Button btnCompare;
        private RichTextBox rtbResults;
        private Button btnClose;
    }
}
