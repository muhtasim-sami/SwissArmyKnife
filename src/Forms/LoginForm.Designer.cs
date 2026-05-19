namespace SwissArmyKnife
{
    partial class LoginForm
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
            lblTitle = new Label();
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(117, 89, 179);
            lblTitle.Location = new Point(60, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 42);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SwissArmyKnife";
            //
            // lblSubtitle
            //
            lblSubtitle = new Label();
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.FromArgb(164, 165, 169);
            lblSubtitle.Location = new Point(80, 85);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(140, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Penetration Testing Suite";
            //
            // lblUsername
            //
            lblUsername = new Label();
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.FromArgb(164, 165, 169);
            lblUsername.Location = new Point(50, 140);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(73, 19);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            //
            // txtUsername
            //
            txtUsername = new TextBox();
            txtUsername.BackColor = Color.FromArgb(44, 44, 56);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.FromArgb(80, 200, 130);
            txtUsername.Location = new Point(50, 165);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(280, 22);
            txtUsername.TabIndex = 3;
            //
            // lblPassword
            //
            lblPassword = new Label();
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.FromArgb(164, 165, 169);
            lblPassword.Location = new Point(50, 210);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 19);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            //
            // txtPassword
            //
            txtPassword = new TextBox();
            txtPassword.BackColor = Color.FromArgb(44, 44, 56);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.FromArgb(80, 200, 130);
            txtPassword.Location = new Point(50, 235);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(280, 22);
            txtPassword.TabIndex = 5;
            //
            // chkShowPassword
            //
            chkShowPassword = new CheckBox();
            chkShowPassword.AutoSize = true;
            chkShowPassword.Cursor = Cursors.Hand;
            chkShowPassword.FlatStyle = FlatStyle.Flat;
            chkShowPassword.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowPassword.ForeColor = Color.FromArgb(164, 165, 169);
            chkShowPassword.Location = new Point(230, 265);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(100, 19);
            chkShowPassword.TabIndex = 6;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            //
            // btnLogin
            //
            btnLogin = new Button();
            btnLogin.BackColor = Color.FromArgb(34, 140, 60);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 310);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(130, 40);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            //
            // btnClear
            //
            btnClear = new Button();
            btnClear.BackColor = Color.FromArgb(60, 60, 70);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(200, 310);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(130, 40);
            btnClear.TabIndex = 8;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            //
            // llRegister
            //
            llRegister = new LinkLabel();
            llRegister.AutoSize = true;
            llRegister.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            llRegister.LinkColor = Color.FromArgb(117, 89, 179);
            llRegister.Location = new Point(110, 370);
            llRegister.Name = "llRegister";
            llRegister.Size = new Size(170, 19);
            llRegister.TabIndex = 9;
            llRegister.TabStop = true;
            llRegister.Text = "Don't have an account? Register";
            llRegister.LinkClicked += LlRegister_LinkClicked;
            //
            // btnClose
            //
            btnClose = new Label();
            btnClose.AutoSize = true;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(164, 165, 169);
            btnClose.Location = new Point(345, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(29, 25);
            btnClose.TabIndex = 10;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            //
            // pnlLine
            //
            pnlLine = new Panel();
            pnlLine.BackColor = Color.FromArgb(117, 89, 179);
            pnlLine.Location = new Point(50, 193);
            pnlLine.Name = "pnlLine";
            pnlLine.Size = new Size(280, 1);
            pnlLine.TabIndex = 11;
            //
            // pnlLinePassword
            //
            pnlLinePassword = new Panel();
            pnlLinePassword.BackColor = Color.FromArgb(117, 89, 179);
            pnlLinePassword.Location = new Point(50, 263);
            pnlLinePassword.Name = "pnlLinePassword";
            pnlLinePassword.Size = new Size(280, 1);
            pnlLinePassword.TabIndex = 12;
            //
            // lblError
            //
            lblError = new Label();
            lblError.AutoSize = true;
            lblError.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.FromArgb(210, 70, 70);
            lblError.Location = new Point(50, 290);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 15);
            lblError.TabIndex = 13;
            lblError.Visible = false;
            //
            // LoginForm
            //
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 38);
            ClientSize = new Size(400, 430);
            Controls.Add(lblError);
            Controls.Add(pnlLinePassword);
            Controls.Add(pnlLine);
            Controls.Add(btnClose);
            Controls.Add(llRegister);
            Controls.Add(btnClear);
            Controls.Add(btnLogin);
            Controls.Add(chkShowPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - SwissArmyKnife";
            Load += LoginForm_Load;
        }

        #endregion


        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private Button btnClear;
        private LinkLabel llRegister;
        private Label btnClose;
        private Panel pnlLine;
        private Panel pnlLinePassword;
        private Label lblError;
    }
}


