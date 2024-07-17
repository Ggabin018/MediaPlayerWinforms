using Microsoft.VisualBasic.ApplicationServices;
using static System.Net.Mime.MediaTypeNames;

namespace VlcPlayerWinforms
{
    public partial class MainForm : Form
    {
        // attributes
        Point precedentMousePosition = new Point(0, 0);
        bool isFullScreen = false;
        bool isPlaying = false;
        int totalSeconds = 0;

        public MainForm()
        {
            //vlcControl.VlcLibDirectory = new DirectoryInfo("C:\\Program Files\\VideoLAN\\VLC");
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadMedia(new Uri("https://www.learningcontainer.com/wp-content/uploads/2020/05/sample-mp4-file.mp4"));
            
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
                    TopMost = false;
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    isFullScreen = false;
                }
                else
                {
                    TopMost = true;
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    isFullScreen = true;
                }
            }
            else
            {
                if (!(bool)explicitModify)
                {
                    TopMost = false;
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    isFullScreen = false;
                }
                else
                {
                    TopMost = true;
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

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //video pause
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                if (!isFullScreen)
                {
                    ModifyFullScreen(true);
                }
            }
            else
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point curPos = MousePosition;
            if (curPos.Equals(precedentMousePosition))
            {
                //playPictureBox.Hide();
                //stopPictureBox.Hide();
                panelMediaControl.Hide();
            }
            else
            {
                //playPictureBox.Show();
                //stopPictureBox.Show();
                panelMediaControl.Show();
            }
            precedentMousePosition = curPos;
            //labelTimerTest.Text = precedentMousePosition.ToString();
        }

        private void vlcControl1_MouseEnter(object sender, EventArgs e)
        {
            timerMouseMovement.Enabled = true;
        }

        private void vlcControl1_MouseLeave(object sender, EventArgs e)
        {
            timerMouseMovement.Enabled = false;
            //playPictureBox.Show();
            //stopPictureBox.Show();
            panelMediaControl.Show();
        }

        private void vlcControl1_DoubleClick(object sender, EventArgs e)
        {
            ModifyFullScreen(null);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ModifyFullScreen(false);
            }
            else if (e.KeyCode == Keys.Space)
            {
                playPictureBox_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F11)
            {
                ModifyFullScreen(null);
            }
        }

        private void playPictureBox_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                isPlaying = false;
                vlcControl.Pause();
                playPictureBox.BackgroundImage = Properties.Resources.play_50px;
            }
            else
            {
                isPlaying = true;
                vlcControl.Pause();
                playPictureBox.BackgroundImage = Properties.Resources.pause_50px;
            }
        }

        private async void loadMedia(Uri uri)
        {
            vlcControl.Play(uri);
            isPlaying = true;

            //time to load media
            await Task.Delay(1);

            TimeSpan totalT = vlcControl.GetCurrentMedia().Duration;
            labelTotalMediaTime.Text = timeSpan2String(totalT);

            // init progress bar
            totalSeconds = (int)totalT.TotalSeconds;
            mediaProgressBar.Maximum = totalSeconds*10; // updateMediaTime = 100 ms, but we want 1 second
            mediaProgressBar.Minimum = 0;
            mediaProgressBar.Value = 0;
            mediaProgressBar.Step = 1;

        }

        private void updateMediaTime_Tick(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                /// BUG ON DISPLAY CURT, LATE ON REALTIME
                // Update media time display
                TimeSpan curT = new TimeSpan((int)(Math.Round(vlcControl.Position, 2) * 100) * 10000000); 
                labelCurrentMediaTime.Text = timeSpan2String(curT);

                // Update progress bar
                mediaProgressBar.PerformStep();

            }
        }

        private String timeSpan2String(TimeSpan timeSpan)
        {
            return String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours,timeSpan.Minutes, timeSpan.Seconds);
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
            vlcControl.Stop();
        }

        private void vlcControl_Click(object sender, EventArgs e)
        {
            playPictureBox_Click(sender, e);
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
    }
}
