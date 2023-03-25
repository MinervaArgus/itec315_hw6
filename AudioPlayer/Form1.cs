/*
 * HW6 ITEC 315
 * Jackson Nevins
 * 03/15/23
 * 
 * Purpose:
 * Audio Player that plays the selected file
 * 
 * Sources:
 * NAudio Documentation: https://github.com/naudio/NAudio/blob/master/Docs/PlayAudioFileWinForms.md
 * NetCoreAudio Documentation: https://github.com/mobiletechtracker/NetCoreAudio
 * TagLib# Documentation: https://github.com/mono/taglib-sharp
 * OpenFileDialog Filter Documentation: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.filedialog.filter?view=windowsdesktop-7.0
 * Form Closing Event: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.form.formclosing?view=windowsdesktop-7.0
 */



namespace AudioPlayer
{
    using NAudio.Wave; // Allows easy functions for music
    using NetCoreAudio; //Allows the media to be played
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    using System.ComponentModel;
    using TagLib; // Needed for the metadata of the loaded file
    using NAudio.Wave.SampleProviders;

    public partial class Form1 : Form
    {
        private WaveOutEvent? waveOut; // ? to make it nullable 
        private AudioFileReader? audioFileReader;
        private Player player;
        private string currentFilePath;
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
            InitializeAudioPlayer();
        }

        // Initializes the Audio Player and assigns all the instance variables to their values
        private void InitializeAudioPlayer()
        {
            player = new Player();
            waveOut = new WaveOutEvent();
            waveOut.PlaybackStopped += OnPlaybackStopped;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += UpdateProgressBar;
            timer.Enabled = true;
        }

        private void OnPlaybackStopped(object? sender, EventArgs e)
        {
            UpdateUIForStoppedPlayback();
            timer.Stop();
        }

        // Disables every button except play 
        private void UpdateUIForStoppedPlayback()
        {
            playBtn.Enabled = true;
            pauseBtn.Enabled = false;
            stopBtn.Enabled = false;
            rewindBtn.Enabled = false;
            fastForwardBtn.Enabled = false;

        }

        // Enables every button except for the play button
        private void UpdateUIForPlaying()
        {
            playBtn.Enabled = false;
            pauseBtn.Enabled = true;
            stopBtn.Enabled = true;
            rewindBtn.Enabled = true;
            fastForwardBtn.Enabled = true;
        }

        // Pulls up the File Browser to open a local .mp3 or .wav file
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
                waveOut.PlaybackStopped -= OnPlaybackStopped;
                waveOut.Dispose();

                if (audioFileReader is AudioFileReader audioFileReaderToDispose)
                {
                    audioFileReaderToDispose.Dispose();
                }

                waveOut = new WaveOutEvent();
                waveOut.PlaybackStopped += OnPlaybackStopped;
            }

            audioFileReader = new AudioFileReader(currentFilePath);
            waveOut.Init(new SampleToWaveProvider(audioFileReader));

            var tagFile = TagLib.File.Create(currentFilePath);
            songTitleLabel.Text = tagFile.Tag.Title ?? Path.GetFileNameWithoutExtension(currentFilePath);

            if (tagFile.Tag.Pictures.Length > 0)
            {
                pictureBoxAlbum.BackgroundImage = null; // Clear the default album image if there is an album image detected from the Metadata
                var albumImage = tagFile.Tag.Pictures[0]; // Set the image of the album to the metadata album cover
                using (var stream = new MemoryStream(albumImage.Data.Data))
                {
                    pictureBoxAlbum.Image = Image.FromStream(stream);
                }
            }
        }

        // Updates the buttons when a new file is loaded and loads album cover if there is one
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

        // Rewinds the song 5 seconds and updates the progress bar
        private void rewindBtn_Click(object sender, EventArgs e)
        {
            if (audioFileReader is AudioFileReader audioFileReaderToRewind)
            {
                int rewindMilliseconds = 5000; // Rewind by 5 seconds
                long newPosition = audioFileReaderToRewind.Position - audioFileReaderToRewind.WaveFormat.AverageBytesPerSecond * rewindMilliseconds / 1000;
                newPosition = Math.Max(newPosition, 0);
                audioFileReaderToRewind.Position = newPosition;
            }
        }

        // Pauses the song
        private void pauseBtn_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Pause();
                timer.Stop();
                UpdateUIForStoppedPlayback();
            }
        }

        // Plays the song/ resumes the song
        private void playBtn_Click(object sender, EventArgs e)
        {
            if (waveOut != null && audioFileReader != null)
            {
                waveOut.Play();// Play the opened audio file
                timer.Start(); // Start the timer for the progress bar
                UpdateUIForPlaying(); // Disables the play button and enables the rest of the buttons
            }
        }

        // Fast forwards the song 5 seconds and updates the progress bar
        private void fastForwardBtn_Click(object sender, EventArgs e)
        {
            if (audioFileReader is AudioFileReader audioFileReaderToRewind)
            {
                int forwardMilliseconds = 5000; // Fast forward by 5 seconds
                long newPosition = audioFileReaderToRewind.Position + audioFileReaderToRewind.WaveFormat.AverageBytesPerSecond * forwardMilliseconds / 1000;
                newPosition = Math.Max(newPosition, 0);
                audioFileReaderToRewind.Position = newPosition;
            }
        }

        // Stops the track and resets it to the start
        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                timer.Stop();
                if (audioFileReader != null)
                {
                    audioFileReader.Position = 0;
                }
                UpdateProgressBar(null, null);
            }
        }

        // Exits the application
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Updates the progress bar to keep track of the amount of the song played
        private void UpdateProgressBar(object? sender, EventArgs? e)
        {
            if (audioFileReader is AudioFileReader audioFileReaderToUpdate)
            {
                progressBar.Maximum = (int)(audioFileReaderToUpdate.Length / audioFileReaderToUpdate.WaveFormat.BlockAlign);
                progressBar.Value = (int)(audioFileReaderToUpdate.Position / audioFileReaderToUpdate.WaveFormat.BlockAlign);
            }
        }

        // Need this to make sure no resources are left undisposed of or running processes that do not need to stay running
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Dispose();
                waveOut = null;
            }
            if (audioFileReader is AudioFileReader audioFileReaderToDispose)
            {
                audioFileReaderToDispose.Dispose();
                audioFileReader = null;
            }
        }
    }
}