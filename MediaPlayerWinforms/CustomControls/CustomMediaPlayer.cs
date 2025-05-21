using System.ComponentModel;
using System.Net;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;

namespace MediaPlayerWinforms.CustomControls
{
    class CustomMediaPlayer : Vlc.DotNet.Forms.VlcControl
    {
        List<CustomPictureBox> _playlist = [];
        int currentVideoId = 0;
        public string CurrentVideoPath { get => _playlist[currentVideoId].VideoPath; }

        public event Action<string> LocalDatabaseAddToHistoric;
        public event Action<int> InitProgressBar;
        public event Action<bool?> ModifyFullScreen;
        public event Action<List<CustomPictureBox>> AddToWaitlistDisplay;

        

        private Label labelTotalMediaTime;

        [Category("Custom Controls")]
        public Label LabelTotalMediaTime { get => labelTotalMediaTime; set => labelTotalMediaTime = value; }

        [Category("Custom Controls")]
        public LoopManager LoopManager { get; set; }

        public CustomMediaPlayer() : base()
        {
            Dock = DockStyle.Fill;
            VlcLibDirectory = new("libvlc");

            BackColor = Color.Black;
        }

        public double Duration
        {
            get 
            {
                 VlcMedia media = GetCurrentMedia();
                if (media != null)
                    return media.Duration.TotalSeconds;
                Utility.WriteLineColor("Duration not set", ConsoleColor.Red);
                return 0;
            } 
        }

        public double PositionSeconds
        {
            get => Position * Duration;
            set
            {
                   Position = (float)(value / Duration);
            }
        }

        public int Volume
        {
            get => Audio.Volume; set => Audio.Volume = value;
        }
        public bool IsPaused { get => State == MediaStates.Paused;}
        public int CurrentVideoId { get => currentVideoId;}

        public void AddToWaitList(string path)
        {
            AssertVideoPath(path);

            CustomPictureBox videoBloc = new (path, _playlist.Count == 0, _playlist.Count, LoadMediaAndPlay);
            //videoBloc.Enabled = false;
            _playlist.Add(videoBloc);
            AddToWaitlistDisplay(_playlist);
        }

        public void Next(bool forceFlag)
        {
            DebugMediaPlayer();
            if (_playlist.Count == 0)
            {
                Utility.WriteLineColor("Empty playlist", ConsoleColor.DarkGreen);
            }
            else if (LoopManager.IsLooping())
            {
                Utility.WriteLineColor("Looping", ConsoleColor.DarkGreen);
                LoadMediaAndPlay(CurrentVideoPath, true);
            }
            else if (currentVideoId + 1 < _playlist.Count)
            {
                Utility.WriteLineColor("Next", ConsoleColor.DarkGreen);
                LoadMediaAndPlay(_playlist[currentVideoId+1]);
            }
            else
                Utility.WriteLineColor("No Next", ConsoleColor.DarkGreen);
        }

        public void Precedent()
        {
            if (_playlist.Count == 0)
                return;

            if (currentVideoId != 0)
            {
                LoadMediaAndPlay(_playlist[currentVideoId-1]);
            }
        }

        public async void LoadMediaAndPlay(string url, bool fromLoop)
        {
            Utility.WriteLineColor("LOAD MEDIA AND PLAY FROM URL", ConsoleColor.DarkMagenta);

            if (!fromLoop)
                AddToWaitList(url);

            //_playlist[currentVideoId].Enabled = false; // not empty because of AddToWaitList
            _playlist[currentVideoId].BackColor = Color.Black;

            currentVideoId = _playlist.Count - 1;
            _playlist[currentVideoId].BackColor = Color.Gray;
            //_playlist[currentVideoId].Enabled = true;

            Play(uri: new Uri(url));

            LocalDatabaseAddToHistoric(url);

            //time to load media
            await Task.Delay(1000);

            double duration = 0;
            int nTry = 100;
            while (duration == 0 && nTry > 0)
            {
                await Task.Delay(10);
                duration = Duration;
                nTry--;
            }
            if (duration == 0)
                throw new Exception("Duration 0 !");
            labelTotalMediaTime.Text = $"{TimeSpan.FromSeconds(duration):hh\\:mm\\:ss}";

            InitProgressBar((int)duration);

            DebugWaitList();
            Utility.WriteLineColor("Playing from start", ConsoleColor.DarkMagenta);
        }

        public async void LoadMediaAndPlay(CustomPictureBox pictureBox)
        {
            Console.WriteLine("LOAD MEDIA AND PLAY FROM CustomPictureBox");

            _playlist[currentVideoId].BackColor = Color.Black;

            currentVideoId = pictureBox.Index;
            _playlist[currentVideoId].BackColor = Color.Gray;

            Play(uri: new Uri(pictureBox.VideoPath));

            LocalDatabaseAddToHistoric(pictureBox.VideoPath);

            //time to load media
            await Task.Delay(1000);

            double duration = 0;
            int nTry = 100;
            while (duration == 0 && nTry > 0)
            {
                await Task.Delay(10);
                duration = Duration;
                nTry--;
            }
            if (duration == 0)
                throw new Exception("Duration 0 !");
            labelTotalMediaTime.Text = $"{TimeSpan.FromSeconds(duration):hh\\:mm\\:ss}";

            InitProgressBar((int)duration);

            DebugWaitList();
        }

        public void OnClickProgressBarForMediaPlayer(int newTime)
        {
            PositionSeconds = newTime;
        }

        public void OnMouseDownForMediaPlayer(int newVolume) => Volume = newVolume;

        public void DebugWaitList()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDebugWaitList : ");
            for (int i = 0; i < _playlist.Count; i++)
            {
                CustomPictureBox videoBloc = _playlist[i];
                string videoInfo = $"path : {videoBloc.VideoPath}\n";
                videoInfo += $"Head : {videoBloc.IsPlaylistHead}\n";
                videoInfo += $"Current : {i == CurrentVideoId}\n";
                videoInfo += $"index : {videoBloc.Index}\n";
                videoInfo += $"enabled : {videoBloc.Enabled}\n";
                
                Console.WriteLine(videoInfo);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DebugMediaPlayer()
        {
            Utility.WriteLineColor($"currentVideoId : {currentVideoId}",ConsoleColor.Green);
            Utility.WriteLineColor($"PositionSeconds : {PositionSeconds}", ConsoleColor.Green);
            Utility.WriteLineColor($"CurrentVideoPath : {CurrentVideoPath}", ConsoleColor.Green);
            Utility.WriteLineColor($"IsPaused : {IsPaused}", ConsoleColor.Green);
            Utility.WriteLineColor($"Volume : {Volume}", ConsoleColor.Green);
            Utility.WriteLineColor($"Duration : {Duration}", ConsoleColor.Green);
        }

        private async void AssertVideoPath(string url)
        {
            if (url.StartsWith("http://") || url.StartsWith("https://"))
            {
                try
                {
                    var videoStreamUrl = await VideoUrlChecker.GetVideoStreamUrlAsync(url);

                    if (videoStreamUrl != null)
                    {
                        return;
                    }
                }
                catch (WebException)
                {
                    throw new Exception("Erreur lors de la requête (par exemple, le fichier n'existe pas)");
                }
                throw new Exception("Le fichier en ligne n'existe pas ou n'est pas une vidéo");
            }
            else
            {
                if (File.Exists(url))
                {
                    string[] videoExtensions = { ".mp4", ".avi", ".mov", ".mkv", ".wmv", ".webm" };
                    string fileExtension = Path.GetExtension(url).ToLower();

                    if (videoExtensions.Contains(fileExtension))
                    {
                        return;
                    }
                }
                throw new Exception($"{url} n'existe pas ou n'est pas une vidéo");
            }
        }


        // Override the WndProc method to capture mouse clicks and double-clicks
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_RBUTTONDOWN = 0x0204;

            switch (m.Msg)
            {
                case WM_RBUTTONDOWN:
                    OnRightMouseClick();
                    break;
            }
        }

        private void OnRightMouseClick()
        {
            MessageBox.Show("Right mouse button clicked!");
            Point clientPos = PointToClient(MousePosition);
            // TODO
        }

    }
}
