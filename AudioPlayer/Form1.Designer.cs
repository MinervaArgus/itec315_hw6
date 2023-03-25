namespace AudioPlayer
{
    partial class Form1
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
            openFileBtn = new Button();
            SuspendLayout();
            // 
            // openFileBtn
            // 
            openFileBtn.BackColor = SystemColors.ControlLight;
            openFileBtn.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            openFileBtn.Location = new Point(1017, 41);
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new Size(191, 59);
            openFileBtn.TabIndex = 0;
            openFileBtn.Text = "📂 Open File";
            openFileBtn.UseVisualStyleBackColor = false;
            openFileBtn.Click += openFileBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1262, 673);
            Controls.Add(openFileBtn);
            MaximumSize = new Size(1280, 720);
            MinimumSize = new Size(1280, 720);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button openFileBtn;
    }
}