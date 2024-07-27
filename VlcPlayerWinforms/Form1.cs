using AxWMPLib;
using Microsoft.VisualBasic.ApplicationServices;
using VlcPlayerWinforms.CustomControls;
using WMPLib;
using static System.Net.Mime.MediaTypeNames;

namespace VlcPlayerWinforms
{
    public enum TimeChange
    {
        Add,
        Sub,
        Set
    }
    public partial class MainForm : Form
    {
        // attributes
        Point precedentMousePosition = new Point(0, 0);
        bool isFullScreen = false;
        int totalSeconds = 0;


        public MainForm()
        {
            InitializeComponent();

            windowsMediaPlayer.uiMode = "none";
            windowsMediaPlayer.stretchToFit = true;
            mediaCustomProgressBar.MediaPlayer = windowsMediaPlayer;
            mediaPlayerSlider.MediaPlayer = windowsMediaPlayer;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /// NEED MODIFICATION
            LoadFilesInQueuePanel();

        }

        /// NEED MODIFICATION
        private void LoadFilesInQueuePanel()
        {
            QueuePanel.AutoScroll = true;
            Size boxSize = new(200, 50);
            for (int i = 0; i < 30; i++)
            {
                PictureBox b = new()
                {
                    Size = boxSize,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Properties.Resources.test
                };
                b.Click += ListPictureBox_Click;

                QueuePanel.Controls.Add(b);
            }
        }

        private void ModifyFullScreen(bool? explicitModify)
        {
            if (explicitModify == null)
            {
                if (isFullScreen)
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    isFullScreen = false;
                    menuStrip.Show();
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    isFullScreen = true;
                    menuStrip.Hide();
                }
            }
            else
            {
                if (!(bool)explicitModify)
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    isFullScreen = false;
                    menuStrip.Show();
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    isFullScreen = true;
                    menuStrip.Hide();
                }
            }

        }

        private void ListPictureBox_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Hey");
        }

        private void timerMouvementMouse_Tick(object sender, EventArgs e)
        {
            Point curPos = MousePosition;

            Point clientPos = PointToClient(MousePosition);
            if (clientPos.Y > windowsMediaPlayer.Location.Y && clientPos.Y < windowsMediaPlayer.Location.Y + windowsMediaPlayer.Height &&
                clientPos.X > windowsMediaPlayer.Location.X && clientPos.X < windowsMediaPlayer.Location.X + windowsMediaPlayer.Width)
            {
                if (curPos.Equals(precedentMousePosition))
                {
                    Cursor.Hide();
                    panelMediaControl.Hide();
                }
                else
                {
                    Cursor.Show();
                    panelMediaControl.Show();
                }
                precedentMousePosition = curPos;
            }
            
        }

        private void SetTime(int time, TimeChange status)
        {
            switch (status)
            {
                case TimeChange.Add:
                    if (windowsMediaPlayer.Ctlcontrols.currentPosition + time < windowsMediaPlayer.currentMedia.duration)
                    {
                        windowsMediaPlayer.Ctlcontrols.currentPosition += time;
                        mediaCustomProgressBar.Value += time;
                    }
                    else
                    {
                        windowsMediaPlayer.Ctlcontrols.currentPosition = windowsMediaPlayer.currentMedia.duration;
                        mediaCustomProgressBar.Value = (int)windowsMediaPlayer.currentMedia.duration;
                    }
                    break;
                case TimeChange.Sub:
                    if (windowsMediaPlayer.Ctlcontrols.currentPosition - time >= 0)
                    {
                        windowsMediaPlayer.Ctlcontrols.currentPosition -= time;
                        mediaCustomProgressBar.Value -= time;
                    }
                    else
                    {
                        windowsMediaPlayer.Ctlcontrols.currentPosition = 0;
                        mediaCustomProgressBar.Value = 0;
                    }
                    break;
                case TimeChange.Set:
                    if (time < windowsMediaPlayer.currentMedia.duration)
                    {
                        windowsMediaPlayer.Ctlcontrols.currentPosition = time;
                        mediaCustomProgressBar.Value = time;
                    }
                    break;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    ModifyFullScreen(false);
                    break;

                case Keys.Space:
                    playPictureBox_Click(sender, e);
                    break;

                case Keys.F11:
                    ModifyFullScreen(null);
                    break;

                case Keys.Right:
                    SetTime(10, TimeChange.Add);
                    break;

                case Keys.Left:
                    SetTime(10, TimeChange.Sub);
                    break;

                case Keys.Up:
                    windowsMediaPlayer.settings.volume += 5;
                    break;

                case Keys.Down:
                    windowsMediaPlayer.settings.volume -= 5;
                    break;

                case Keys.NumPad0:
                case Keys.D0:
                    SetTime(0, TimeChange.Set);
                    break;

                case Keys.NumPad1:
                case Keys.D1:
                    SetTime((int)(windowsMediaPlayer.currentMedia.duration * 0.1), TimeChange.Set);
                    break;

                case Keys.NumPad2:
                case Keys.D2:
                    SetTime((int)(windowsMediaPlayer.currentMedia.duration * 0.2), TimeChange.Set);
                    break;

                case Keys.NumPad3:
                case Keys.D3:
                    SetTime((int)(windowsMediaPlayer.currentMedia.duration * 0.3), TimeChange.Set);
                    break;

                case Keys.NumPad4:
                case Keys.D4:
                    SetTime((int)(windowsMediaPlayer.currentMedia.duration * 0.4), TimeChange.Set);
                    break;

                case Keys.NumPad5:
                case Keys.D5:
                    SetTime((int)(windowsMediaPlayer.currentMedia.duration * 0.5), TimeChange.Set);
                    break;

                case Keys.NumPad6:
                case Keys.D6:
                    SetTime((int)(windowsMediaPlayer.currentMedia.duration * 0.6), TimeChange.Set);
                    break;

                case Keys.NumPad7:
                case Keys.D7:
                    SetTime((int)(windowsMediaPlayer.currentMedia.duration * 0.7), TimeChange.Set);
                    break;

                case Keys.NumPad8:
                case Keys.D8:
                    SetTime((int)(windowsMediaPlayer.currentMedia.duration * 0.8), TimeChange.Set);
                    break;

                case Keys.NumPad9:
                case Keys.D9:
                    SetTime((int)(windowsMediaPlayer.currentMedia.duration * 0.9), TimeChange.Set);
                    break;
            }

        }

        private void playPictureBox_Click(object sender, EventArgs? e)
        {
            if (windowsMediaPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                windowsMediaPlayer.Ctlcontrols.pause();
                playPictureBox.BackgroundImage = Properties.Resources.play_50px;
            }
            else if (windowsMediaPlayer.playState == WMPPlayState.wmppsPaused)
            {
                windowsMediaPlayer.Ctlcontrols.play();
                playPictureBox.BackgroundImage = Properties.Resources.pause_50px;
            }
            else
            {
                // init media player + progress bar
                loadMedia("https://www.learningcontainer.com/wp-content/uploads/2020/05/sample-mp4-file.mp4");
            }
        }

        private async void loadMedia(string url)
        {
            windowsMediaPlayer.URL = url;

            //time to load media
            await Task.Delay(1000);

            double duration = windowsMediaPlayer.currentMedia.duration;
            labelTotalMediaTime.Text = $"{TimeSpan.FromSeconds(duration):hh\\:mm\\:ss}";

            // init progress bar
            totalSeconds = (int)duration;
            mediaCustomProgressBar.Maximum = totalSeconds;
            mediaCustomProgressBar.Minimum = 0;
            mediaCustomProgressBar.Value = 0;
            mediaCustomProgressBar.Step = 1;


        }

        private void updateMediaTime_Tick(object sender, EventArgs e)
        {
            if (windowsMediaPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                /// BUG ON DISPLAY CURT, LATE ON REALTIME
                // Update media time display
                double currentPosition = windowsMediaPlayer.Ctlcontrols.currentPosition;
                labelCurrentMediaTime.Text = $"{TimeSpan.FromSeconds(currentPosition):hh\\:mm\\:ss}";

                // Update progress bar
                mediaCustomProgressBar.Value = (int)currentPosition;

            }
        }

        /// NEED MODIFICATION
        private void ouvrirUnFichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            Text = filePath;
            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void stopPictureBox_Click(object sender, EventArgs e)
        {
            windowsMediaPlayer.Ctlcontrols.stop();
        }

        private void queuePictureBox_Click(object sender, EventArgs e)
        {
            if (QueuePanel.Visible)
            {
                QueuePanel.Hide();
            }
            else
            {
                QueuePanel.Show();
            }

        }

        private void windowsMediaPlayer_MouseUpEvent(object sender, _WMPOCXEvents_MouseUpEvent e)
        {
            playPictureBox_Click(sender, null);
        }

        private void windowsMediaPlayer_DoubleClickEvent(object sender, _WMPOCXEvents_DoubleClickEvent e)
        {
            ModifyFullScreen(null);
        }
    }
}
