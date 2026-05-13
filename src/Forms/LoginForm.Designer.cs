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
            RegistrationForm = new Button();
            SuspendLayout();
            // 
            // RegistrationForm
            // 
            RegistrationForm.Location = new Point(273, 222);
            RegistrationForm.Name = "RegistrationForm";
            RegistrationForm.Size = new Size(201, 93);
            RegistrationForm.TabIndex = 0;
            RegistrationForm.Text = "Sign Up";
            RegistrationForm.UseVisualStyleBackColor = true;
            RegistrationForm.Click += RegistrationForm_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RegistrationForm);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
        }

        #endregion

        private Button RegistrationForm;
    }
}
