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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            openFileBtn = new Button();
            pictureBoxAlbum = new PictureBox();
            rewindBtn = new Button();
            pauseBtn = new Button();
            playBtn = new Button();
            fastForwardBtn = new Button();
            stopBtn = new Button();
            songTitleLabel = new Label();
            progressBar = new ProgressBar();
            exitBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlbum).BeginInit();
            SuspendLayout();
            // 
            // openFileBtn
            // 
            openFileBtn.BackColor = SystemColors.ControlLight;
            openFileBtn.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            openFileBtn.Location = new Point(41, 138);
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new Size(240, 59);
            openFileBtn.TabIndex = 0;
            openFileBtn.Text = "📂 Open Media File";
            openFileBtn.UseVisualStyleBackColor = false;
            openFileBtn.Click += openFileBtn_Click;
            // 
            // pictureBoxAlbum
            // 
            pictureBoxAlbum.BackgroundImage = (Image)resources.GetObject("pictureBoxAlbum.BackgroundImage");
            pictureBoxAlbum.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxAlbum.Location = new Point(41, 253);
            pictureBoxAlbum.MaximumSize = new Size(240, 240);
            pictureBoxAlbum.MinimumSize = new Size(240, 240);
            pictureBoxAlbum.Name = "pictureBoxAlbum";
            pictureBoxAlbum.Size = new Size(240, 240);
            pictureBoxAlbum.TabIndex = 1;
            pictureBoxAlbum.TabStop = false;
            // 
            // rewindBtn
            // 
            rewindBtn.BackColor = Color.Transparent;
            rewindBtn.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rewindBtn.Location = new Point(362, 492);
            rewindBtn.Name = "rewindBtn";
            rewindBtn.Size = new Size(147, 41);
            rewindBtn.TabIndex = 2;
            rewindBtn.Text = "<<";
            rewindBtn.UseVisualStyleBackColor = false;
            rewindBtn.Click += rewindBtn_Click;
            // 
            // pauseBtn
            // 
            pauseBtn.BackColor = Color.Transparent;
            pauseBtn.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            pauseBtn.Location = new Point(515, 492);
            pauseBtn.Name = "pauseBtn";
            pauseBtn.Size = new Size(147, 41);
            pauseBtn.TabIndex = 3;
            pauseBtn.Text = "||";
            pauseBtn.UseVisualStyleBackColor = false;
            pauseBtn.Click += pauseBtn_Click;
            // 
            // playBtn
            // 
            playBtn.BackColor = Color.Transparent;
            playBtn.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            playBtn.Location = new Point(668, 492);
            playBtn.Name = "playBtn";
            playBtn.Size = new Size(147, 41);
            playBtn.TabIndex = 4;
            playBtn.Text = "▶";
            playBtn.UseVisualStyleBackColor = false;
            playBtn.Click += playBtn_Click;
            // 
            // fastForwardBtn
            // 
            fastForwardBtn.BackColor = Color.Transparent;
            fastForwardBtn.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            fastForwardBtn.Location = new Point(821, 492);
            fastForwardBtn.Name = "fastForwardBtn";
            fastForwardBtn.Size = new Size(147, 41);
            fastForwardBtn.TabIndex = 5;
            fastForwardBtn.Text = ">>";
            fastForwardBtn.UseVisualStyleBackColor = false;
            fastForwardBtn.Click += fastForwardBtn_Click;
            // 
            // stopBtn
            // 
            stopBtn.BackColor = Color.Transparent;
            stopBtn.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            stopBtn.Location = new Point(974, 492);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(147, 41);
            stopBtn.TabIndex = 6;
            stopBtn.Text = "◼️";
            stopBtn.UseVisualStyleBackColor = false;
            stopBtn.Click += stopBtn_Click;
            // 
            // songTitleLabel
            // 
            songTitleLabel.AutoSize = true;
            songTitleLabel.BackColor = Color.Transparent;
            songTitleLabel.Font = new Font("Consolas", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            songTitleLabel.Location = new Point(362, 376);
            songTitleLabel.Name = "songTitleLabel";
            songTitleLabel.Size = new Size(0, 27);
            songTitleLabel.TabIndex = 7;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(362, 455);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(759, 17);
            progressBar.TabIndex = 8;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = SystemColors.ControlLight;
            exitBtn.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            exitBtn.Location = new Point(974, 138);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(240, 59);
            exitBtn.TabIndex = 9;
            exitBtn.Text = "❌ Exit Application";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1262, 673);
            Controls.Add(exitBtn);
            Controls.Add(progressBar);
            Controls.Add(songTitleLabel);
            Controls.Add(stopBtn);
            Controls.Add(fastForwardBtn);
            Controls.Add(playBtn);
            Controls.Add(pauseBtn);
            Controls.Add(rewindBtn);
            Controls.Add(pictureBoxAlbum);
            Controls.Add(openFileBtn);
            DoubleBuffered = true;
            MaximumSize = new Size(1280, 720);
            MinimumSize = new Size(1280, 720);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBoxAlbum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openFileBtn;
        private PictureBox pictureBoxAlbum;
        private Button rewindBtn;
        private Button pauseBtn;
        private Button playBtn;
        private Button fastForwardBtn;
        private Button stopBtn;
        private Label songTitleLabel;
        private ProgressBar progressBar;
        private Button exitBtn;
    }
}