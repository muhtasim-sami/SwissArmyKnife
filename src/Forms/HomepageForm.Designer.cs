namespace SwissArmyKnife
{
    partial class HomepageForm
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
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnLogin = new Button();
            btnClose = new Label();
            lblError = new Label();
            RegisterButton = new Button();
            ViewerButton = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(117, 89, 179);
            lblTitle.Location = new Point(79, 41);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(302, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SwissArmyKnife";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Nirmala UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.FromArgb(164, 165, 169);
            lblSubtitle.Location = new Point(133, 111);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(199, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Penetration Testing Suite";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(34, 140, 60);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(164, 254);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(130, 40);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Nirmala UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(164, 165, 169);
            btnClose.Location = new Point(412, 9);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 32);
            btnClose.TabIndex = 10;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.FromArgb(210, 70, 70);
            lblError.Location = new Point(50, 290);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 13;
            lblError.Visible = false;
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = Color.FromArgb(34, 140, 60);
            RegisterButton.Cursor = Cursors.Hand;
            RegisterButton.FlatAppearance.BorderSize = 0;
            RegisterButton.FlatStyle = FlatStyle.Flat;
            RegisterButton.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RegisterButton.ForeColor = Color.White;
            RegisterButton.Location = new Point(164, 322);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(130, 40);
            RegisterButton.TabIndex = 14;
            RegisterButton.Text = "REGISTER";
            RegisterButton.UseVisualStyleBackColor = false;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // ViewerButton
            // 
            ViewerButton.BackColor = Color.FromArgb(34, 140, 60);
            ViewerButton.Cursor = Cursors.Hand;
            ViewerButton.FlatAppearance.BorderSize = 0;
            ViewerButton.FlatStyle = FlatStyle.Flat;
            ViewerButton.Font = new Font("Nirmala UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ViewerButton.ForeColor = Color.White;
            ViewerButton.Location = new Point(97, 161);
            ViewerButton.Name = "ViewerButton";
            ViewerButton.Size = new Size(260, 66);
            ViewerButton.TabIndex = 15;
            ViewerButton.Text = "VIEW AVAILABLE REPORTS";
            ViewerButton.UseVisualStyleBackColor = false;
            ViewerButton.Click += ViewerButton_Click;
            // 
            // HomepageForm
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 38);
            ClientSize = new Size(459, 509);
            Controls.Add(ViewerButton);
            Controls.Add(RegisterButton);
            Controls.Add(lblError);
            Controls.Add(btnClose);
            Controls.Add(btnLogin);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HomepageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - SwissArmyKnife";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Label lblTitle;
        private Label lblSubtitle;
        private Button btnLogin;
        private Label btnClose;
        private Label lblError;
        private Button RegisterButton;
        private Button ViewerButton;
    }
}


