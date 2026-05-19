namespace SwissArmyKnife
{
    partial class ScheduledScansForm
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
            this.Text = "Scheduled Scans";
            this.Size = new Size(800, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 38);

            lvSchedules = new ListView();
            lvSchedules.Dock = DockStyle.Top;
            lvSchedules.Height = 380;
            lvSchedules.View = View.Details;
            lvSchedules.FullRowSelect = true;
            lvSchedules.BackColor = Color.FromArgb(35, 35, 43);
            lvSchedules.ForeColor = Color.FromArgb(220, 220, 230);
            lvSchedules.Columns.Add("Schedule Name", 180);
            lvSchedules.Columns.Add("Scan Type", 120);
            lvSchedules.Columns.Add("Target", 180);
            lvSchedules.Columns.Add("Frequency", 120);
            lvSchedules.Columns.Add("Next Run", 150);

            btnAdd = new Button();
            btnAdd.Text = "Add Schedule";
            btnAdd.BackColor = Color.FromArgb(34, 140, 60);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Size = new Size(120, 35);
            btnAdd.Location = new Point(30, 420);
            btnAdd.Click += BtnAdd_Click;

            btnEdit = new Button();
            btnEdit.Text = "Edit";
            btnEdit.BackColor = Color.FromArgb(60, 60, 70);
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Size = new Size(100, 35);
            btnEdit.Location = new Point(170, 420);
            btnEdit.Click += BtnEdit_Click;

            btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.BackColor = Color.FromArgb(160, 40, 40);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Size = new Size(100, 35);
            btnDelete.Location = new Point(290, 420);
            btnDelete.Click += BtnDelete_Click;

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.BackColor = Color.FromArgb(60, 60, 70);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(670, 420);
            btnClose.Click += (s, e) => Close();

            btnToggle = new Button();
            btnToggle.Text = "Enable/Disable";
            btnToggle.BackColor = Color.FromArgb(60, 60, 70);
            btnToggle.ForeColor = Color.White;
            btnToggle.FlatStyle = FlatStyle.Flat;
            btnToggle.Size = new Size(120, 35);
            btnToggle.Location = new Point(410, 450);
            btnToggle.Click += BtnToggle_Click;

            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(lvSchedules);

        }

        #endregion

        private ListView lvSchedules;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClose;
        private Button btnToggle;
    }
}
