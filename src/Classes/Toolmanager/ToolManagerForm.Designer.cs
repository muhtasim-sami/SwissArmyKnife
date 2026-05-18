namespace SwissArmyKnife
{
    partial class ToolManagerForm
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
        }

        #endregion

        private Button RegistrationForm;
        private Button DashboardButton;
    }
}
