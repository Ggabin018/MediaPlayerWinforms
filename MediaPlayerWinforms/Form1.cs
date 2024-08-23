using System.Diagnostics;
using System.Net;

namespace MediaPlayerWinforms
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
        Point precedentMousePosition = new(0, 0);
        bool isFullScreen = false;
        int totalSeconds = 0;
        LocalDatabase localDatabase = new();

        private static readonly Mutex mutexSetTime = new Mutex();


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

        private void SetTime(int time, TimeChange status)
        {
            mutexSetTime.WaitOne();

            try
            {
                switch (status)
                {
                    case TimeChange.Add:
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
                    case TimeChange.Sub:
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
                    case TimeChange.Set:
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
                    SetTime(10, TimeChange.Add);
                    break;

                case Keys.Left: 
                case Keys.Q:
                    // backward skip in video
                    SetTime(10, TimeChange.Sub);
                    if (customMediaPlayer.IsPaused)
                    {
                        customMediaPlayer.Play(); /// BUG Come back to beginning
                    }
                    break;

                case Keys.Up:
                case Keys.Z:
                    customMediaPlayer.Volume += 5;
                    mediaPlayerSlider.Value = customMediaPlayer.Volume;
                    break;

                case Keys.Down:
                case Keys.S:
                    customMediaPlayer.Volume -= 5;
                    mediaPlayerSlider.Value = customMediaPlayer.Volume;
                    break;

                case Keys.A:
                    precedentPictureBox_Click(sender, e);
                    break;

                case Keys.E:
                    NextPictureBox_Click(sender, e);
                    break;

                case Keys.NumPad0:
                case Keys.D0:
                    SetTime(0, TimeChange.Set);
                    break;

                case Keys.NumPad1:
                case Keys.D1:
                    SetTime((int)(customMediaPlayer.Duration * 0.1), TimeChange.Set);
                    break;

                case Keys.NumPad2:
                case Keys.D2:
                    SetTime((int)(customMediaPlayer.Duration * 0.2), TimeChange.Set);
                    break;

                case Keys.NumPad3:
                case Keys.D3:
                    SetTime((int)(customMediaPlayer.Duration * 0.3), TimeChange.Set);
                    break;

                case Keys.NumPad4:
                case Keys.D4:
                    SetTime((int)(customMediaPlayer.Duration * 0.4), TimeChange.Set);
                    break;

                case Keys.NumPad5:
                case Keys.D5:
                    SetTime((int)(customMediaPlayer.Duration * 0.5), TimeChange.Set);
                    break;

                case Keys.NumPad6:
                case Keys.D6:
                    SetTime((int)(customMediaPlayer.Duration * 0.6), TimeChange.Set);
                    break;

                case Keys.NumPad7:
                case Keys.D7:
                    SetTime((int)(customMediaPlayer.Duration * 0.7), TimeChange.Set);
                    break;

                case Keys.NumPad8:
                case Keys.D8:
                    SetTime((int)(customMediaPlayer.Duration * 0.8), TimeChange.Set);
                    break;

                case Keys.NumPad9:
                case Keys.D9:
                    SetTime((int)(customMediaPlayer.Duration * 0.9), TimeChange.Set);
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
                //loadMediaAndPlay("https://www.learningcontainer.com/wp-content/uploads/2020/05/sample-mp4-file.mp4");
                customMediaPlayer.LoadMediaAndPlay("C:\\Users\\tigro\\source\\repos\\MediaPlayerWinforms\\MediaPlayerWinforms\\tmp\\video.mp4");
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

            string? path = customMediaPlayer.Next();

            if (path != null)
            {
                customQueuePanel.Next();
                customMediaPlayer.LoadMediaAndPlay(path);
            }
        }

        private void flushHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            localDatabase.ClearHistory();
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
            string? path = customMediaPlayer.Next();

            if (path != null)
            {
                customQueuePanel.Next();
                customMediaPlayer.LoadMediaAndPlay(path);
            }
        }
    }
}
