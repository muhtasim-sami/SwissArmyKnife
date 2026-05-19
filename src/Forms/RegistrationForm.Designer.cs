namespace SwissArmyKnife
{
    partial class RegistrationForm
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
            lblTitle.Location = new Point(80, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 42);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Account";
            //
            // lblSubtitle
            //
            lblSubtitle = new Label();
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.FromArgb(164, 165, 169);
            lblSubtitle.Location = new Point(50, 75);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(250, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Join SwissArmyKnife Penetration Testing Suite";
            //
            // lblUsername
            //
            lblUsername = new Label();
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.FromArgb(164, 165, 169);
            lblUsername.Location = new Point(50, 120);
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
            txtUsername.Location = new Point(50, 145);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(320, 22);
            txtUsername.TabIndex = 3;
            txtUsername.TextChanged += TxtUsername_TextChanged;
            //
            // pnlLineUsername
            //
            pnlLineUsername = new Panel();
            pnlLineUsername.BackColor = Color.FromArgb(117, 89, 179);
            pnlLineUsername.Location = new Point(50, 173);
            pnlLineUsername.Name = "pnlLineUsername";
            pnlLineUsername.Size = new Size(320, 1);
            pnlLineUsername.TabIndex = 4;
            //
            // lblEmail
            //
            lblEmail = new Label();
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(164, 165, 169);
            lblEmail.Location = new Point(50, 190);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 19);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email";
            //
            // txtEmail
            //
            txtEmail = new TextBox();
            txtEmail.BackColor = Color.FromArgb(44, 44, 56);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.FromArgb(80, 200, 130);
            txtEmail.Location = new Point(50, 215);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 22);
            txtEmail.TabIndex = 6;
            //
            // pnlLineEmail
            //
            pnlLineEmail = new Panel();
            pnlLineEmail.BackColor = Color.FromArgb(117, 89, 179);
            pnlLineEmail.Location = new Point(50, 243);
            pnlLineEmail.Name = "pnlLineEmail";
            pnlLineEmail.Size = new Size(320, 1);
            pnlLineEmail.TabIndex = 7;
            //
            // lblPassword
            //
            lblPassword = new Label();
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.FromArgb(164, 165, 169);
            lblPassword.Location = new Point(50, 260);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 19);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Password";
            //
            // txtPassword
            //
            txtPassword = new TextBox();
            txtPassword.BackColor = Color.FromArgb(44, 44, 56);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.FromArgb(80, 200, 130);
            txtPassword.Location = new Point(50, 285);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(320, 22);
            txtPassword.TabIndex = 9;
            //
            // pnlLinePassword
            //
            pnlLinePassword = new Panel();
            pnlLinePassword.BackColor = Color.FromArgb(117, 89, 179);
            pnlLinePassword.Location = new Point(50, 313);
            pnlLinePassword.Name = "pnlLinePassword";
            pnlLinePassword.Size = new Size(320, 1);
            pnlLinePassword.TabIndex = 10;
            //
            // lblConfirmPassword
            //
            lblConfirmPassword = new Label();
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Nirmala UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfirmPassword.ForeColor = Color.FromArgb(164, 165, 169);
            lblConfirmPassword.Location = new Point(50, 330);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(124, 19);
            lblConfirmPassword.TabIndex = 11;
            lblConfirmPassword.Text = "Confirm Password";
            //
            // txtConfirmPassword
            //
            txtConfirmPassword = new TextBox();
            txtConfirmPassword.BackColor = Color.FromArgb(44, 44, 56);
            txtConfirmPassword.BorderStyle = BorderStyle.None;
            txtConfirmPassword.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.ForeColor = Color.FromArgb(80, 200, 130);
            txtConfirmPassword.Location = new Point(50, 355);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '•';
            txtConfirmPassword.Size = new Size(320, 22);
            txtConfirmPassword.TabIndex = 12;
            //
            // pnlLineConfirm
            //
            pnlLineConfirm = new Panel();
            pnlLineConfirm.BackColor = Color.FromArgb(117, 89, 179);
            pnlLineConfirm.Location = new Point(50, 383);
            pnlLineConfirm.Name = "pnlLineConfirm";
            pnlLineConfirm.Size = new Size(320, 1);
            pnlLineConfirm.TabIndex = 13;
            //
            // chkShowPassword
            //
            chkShowPassword = new CheckBox();
            chkShowPassword.AutoSize = true;
            chkShowPassword.Cursor = Cursors.Hand;
            chkShowPassword.FlatStyle = FlatStyle.Flat;
            chkShowPassword.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowPassword.ForeColor = Color.FromArgb(164, 165, 169);
            chkShowPassword.Location = new Point(270, 400);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(100, 19);
            chkShowPassword.TabIndex = 14;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            //
            // btnRegister
            //
            btnRegister = new Button();
            btnRegister.BackColor = Color.FromArgb(34, 140, 60);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(50, 440);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 40);
            btnRegister.TabIndex = 15;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += BtnRegister_Click;
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
            btnClear.Location = new Point(220, 440);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 40);
            btnClear.TabIndex = 16;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            //
            // llLogin
            //
            llLogin = new LinkLabel();
            llLogin.AutoSize = true;
            llLogin.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            llLogin.LinkColor = Color.FromArgb(117, 89, 179);
            llLogin.Location = new Point(120, 500);
            llLogin.Name = "llLogin";
            llLogin.Size = new Size(170, 19);
            llLogin.TabIndex = 17;
            llLogin.TabStop = true;
            llLogin.Text = "Already have an account? Login";
            llLogin.LinkClicked += LlLogin_LinkClicked;
            //
            // lblError
            //
            lblError = new Label();
            lblError.AutoSize = true;
            lblError.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.FromArgb(210, 70, 70);
            lblError.Location = new Point(50, 420);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 15);
            lblError.TabIndex = 18;
            lblError.Visible = false;
            //
            // lblUsernameError
            //
            lblUsernameError = new Label();
            lblUsernameError.AutoSize = true;
            lblUsernameError.Font = new Font("Nirmala UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsernameError.ForeColor = Color.FromArgb(210, 70, 70);
            lblUsernameError.Location = new Point(50, 178);
            lblUsernameError.Name = "lblUsernameError";
            lblUsernameError.Size = new Size(0, 13);
            lblUsernameError.TabIndex = 19;
            lblUsernameError.Visible = false;
            //
            // lblEmailError
            //
            lblEmailError = new Label();
            lblEmailError.AutoSize = true;
            lblEmailError.Font = new Font("Nirmala UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmailError.ForeColor = Color.FromArgb(210, 70, 70);
            lblEmailError.Location = new Point(50, 248);
            lblEmailError.Name = "lblEmailError";
            lblEmailError.Size = new Size(0, 13);
            lblEmailError.TabIndex = 20;
            lblEmailError.Visible = false;
            //
            // lblPasswordStrength
            //
            lblPasswordStrength = new Label();
            lblPasswordStrength.AutoSize = true;
            lblPasswordStrength.Font = new Font("Nirmala UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPasswordStrength.Location = new Point(50, 318);
            lblPasswordStrength.Name = "lblPasswordStrength";
            lblPasswordStrength.Size = new Size(0, 13);
            lblPasswordStrength.TabIndex = 21;
            lblPasswordStrength.Visible = false;
            //
            // btnClose
            //
            btnClose = new Label();
            btnClose.AutoSize = true;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(164, 165, 169);
            btnClose.Location = new Point(385, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(29, 25);
            btnClose.TabIndex = 22;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            //
            // RegistrationForm
            //
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 38);
            ClientSize = new Size(420, 550);
            Controls.Add(btnClose);
            Controls.Add(lblPasswordStrength);
            Controls.Add(lblEmailError);
            Controls.Add(lblUsernameError);
            Controls.Add(lblError);
            Controls.Add(llLogin);
            Controls.Add(btnClear);
            Controls.Add(btnRegister);
            Controls.Add(chkShowPassword);
            Controls.Add(pnlLineConfirm);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(pnlLinePassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(pnlLineEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(pnlLineUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register - SwissArmyKnife";
            Load += RegistrationForm_Load;
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Panel pnlLineUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Panel pnlLineEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Panel pnlLinePassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Panel pnlLineConfirm;
        private CheckBox chkShowPassword;
        private Button btnRegister;
        private Button btnClear;
        private LinkLabel llLogin;
        private Label lblError;
        private Label lblUsernameError;
        private Label lblEmailError;
        private Label lblPasswordStrength;
        private Label btnClose;
    }
}

/*
 
 namespace SwissArmyKnife
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            
        }

        #endregion

        
    }
}
 
 */