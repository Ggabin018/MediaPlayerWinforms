using System.ComponentModel;
using System.Net;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;

namespace MediaPlayerWinforms.CustomControls
{
    public enum LoopType
    {
        NoLoop,
        Loop1time,
        LoopNtimes,
        LoopAll,
        InfiniteLoop
    }

    class CustomMediaPlayer : Vlc.DotNet.Forms.VlcControl
    {
        List<CustomPictureBox> _playlist = [];
        int currentVideoId = 0;
        public string CurrentVideoPath { get => _playlist[currentVideoId].VideoPath; }

        public event Action<string> LocalDatabaseAddToHistoric;
        public event Action<int> InitProgressBar;
        public event Action<string> GoToThisVideoInQueuePanel;

        LoopType _loopVar; // type of loop
        int _loopN = 0; // number of loop if LoopNtimes
        int _loopCount = 0; // number of loop to reach in current context
        int _loopCounter = 0; // current number of loop

        private Label labelTotalMediaTime;

        [Category("Custom Controls")]
        public Label LabelTotalMediaTime { get => labelTotalMediaTime; set => labelTotalMediaTime = value; }

        [Category("Custom Controls")]
        public LoopType LoopVar { get => _loopVar; set => _loopVar = value; }

        [Category("Custom Controls")]
        public int LoopN { get => _loopN; set => _loopN = value; }

        public CustomMediaPlayer() : base()
        {
            Dock = DockStyle.Fill;
            VlcLibDirectory = new("C:\\Program Files\\VideoLAN\\VLC");

            BackColor = Color.Black;
        }

        public double Duration
        {
            get 
            {
                 VlcMedia media = GetCurrentMedia();
                if (media != null)
                    return media.Duration.TotalSeconds;
                Console.WriteLine("Duration not set");
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
        public int? CurrentVideoId { get => currentVideoId;}

        public void AddToWaitList(string path)
        {
            AssertVideoPath(path);

            CustomPictureBox videoBloc = new (path, _playlist.Count == 0, _playlist.Count, LoadMediaAndPlay);

            _playlist.Add(videoBloc);
        }

        public void Next(bool forceFlag)
        {
            if (_playlist.Count == 0)
            {
                Console.WriteLine("Empty playlist");
            }

            //switch (LoopVar)
            //{
            //    case LoopType.NoLoop:
            //        _loopCount = 0;
            //        forceFlag = true;
            //        break;
            //    case LoopType.LoopAll:
            //        throw new NotImplementedException();
            //    case LoopType.Loop1time:
            //        _loopCount = 1;
            //        break;
            //    case LoopType.LoopNtimes:
            //        _loopCount = LoopN;
            //        break;
            //    case LoopType.InfiniteLoop:
            //        Play(_playlist[currentVideoId]);
            //        // bug, not playing
            //        return null;
            //}

            //_loopCounter++;

            //if (forceFlag || _loopCounter > _loopCount)
            //{
            //    string path = _listNextVideos[0];
            //    _stackPrecedentVideos.Push(path);

            //    _loopCounter = 0;
            //    return path;
            //}

            if (currentVideoId + 1 < _playlist.Count)
            {
                LoadMediaAndPlay(_playlist[currentVideoId+1]);
            }
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

        public async void LoadMediaAndPlay(string url)
        {
            Console.WriteLine("LOAD MEDIA AND PLAY FROM URL");

            AddToWaitList(url);
            currentVideoId = _playlist.Count - 1;

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
        }

        public async void LoadMediaAndPlay(CustomPictureBox pictureBox)
        {
            Console.WriteLine("LOAD MEDIA AND PLAY FROM CustomPictureBox");

            currentVideoId = pictureBox.Index;

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
            Console.WriteLine("\nDebugWaitList : ");
            for (int i = 0; i < _playlist.Count; i++)
            {
                CustomPictureBox videoBloc = _playlist[i];
                string videoInfo = $"path : {videoBloc.VideoPath}\n";
                videoInfo += $"Head : {videoBloc.IsPlaylistHead}\n";
                videoInfo += $"Current : {i == CurrentVideoId}\n";
                videoInfo += $"index : {videoBloc.Index}\n";
                Console.WriteLine(videoInfo);
            }
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
                throw new Exception("Le fichier local n'existe pas ou n'est pas une vidéo");
            }
        }

        
    }
}
