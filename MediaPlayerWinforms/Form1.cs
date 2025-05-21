using MediaPlayerWinforms.CustomControls;
using System.ComponentModel;

namespace MediaPlayerWinforms
{
    public partial class MainForm : Form
    {
        public enum ValueChange
        {
            Add,
            Sub,
            Set
        }

        // attributes
        Point precedentMousePosition = new(0, 0);
        bool isFullScreen = false;

        bool isMuted = false;
        int volumeValueBeforeMute = 100;

        int totalSeconds = 0;
        private readonly LocalDatabase localDatabase = new();

        private readonly Mutex mutexSetTime = new();
        private readonly Mutex mutexSetVolume = new();

        private bool IsUiHidden = false;

        private bool IsMuted = false;

        private ToolStripMenuItem curModelSize;

        private List<PictureBox> pictureBoxesLoop = new List<PictureBox>();

        public MainForm()
        {
            InitializeComponent();

            pictureBoxesLoop.Add(new PictureBox());

            customMediaPlayer.Video.IsMouseInputEnabled = false;
            customMediaPlayer.Video.IsKeyInputEnabled = false;

            curModelSize = baseToolStripMenuItem;

            // Link event
            mediaCustomProgressBar.OnClickProgressBarForMediaPlayer += customMediaPlayer.OnClickProgressBarForMediaPlayer;
            mediaPlayerSlider.OnMouseDownForMediaPlayer += customMediaPlayer.OnMouseDownForMediaPlayer;
            customMediaPlayer.LocalDatabaseAddToHistoric += localDatabase.AddToHistoric;
            customMediaPlayer.InitProgressBar += mediaCustomProgressBar.InitProgressBar;
            customMediaPlayer.ModifyFullScreen += ModifyFullScreen;
            customMediaPlayer.AddToWaitlistDisplay += customQueuePanel.AddToWaitlistDisplay;
        }

        public void ModifyFullScreen(bool? explicitModify)
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
                customMediaPlayer.LoadMediaAndPlay(Path.Combine(Directory.GetCurrentDirectory(), "tmp\\video_test.mp4"), false);
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

        private string? AskVideoPath()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "video files|*.mp4;*.avi;*.mov;*.mkv;*.wmv;*.webm|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    return filePath;
                }
            }
            return null;
        }

        private void ouvrirUnFichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string? filePath = AskVideoPath();
            if (filePath != null)
                customMediaPlayer.LoadMediaAndPlay(filePath, false);
            else
                Console.WriteLine("No media to load");
        }

        private void ouvrirPlusieursFichiersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "video files|*.mp4;*.avi;*.mov;*.mkv;*.wmv;*.webm|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] filePaths = openFileDialog.FileNames;
                    customMediaPlayer.LoadMediaAndPlay(filePaths[0], false);
                    for (int i = 1; i < filePaths.Length; i++)
                    {
                        customMediaPlayer.AddToWaitList(filePaths[i]);
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

                        customMediaPlayer.LoadMediaAndPlay(filePaths[0], false);
                        for (int i = 1; i < filePaths.Count; i++)
                        {
                            customMediaPlayer.AddToWaitList(filePaths[i]);
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
                Console.WriteLine("customQueuePanel HIDE");
                customQueuePanel.Hide();
            }
            else
            {
                Console.WriteLine("customQueuePanel SHOW");
                customQueuePanel.Show();
            }

        }

        private void customMediaPlayer_Click(object sender, EventArgs e)
        {
            PlayPause();
        }


        private void customMediaPlayer_DoubleClick(object sender, EventArgs e)
        {
            ModifyFullScreen(null);
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

                    customMediaPlayer.LoadMediaAndPlay(historicEntry.path, false);
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
            Utility.WriteLineColor("EOF", ConsoleColor.Magenta);

            customMediaPlayer.Next(false);
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
            customMediaPlayer.Precedent();
        }
        private void precedentPictureBox_Click(object sender, EventArgs e)
        {
            OnPrecedent();
        }
        private void OnNext()
        {
            customMediaPlayer.Next(true);
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
            localDatabase.ModifyFav(customMediaPlayer.CurrentVideoPath);
        }

        // Override ProcessCmdKey to capture arrow key presses
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
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
                case Keys.H:
                    if (IsUiHidden)
                    {
                        Cursor.Show();
                        panelMediaControl.Show();
                        IsUiHidden = false;
                    }
                    else
                    {
                        Cursor.Hide();
                        panelMediaControl.Hide();
                        IsUiHidden = true;
                    }
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void créerSoustitresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string parentPath = "Python\\SpeechToText";
            if (Path.Exists(parentPath))
            {
                Console.WriteLine("SpeechToText found");
                try
                {
                    Console.WriteLine($"Srt for {customMediaPlayer.CurrentVideoPath}");
                    Utility.SrtMake(parentPath, customMediaPlayer.CurrentVideoPath, curModelSize.Text!);
                }
                catch
                {
                    string? filePath = AskVideoPath();
                    if (filePath != null)
                    {
                        Console.WriteLine($"Srt for {filePath}");
                        Utility.SrtMake(parentPath, filePath, curModelSize.Text!);
                    }
                    else
                        Console.WriteLine("No media load");
                }
            }
            else
                Console.WriteLine("SpeechToText folder in Python folder not found");
        }

        private void changeModelSize(ToolStripMenuItem item)
        {
            curModelSize.Image = null;
            curModelSize = item;
            curModelSize.Image = Properties.Resources.approved_96;
        }

        private void tinyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeModelSize(tinyToolStripMenuItem);
        }

        private void baseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeModelSize(baseToolStripMenuItem);
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeModelSize(baseToolStripMenuItem);
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeModelSize(mediumToolStripMenuItem);
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeModelSize(largeToolStripMenuItem);
        }
    }
}
