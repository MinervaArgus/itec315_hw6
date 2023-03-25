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


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {

        }
    }
}