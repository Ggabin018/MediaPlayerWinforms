using System.Diagnostics;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;

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

        bool isMuted = false;
        int volumeValueBeforeMute = 100;

        int totalSeconds = 0;
        LocalDatabase localDatabase = new();

        private static readonly Mutex mutexSetTime = new Mutex();
        private static readonly Mutex mutexSetVolume = new();


        public MainForm()
        {
            InitializeComponent();

            timerMouseMovement.Start();

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

        private void PlayPause()
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
                //customMediaPlayer.LoadMediaAndPlay("https://www.learningcontainer.com/wp-content/uploads/2020/05/sample-mp4-file.mp4");
                customMediaPlayer.LoadMediaAndPlay("C:\\Users\\tigro\\source\\repos\\MediaPlayerWinforms\\MediaPlayerWinforms\\tmp\\video_test.mp4");
            }
        }

        private void playPictureBox_Click(object sender, EventArgs? e)
        {
            PlayPause();
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

        private void ouvrirUnDossierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string dbPath = fbd.SelectedPath;

                        var extensions = new[] { ".mp4", ".avi", ".mov", ".mkv", ".wmv", ".webm" };
                        List<string> filePaths = Directory.EnumerateFiles(dbPath, "*", SearchOption.TopDirectoryOnly)
                              .Where(file => extensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                              .ToList();

                        customMediaPlayer.LoadMediaAndPlay(filePaths[0]);
                        customQueuePanel.Add(filePaths[0]);
                        for (int i = 1; i < filePaths.Count; i++)
                        {
                            customMediaPlayer.AddToQueue(filePaths[i]);
                            customQueuePanel.Add(filePaths[i]);
                        }
                    }
                    catch (UnauthorizedAccessException uAEx)
                    {
                        Console.WriteLine(uAEx.Message);
                    }
                    catch (PathTooLongException pathEx)
                    {
                        Console.WriteLine(pathEx.Message);
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
            PlayPause();
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

        private void OnPrecedent()
        {
            string? path = customMediaPlayer.Precedent();
            if (path != null)
            {
                customQueuePanel.Precedent(path);
                customMediaPlayer.LoadMediaAndPlay(path);
            }
        }
        private void precedentPictureBox_Click(object sender, EventArgs e)
        {
            OnPrecedent();
        }
        private void OnNext()
        {
            string? path = customMediaPlayer.Next(true);

            if (path != null)
            {
                customQueuePanel.Next();
                customMediaPlayer.LoadMediaAndPlay(path);
            }
        }
        private void NextPictureBox_Click(object sender, EventArgs e)
        {
            OnNext();
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

        private void fullScrenPictureBox_Click(object sender, EventArgs e)
        {
            ModifyFullScreen(null);
        }

        private void pleinÉcranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyFullScreen(null);
        }

        private void couperLeSonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isMuted = true;
            SetVolume(0, ValueChange.Set);
            volumePictureBox.BackgroundImage = Properties.Resources.mute_50;
        }

        private void volumePictureBox_Click(object sender, EventArgs e)
        {
            if (isMuted)
            {
                isMuted = false;
                SetVolume(volumeValueBeforeMute, ValueChange.Set);
                volumePictureBox.BackgroundImage = Properties.Resources.high_volume_50;
            }
            else
            {
                isMuted = true;
                SetVolume(0, ValueChange.Set);
                volumePictureBox.BackgroundImage = Properties.Resources.mute_50;
            }
        }

        private void favPictureBox_Click(object sender, EventArgs e)
        {
            favPictureBox.BackgroundImage = Properties.Resources.fav_50;
        }


        // Override the WndProc method to detect mouse movement at the form level
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_MOUSEMOVE = 0x0200;

            if (m.Msg == WM_MOUSEMOVE)
            {
                OnActivity();
            }
        }

        private void OnActivity()
        {
            timerMouseMovement.Stop();
            timerMouseMovement.Start();
            Cursor.Show();
            panelMediaControl.Show();
        }

        // Override ProcessCmdKey to capture arrow key presses
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            OnActivity();

            switch (keyData)
            {
                case Keys.Space:
                    PlayPause();
                    break;

                case Keys.Escape:
                    ModifyFullScreen(false);
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
                    OnPrecedent();
                    break;

                case Keys.E:
                    OnNext();
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
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timerMouseMovement_Tick(object sender, EventArgs e)
        {
            if (Utility.ControlIsHover(customMediaPlayer))
            {
                Cursor.Hide();
                panelMediaControl.Hide();
            }
        }

        private void créerSoustitresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string parentPath = "C:\\Users\\tigro\\source\\repos\\MediaPlayerWinforms\\Python\\SpeechToText";
            if (Path.Exists(parentPath))
            {
                Debug.WriteLine("SpeechToText found");
                if (customMediaPlayer.CurrentVideoPath != string.Empty)
                {
                    Debug.WriteLine($"Srt for {customMediaPlayer.CurrentVideoPath}");
                    Utility.SrtMake(parentPath, customMediaPlayer.CurrentVideoPath);
                }
                else
                    Debug.WriteLine("No media load");
            }
            else
                Debug.WriteLine("SpeechToText folder in Python folder not found");
        }
    }
}
