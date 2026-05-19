namespace SwissArmyKnife
{
    partial class EditUserForm
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
            this.Text = $"Edit User - {user.Username}";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 38);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label lblRole = new Label();
            lblRole.Text = "Role:";
            lblRole.ForeColor = Color.FromArgb(220, 220, 230);
            lblRole.Location = new Point(30, 30);
            lblRole.Size = new Size(80, 25);

            cboRole = new ComboBox();
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.BackColor = Color.FromArgb(44, 44, 56);
            cboRole.ForeColor = Color.FromArgb(220, 220, 230);
            cboRole.Location = new Point(120, 28);
            cboRole.Size = new Size(200, 25);

            Label lblActive = new Label();
            lblActive.Text = "Status:";
            lblActive.ForeColor = Color.FromArgb(220, 220, 230);
            lblActive.Location = new Point(30, 70);
            lblActive.Size = new Size(80, 25);

            chkActive = new CheckBox();
            chkActive.Text = "Active";
            chkActive.ForeColor = Color.FromArgb(220, 220, 230);
            chkActive.Location = new Point(120, 70);
            chkActive.Size = new Size(100, 25);

            btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.BackColor = Color.FromArgb(34, 140, 60);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Size = new Size(100, 35);
            btnSave.Location = new Point(100, 200);
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.BackColor = Color.FromArgb(60, 60, 70);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Size = new Size(100, 35);
            btnCancel.Location = new Point(220, 200);
            btnCancel.Click += (s, e) => Close();

            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkActive);
            Controls.Add(lblActive);
            Controls.Add(cboRole);
            Controls.Add(lblRole);
        }

        #endregion

        private ComboBox cboRole;
        private CheckBox chkActive;
        private Button btnSave;
        private Button btnCancel;
    }
}
