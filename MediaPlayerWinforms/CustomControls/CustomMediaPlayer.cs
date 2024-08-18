using System.Configuration;
using System.Diagnostics;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;

namespace MediaPlayerWinforms.CustomControls
{
    class CustomMediaPlayer : Vlc.DotNet.Forms.VlcControl
    {
        Queue<string> _queue = new Queue<string>();
        Stack<string> _stack = new Stack<string>();

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
            _queue.Enqueue(path);
        }

        public void AddsToQueue(IEnumerable<string> paths)
        {
            foreach (string path in paths)
                AddToQueue(path);
        }

        public string? Next()
        {
            if (_queue.Count == 0)
                return null;
            string path = _queue.Dequeue();
            _stack.Push(path);
            return path;
        }

    }
}
