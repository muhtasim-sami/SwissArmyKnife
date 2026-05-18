namespace SwissArmyKnife
{
    partial class ReportViewerForm
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
        private void InitializeComponent(string title, string content)
        {
            RegistrationForm = new Button();
            DashboardButton = new Button();
            SuspendLayout();
            // 
            // RegistrationForm
            // 
            RegistrationForm.Location = new Point(269, 171);
            RegistrationForm.Name = "RegistrationForm";
            RegistrationForm.Size = new Size(205, 59);
            RegistrationForm.TabIndex = 0;
            RegistrationForm.Text = "Sign Up";
            RegistrationForm.UseVisualStyleBackColor = true;
            RegistrationForm.Click += RegistrationForm_Click;
            // 
            // DashboardButton
            // 
            DashboardButton.Location = new Point(269, 262);
            DashboardButton.Name = "DashboardButton";
            DashboardButton.Size = new Size(205, 70);
            DashboardButton.TabIndex = 1;
            DashboardButton.Text = "Dashboard";
            DashboardButton.UseVisualStyleBackColor = true;
            DashboardButton.Click += DashboardButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DashboardButton);
            Controls.Add(RegistrationForm);
            Name = "LoginForm";
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            // 
            // Title
            // 
            Text = title;
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(30, 30, 38);
            // 
            // RegistrationForm
            //
            rtbContent = new RichTextBox();
            rtbContent.Dock = DockStyle.Fill;
            rtbContent.BackColor = Color.FromArgb(18, 18, 22);
            rtbContent.ForeColor = Color.FromArgb(220, 220, 230);
            rtbContent.Font = new Font("Consolas", 10F);
            rtbContent.ReadOnly = true;
            rtbContent.Text = content;
            // 
            // RegistrationForm
            // 
            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.BackColor = Color.FromArgb(60, 60, 70);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(350, 520);
            btnClose.Click += (s, e) => Close();

            Controls.Add(rtbContent);
            Controls.Add(btnClose);
        }

        #endregion

        private Button RegistrationForm;
        private Button DashboardButton;
    }
}
