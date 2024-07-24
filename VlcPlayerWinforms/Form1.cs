using AxWMPLib;
using Microsoft.VisualBasic.ApplicationServices;
using VlcPlayerWinforms.CustomControls;
using WMPLib;
using static System.Net.Mime.MediaTypeNames;

namespace VlcPlayerWinforms
{
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadMedia("https://www.learningcontainer.com/wp-content/uploads/2020/05/sample-mp4-file.mp4");

            // init Queue Panel
            QueuePanel.AutoScroll = true;
            for (int i = 0; i < 30; i++)
            {
                PictureBox b = new PictureBox();
                b.Size = new Size(200, 50);
                b.SizeMode = PictureBoxSizeMode.StretchImage;
                b.Image = System.Drawing.Image.FromFile("C:\\Users\\tigro\\source\\repos\\VlcPlayerWinforms\\VlcPlayerWinforms\\img\\test.png");
                b.Click += ListPictureBox_Click;

                QueuePanel.Controls.Add(b);
            }

            timerMouseMovement.Enabled = false;

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
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    isFullScreen = true;
                }
            }
            else
            {
                if (!(bool)explicitModify)
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    isFullScreen = false;
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    isFullScreen = true;
                }
            }

        }

        private void ListPictureBox_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Hey");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point curPos = MousePosition;
            if (curPos.Equals(precedentMousePosition))
            {
                panelMediaControl.Hide();
            }
            else
            {
                panelMediaControl.Show();
            }
            precedentMousePosition = curPos;
        }

        private void vlcControl1_MouseEnter(object sender, EventArgs e)
        {
            timerMouseMovement.Enabled = true;
        }

        private void vlcControl1_MouseLeave(object sender, EventArgs e)
        {
            timerMouseMovement.Enabled = false;
            panelMediaControl.Show();
        }

        private void vlcControl1_DoubleClick(object sender, EventArgs e)
        {
            ModifyFullScreen(null);
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

                case Keys.Left:
                    //vlcControl.Time += 10;
                    break;

                case Keys.Right:
                    //vlcControl.Time -= 10;
                    break;

            }

        }

        private void playPictureBox_Click(object sender, EventArgs? e)
        {
            if (windowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                windowsMediaPlayer.Ctlcontrols.pause();
                playPictureBox.BackgroundImage = Properties.Resources.play_50px;
            }
            else
            {
                windowsMediaPlayer.Ctlcontrols.play();
                playPictureBox.BackgroundImage = Properties.Resources.pause_50px;
            }
        }

        private async void loadMedia(string url)
        {
            windowsMediaPlayer.URL = url;

            //time to load media
            await Task.Delay(1);

            //TimeSpan totalT = vlcControl.GetCurrentMedia().Duration;
            //labelTotalMediaTime.Text = TimeSpan2String(totalT);

            // init progress bar
            //totalSeconds = (int)totalT.TotalSeconds;
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
                //TimeSpan curT = new TimeSpan((int)(Math.Round(vlcControl.Position, 2) * 100) * 10000000);

                //labelCurrentMediaTime.Text = TimeSpan2String(curT);

                // Update progress bar
                //mediaCustomProgressBar.Value = (int)(Math.Round(vlcControl.Position, 2) * 100);

            }
        }

        private String TimeSpan2String(TimeSpan timeSpan)
        {
            return $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }

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
            //vlcControl.Stop();
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
    }
}
