using System.Configuration;
using System.Diagnostics;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;

namespace MediaPlayerWinforms.CustomControls
{
    class CustomMediaPlayer : Vlc.DotNet.Forms.VlcControl
    {
        List<string> _listNextVideos = new List<string>();
        Stack<string> _stackPrecedentVideos = new Stack<string>();

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
                Debug.WriteLineIf(true, "Duration not set");
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

        public void AddToQueue(string path)
        {
            _listNextVideos.Add(path);
        }

        public string? Next()
        {
            if (_listNextVideos.Count == 0)
                return null;
            string path = _listNextVideos[0];
            _listNextVideos.RemoveAt(0);
            _stackPrecedentVideos.Push(path);
            return path;
        }

        public string? Precedent()
        {
            if (_stackPrecedentVideos.Count == 0)
                return null;
            string path = _stackPrecedentVideos.Pop();
            _listNextVideos.Insert(0, path);
            return path;
        }

        public void OnClickProgressBarForMediaPlayer(int newTime)
        {
            PositionSeconds = newTime;
        }

        public void OnMouseDownForMediaPlayer(int newVolume) => Volume = newVolume;
    }
}
