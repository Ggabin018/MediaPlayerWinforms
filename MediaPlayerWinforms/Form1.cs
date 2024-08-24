using System.Diagnostics;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace MediaPlayerWinforms
{
    public enum ValueChange
    {
        Add,
        Sub,
        Set
    }
    public partial class MainForm : Form
    {
        // attributes
        Point precedentMousePosition = new(0, 0);
        bool isFullScreen = false;
        int totalSeconds = 0;
        LocalDatabase localDatabase = new();

        private static readonly Mutex mutexSetTime = new Mutex();
        private static readonly Mutex mutexSetVolume = new();


        public MainForm()
        {
            InitializeComponent();

            // Link event
            mediaCustomProgressBar.OnClickProgressBarForMediaPlayer += customMediaPlayer.OnClickProgressBarForMediaPlayer;
            mediaPlayerSlider.OnMouseDownForMediaPlayer += customMediaPlayer.OnMouseDownForMediaPlayer;
            customMediaPlayer.LocalDatabaseAddToHistoric += localDatabase.AddToHistoric;
            customMediaPlayer.InitProgressBar += mediaCustomProgressBar.InitProgressBar;
            customQueuePanel.LoadAndPlay += customMediaPlayer.LoadMediaAndPlay;
            customMediaPlayer.GoToThisVideoInQueuePanel += customQueuePanel.GoToThisVideoInQueuePanel;
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

        private void timerMouvementMouse_Tick(object sender, EventArgs e)
        {
            Point curPos = MousePosition;

            Point clientPos = PointToClient(MousePosition);
            if (clientPos.Y > customMediaPlayer.Location.Y && clientPos.Y < customMediaPlayer.Location.Y + customMediaPlayer.Height &&
                clientPos.X > customMediaPlayer.Location.X && clientPos.X < customMediaPlayer.Location.X + customMediaPlayer.Width)
            {

                if (curPos.Equals(precedentMousePosition))
                {
                    /// Cursor.Hide();
                    /// panelMediaControl.Hide();
                }
                else
                {
                    Cursor.Show();
                    panelMediaControl.Show();
                }
                precedentMousePosition = curPos;
            }

        }

        private void SetTime(int time, ValueChange status)
        {
            mutexSetTime.WaitOne();

            try
            {
                switch (status)
                {
                    case ValueChange.Add:
                        if (customMediaPlayer.PositionSeconds + time < customMediaPlayer.Duration)
                        {
                            customMediaPlayer.PositionSeconds += time;
                            mediaCustomProgressBar.Value += time;
                        }
                        else
                        {
                            customMediaPlayer.PositionSeconds = customMediaPlayer.Duration;
                            mediaCustomProgressBar.Value = (int)customMediaPlayer.Duration;
                        }
                        break;
                    case ValueChange.Sub:
                        if (customMediaPlayer.PositionSeconds - time >= 0)
                        {
                            customMediaPlayer.PositionSeconds -= time;
                            mediaCustomProgressBar.Value -= time;
                        }
                        else
                        {
                            customMediaPlayer.PositionSeconds = 0;
                            mediaCustomProgressBar.Value = 0;
                        }
                        break;
                    case ValueChange.Set:
                        if (time < customMediaPlayer.Duration)
                        {
                            customMediaPlayer.PositionSeconds = time;
                            mediaCustomProgressBar.Value = time;
                        }
                        break;
                }
            }
            finally { mutexSetTime.ReleaseMutex(); }

        }

        private void SetVolume(int value, ValueChange status)
        {
            // Bugfix audio go directly to 0
            mutexSetVolume.WaitOne();

            try
            {
                customMediaPlayer.Volume += value;
                mediaPlayerSlider.Value = customMediaPlayer.Volume;

                switch (status)
                {
                    case ValueChange.Add:
                        customMediaPlayer.Volume += value;
                        mediaPlayerSlider.Value = customMediaPlayer.Volume;
                        break;
                    case ValueChange.Sub:
                        customMediaPlayer.Volume -= value;
                        mediaPlayerSlider.Value = customMediaPlayer.Volume;
                        break;
                    case ValueChange.Set:
                        customMediaPlayer.Volume = value;
                        mediaPlayerSlider.Value = customMediaPlayer.Volume;
                        break;
                }
            }
            finally { mutexSetVolume.ReleaseMutex(); }
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
                case Keys.F:
                    ModifyFullScreen(null);
                    break;

                case Keys.Right:
                case Keys.D:
                    // forward skip in video
                    SetTime(int.Parse($"{forwardPictureBox.Tag}"), ValueChange.Add);
                    break;

                case Keys.Left:
                case Keys.Q:
                    // backward skip in video
                    SetTime(int.Parse($"{rewindPictureBox.Tag}"), ValueChange.Sub);
                    if (customMediaPlayer.IsPaused)
                    {
                        customMediaPlayer.Play(); /// BUG Come back to beginning
                    }
                    break;

                case Keys.Up:
                case Keys.Z:
                    SetVolume(5, ValueChange.Add);
                    break;

                case Keys.Down:
                case Keys.S:
                    SetVolume(5, ValueChange.Sub);
                    break;

                case Keys.A:
                    precedentPictureBox_Click(sender, e);
                    break;

                case Keys.E:
                    NextPictureBox_Click(sender, e);
                    break;

                case Keys.NumPad0:
                case Keys.D0:
                    SetTime(0, ValueChange.Set);
                    break;

                case Keys.NumPad1:
                case Keys.D1:
                    SetTime((int)(customMediaPlayer.Duration * 0.1), ValueChange.Set);
                    break;

                case Keys.NumPad2:
                case Keys.D2:
                    SetTime((int)(customMediaPlayer.Duration * 0.2), ValueChange.Set);
                    break;

                case Keys.NumPad3:
                case Keys.D3:
                    SetTime((int)(customMediaPlayer.Duration * 0.3), ValueChange.Set);
                    break;

                case Keys.NumPad4:
                case Keys.D4:
                    SetTime((int)(customMediaPlayer.Duration * 0.4), ValueChange.Set);
                    break;

                case Keys.NumPad5:
                case Keys.D5:
                    SetTime((int)(customMediaPlayer.Duration * 0.5), ValueChange.Set);
                    break;

                case Keys.NumPad6:
                case Keys.D6:
                    SetTime((int)(customMediaPlayer.Duration * 0.6), ValueChange.Set);
                    break;

                case Keys.NumPad7:
                case Keys.D7:
                    SetTime((int)(customMediaPlayer.Duration * 0.7), ValueChange.Set);
                    break;

                case Keys.NumPad8:
                case Keys.D8:
                    SetTime((int)(customMediaPlayer.Duration * 0.8), ValueChange.Set);
                    break;

                case Keys.NumPad9:
                case Keys.D9:
                    SetTime((int)(customMediaPlayer.Duration * 0.9), ValueChange.Set);
                    break;
            }

        }

        private void playPictureBox_Click(object sender, EventArgs? e)
        {
            if (customMediaPlayer.IsPlaying)
            {
                customMediaPlayer.Pause();
                playPictureBox.BackgroundImage = Properties.Resources.play_50px;
            }
            else if (customMediaPlayer.IsPaused)
            {
                customMediaPlayer.Play();
                playPictureBox.BackgroundImage = Properties.Resources.pause_50px;
            }
            else
            {
                // init media player + progress bar
                customMediaPlayer.LoadMediaAndPlay("https://www.learningcontainer.com/wp-content/uploads/2020/05/sample-mp4-file.mp4");
                //customMediaPlayer.LoadMediaAndPlay("C:\\Users\\tigro\\source\\repos\\MediaPlayerWinforms\\MediaPlayerWinforms\\tmp\\video.mp4");
            }
        }



        private void updateMediaTime_Tick(object sender, EventArgs e)
        {
            if (customMediaPlayer.IsPlaying)
            {
                // Update media time display
                double currentPosition = customMediaPlayer.PositionSeconds;
                labelCurrentMediaTime.Text = $"{TimeSpan.FromSeconds(currentPosition):hh\\:mm\\:ss}";

                // Update progress bar
                mediaCustomProgressBar.Value = (int)currentPosition;
            }
        }

        private void ouvrirUnFichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "video files|*.mp4;*.avi;*.mov;*.mkv;*.wmv;*.webm|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the _videoPath of specified file
                    filePath = openFileDialog.FileName;

                    customMediaPlayer.LoadMediaAndPlay(filePath);
                }
            }
        }

        private void ouvrirPlusieursFichiersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "video files|*.mp4;*.avi;*.mov;*.mkv;*.wmv;*.webm|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;  // Enable multi-selection

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Iterate through the selected files
                    string[] filePaths = openFileDialog.FileNames;
                    customMediaPlayer.LoadMediaAndPlay(filePaths[0]);
                    customQueuePanel.Add(filePaths[0]);
                    for (int i = 1; i < filePaths.Length; i++)
                    {
                        customMediaPlayer.AddToQueue(filePaths[i]);
                        customQueuePanel.Add(filePaths[i]);
                    }
                }
            }
        }


        private void stopPictureBox_Click(object sender, EventArgs e)
        {
            customMediaPlayer.Stop();
        }

        private void queuePictureBox_Click(object sender, EventArgs e)
        {
            if (customQueuePanel.Visible)
            {
                Debug.WriteLine("customQueuePanel HIDE");
                customQueuePanel.Hide();
            }
            else
            {
                Debug.WriteLine("customQueuePanel SHOW");
                customQueuePanel.Show();
            }

        }


        private void customMediaPlayer_Click(object sender, EventArgs e)
        {
            playPictureBox_Click(sender, null);
        }

        private void panelMediaControl_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void historiqueToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            historiqueToolStripMenuItem.DropDownItems.Clear();

            var lastModifiedEntries = localDatabase.GetLast10HistoricEntries();

            foreach (var entry in lastModifiedEntries)
            {
                ToolStripMenuItem menuItem = new()
                {
                    Text = $"Name: {entry.Name}, Last Modified: {entry.LastModified}",  // Set the text for the menu item
                    Tag = entry  // Store the entry in the Tag property for future reference
                };

                menuItem.Click += (s, ev) =>
                {
                    var clickedItem = (ToolStripMenuItem)s;
                    (string name, string path, DateTime lastModified) historicEntry = (ValueTuple<string, string, DateTime>)clickedItem.Tag;

                    customMediaPlayer.LoadMediaAndPlay(historicEntry.path);
                };

                historiqueToolStripMenuItem.DropDownItems.Add(menuItem);
            }

            // If no entries are found, add a placeholder item
            if (lastModifiedEntries.Count == 0)
            {
                ToolStripMenuItem emptyItem = new ToolStripMenuItem
                {
                    Text = "No recent history found"
                };
                historiqueToolStripMenuItem.DropDownItems.Add(emptyItem);
            }
        }

        private void customMediaPlayer_EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
        {
            Debug.WriteLine("END REACH");

            string? path = customMediaPlayer.Next(false);

            if (path != null)
            {
                customQueuePanel.Next();
                customMediaPlayer.LoadMediaAndPlay(path);
            }
        }

        private void flushHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete History ?", "Confirmation Window", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                localDatabase.ClearHistory();
            }
        }

        private void precedentPictureBox_Click(object sender, EventArgs e)
        {
            string? path = customMediaPlayer.Precedent();
            if (path != null)
            {
                customQueuePanel.Precedent(path);
                customMediaPlayer.LoadMediaAndPlay(path);
            }
        }

        private void NextPictureBox_Click(object sender, EventArgs e)
        {
            string? path = customMediaPlayer.Next(true);

            if (path != null)
            {
                customQueuePanel.Next();
                customMediaPlayer.LoadMediaAndPlay(path);
            }
        }

        private void fiveSecondesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forwardPictureBox.BackgroundImage = Properties.Resources.forward_5_50;
            forwardPictureBox.Tag = 5;

            rewindPictureBox.BackgroundImage = Properties.Resources.replay_5_50;
            rewindPictureBox.Tag = 5;
        }

        private void tenSecondesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            forwardPictureBox.BackgroundImage = Properties.Resources.forward_10_50;
            forwardPictureBox.Tag = 10;

            rewindPictureBox.BackgroundImage = Properties.Resources.replay_10_50;
            rewindPictureBox.Tag = 10;
        }

        private void forwardPictureBox_Click(object sender, EventArgs e)
        {
            SetTime(int.Parse($"{forwardPictureBox.Tag}"), ValueChange.Add);
        }

        private void rewindPictureBox_Click(object sender, EventArgs e)
        {
            SetTime(int.Parse($"{rewindPictureBox.Tag}"), ValueChange.Sub);
        }
    }
}
