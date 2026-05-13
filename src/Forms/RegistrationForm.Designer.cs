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
            LoginForm = new Button();
            SuspendLayout();
            // 
            // LoginForm
            // 
            LoginForm.Location = new Point(264, 224);
            LoginForm.Name = "LoginForm";
            LoginForm.Size = new Size(174, 85);
            LoginForm.TabIndex = 0;
            LoginForm.Text = "Login";
            LoginForm.UseVisualStyleBackColor = true;
            LoginForm.Click += this.LoginForm_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LoginForm);
            Name = "RegistrationForm";
            Text = "Registration";
            ResumeLayout(false);
        }

        #endregion

        private Button LoginForm;
    }
}
