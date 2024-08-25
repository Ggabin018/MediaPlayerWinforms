﻿using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Security.Policy;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;
using Vlc.DotNet.Forms;
using static MediaToolkit.Model.Metadata;
using static System.Windows.Forms.Design.AxImporter;

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
        List<string> _listNextVideos = new List<string>();
        Stack<string> _stackPrecedentVideos = new Stack<string>();
        string currentVideoPath = "";
        
        public event Action<string, string> LocalDatabaseAddToHistoric;
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
        public string CurrentVideoPath { get => currentVideoPath;}

        public void AddToQueue(string path)
        {
            _listNextVideos.Add(path);
        }

        public string? Next(bool forceFlag)
        {
            if (_listNextVideos.Count == 0) /// NEED MODIF WITH LOOP ALL
                return null;

            switch (LoopVar)
            {
                case LoopType.NoLoop:
                    _loopCount = 0;
                    forceFlag = true;
                    break;
                case LoopType.LoopAll:
                    throw new NotImplementedException();
                case LoopType.Loop1time:
                    _loopCount = 1;
                    break;
                case LoopType.LoopNtimes:
                    _loopCount = LoopN;
                    break;
                case LoopType.InfiniteLoop:
                    Play(currentVideoPath);
                    // bug, not playing
                    return null;
            }

            _loopCounter++;

            if (forceFlag || _loopCounter > _loopCount)
            {
                string path = _listNextVideos[0];
                _listNextVideos.RemoveAt(0);
                _stackPrecedentVideos.Push(path);

                _loopCounter = 0;
                return path;
            }
            return null;
        }

        public string? Precedent()
        {
            /// weird mix on prec cur next
            if (_stackPrecedentVideos.Count == 0)
                return null;
            string path = _stackPrecedentVideos.Pop();
            _listNextVideos.Insert(0, path);
            return path;
        }

        public async void LoadMediaAndPlay(string url)
        {
            Debug.WriteLine("LOAD MEDIA AND PLAY");

            string URL = "";
            string name = "";

            // Test if it is a good file
            if (url.StartsWith("http://") || url.StartsWith("https://"))
            {
                try
                {
                    var videoStreamUrl = await VideoUrlChecker.GetVideoStreamUrlAsync(url);

                    if (videoStreamUrl != null)
                    {
                        URL = url;
                        name = Path.GetFileName(new Uri(url).LocalPath);
                    }
                }
                catch (WebException)
                {
                    throw new Exception("Erreur lors de la requête (par exemple, le fichier n'existe pas)");
                }
                if (URL == "")
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
                        URL = url;
                        name = Path.GetFileName(url);
                    }
                }
                if (URL == "")
                    throw new Exception("Le fichier local n'existe pas ou n'est pas une vidéo");
            }

            Play(uri: new Uri(URL));

            if (currentVideoPath != "")
                _stackPrecedentVideos.Push(currentVideoPath);
            currentVideoPath = URL;
            GoToThisVideoInQueuePanel(URL);
            LocalDatabaseAddToHistoric(name, URL);

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

            Video.IsKeyInputEnabled = true;
            //Video.IsMouseInputEnabled = false;

            DebugWaitList();
        }

        public void OnClickProgressBarForMediaPlayer(int newTime)
        {
            PositionSeconds = newTime;
        }

        public void OnMouseDownForMediaPlayer(int newVolume) => Volume = newVolume;

        public void DebugWaitList()
        {
            List<string> tmpList = _stackPrecedentVideos.ToList();
            tmpList.Reverse();
            tmpList.ForEach(video => { Debug.WriteLine($"PRECEDENT {Path.GetFileNameWithoutExtension(video)}"); });
            Debug.WriteLine($"CURRENT {Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(currentVideoPath))}");
            _listNextVideos.ForEach(video => { Debug.WriteLine($"NEXT {Path.GetFileNameWithoutExtension(video)}"); });
        }
    }
}
