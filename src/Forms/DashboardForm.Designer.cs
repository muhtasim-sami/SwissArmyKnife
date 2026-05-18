namespace SwissArmyKnife
{
    partial class DashboardForm
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
            PentestToolKitForm = new Button();
            WebSecurityAuditButton = new Button();
            SuspendLayout();
            // 
            // PentestToolKitForm
            // 
            PentestToolKitForm.Location = new Point(285, 143);
            PentestToolKitForm.Name = "PentestToolKitForm";
            PentestToolKitForm.Size = new Size(174, 85);
            PentestToolKitForm.TabIndex = 0;
            PentestToolKitForm.Text = "Network Scanning";
            PentestToolKitForm.UseVisualStyleBackColor = true;
            PentestToolKitForm.Click += NerworkScannerForm_Click;
            // 
            // WebSecurityAuditButton
            // 
            WebSecurityAuditButton.Location = new Point(285, 265);
            WebSecurityAuditButton.Name = "WebSecurityAuditButton";
            WebSecurityAuditButton.Size = new Size(174, 75);
            WebSecurityAuditButton.TabIndex = 1;
            WebSecurityAuditButton.Text = "Web Testing";
            WebSecurityAuditButton.UseVisualStyleBackColor = true;
            WebSecurityAuditButton.Click += WebSecurityAuditButton_Click;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(WebSecurityAuditButton);
            Controls.Add(PentestToolKitForm);
            Name = "DashboardForm";
            Text = "Dashboard";
            Load += NerworkScannerForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button PentestToolKitForm;
        private Button WebSecurityAuditButton;
    }
}
