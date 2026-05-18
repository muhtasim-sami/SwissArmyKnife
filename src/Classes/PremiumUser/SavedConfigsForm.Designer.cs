namespace SwissArmyKnife
{
    partial class SavedConfigsForm
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
            this.Text = "Saved Configurations";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 38);

            lvConfigs = new ListView();
            lvConfigs.Dock = DockStyle.Top;
            lvConfigs.Height = 350;
            lvConfigs.View = View.Details;
            lvConfigs.FullRowSelect = true;
            lvConfigs.BackColor = Color.FromArgb(35, 35, 43);
            lvConfigs.ForeColor = Color.FromArgb(220, 220, 230);
            lvConfigs.Columns.Add("Config Name", 200);
            lvConfigs.Columns.Add("Scan Type", 120);
            lvConfigs.Columns.Add("Target", 180);
            lvConfigs.Columns.Add("Created", 150);

            btnLoad = new Button();
            btnLoad.Text = "Load Configuration";
            btnLoad.BackColor = Color.FromArgb(34, 140, 60);
            btnLoad.ForeColor = Color.White;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Size = new Size(150, 35);
            btnLoad.Location = new Point(50, 400);
            btnLoad.Click += BtnLoad_Click;

            btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.BackColor = Color.FromArgb(160, 40, 40);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Size = new Size(100, 35);
            btnDelete.Location = new Point(220, 400);
            btnDelete.Click += BtnDelete_Click;

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.BackColor = Color.FromArgb(60, 60, 70);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(550, 400);
            btnClose.Click += (s, e) => Close();

            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnLoad);
            Controls.Add(lvConfigs);
        }

        #endregion

        private ListView lvConfigs;
        private Button btnLoad;
        private Button btnDelete;
        private Button btnClose;
    }
}
