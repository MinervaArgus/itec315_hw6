namespace AudioPlayer
{
    using NAudio.Wave;
    using NetCoreAudio; //Allows the media to be played
    using System; // Need this for every app
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    using System.ComponentModel;
    using TagLib;
    using NAudio.Wave.SampleProviders;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;

    public partial class Form1 : Form
    {
        private WaveOutEvent waveOut;
        private IWaveProvider audioFileReader;
        private Player player;
        private string currentFilePath;
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
        }

        // Initializes the Audio Player and assigns all the instance variables to their values
        private void IntializeAudioPlayer()
        {
            player = new Player();
            waveOut = new WaveOutEvent();
            waveOut.PlaybackStopped += OnPlaybackStopped;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += UpdateProgressBar;
        }

        private void OnPlaybackStopped(object sender, EventArgs e)
        {
            UpdateUIForStoppedPlayback();
        }

        private void UpdateUIForStoppedPlayback()
        {
            playBtn.Enabled = true;
            pauseBtn.Enabled = false;
            stopBtn.Enabled = false;
            rewindBtn.Enabled = false;
            fastForwardBtn.Enabled = false;
            progressBar.Value = 0;

        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files| *.mp3;*.wav"; // Filters for 2 of the 7 File Formats as required

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                LoadAudioFile();
                UpdateUIForNewFile();
            }
        }

        // Loads the provided audio file 
        private void LoadAudioFile()
        {
            if (audioFileReader != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = new WaveOutEvent();
                waveOut.PlaybackStopped += OnPlaybackStopped;
            }

            using (var tempReader = new AudioFileReader(currentFilePath))
            {
                audioFileReader = new SampleToWaveProvider(tempReader);
                waveOut.Init(audioFileReader);
            }

            var tagFile = TagLib.File.Create(currentFilePath);
            songTitleLabel.Text = tagFile.Tag.Title ?? Path.GetFileNameWithoutExtension(currentFilePath);

            if (tagFile.Tag.Pictures.Length > 0)
            {
                var albumImage = tagFile.Tag.Pictures[0];
                using (var stream = new MemoryStream(albumImage.Data.Data))
                {
                    pictureBoxAlbum.Image = Image.FromStream(stream);
                }
            }
            else
            {
                pictureBoxAlbum.Image = null;
            }
        }

        private void UpdateUIForNewFile()
        {
            playBtn.Enabled = true; // Enable Play btn for new song
            pauseBtn.Enabled = true; // Enable Pause btn for new song
            stopBtn.Enabled = true; // Enable Stop btn for new song
            rewindBtn.Enabled = true; // Enable Rewind btn for new song
            fastForwardBtn.Enabled = true; // Enable Fast Forward btn for new song
            progressBar.Value = 0; // Set the Progress Bar to 0 for new song

            // Update the title of the song
            songTitleLabel.Text = Path.GetFileNameWithoutExtension(currentFilePath);
        }
    }
}