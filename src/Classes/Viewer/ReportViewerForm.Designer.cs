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

        private RichTextBox rtbContent;
        private Button btnClose;
    }
}
