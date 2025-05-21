using MediaToolkit.Model;
using MediaToolkit.Options;
using MediaToolkit;
using System.ComponentModel;

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
    public class LoopManager : PictureBox
    {
        private LoopType _loopType = LoopType.NoLoop; // type of loop
        private int _loopN = 0; // number of loop if LoopNtimes
        private int _loopCount = 0; // number of loop to reach in current context
        private int _loopCounter = 0; // current number of loop

        public LoopManager() : base()
        {
            BackgroundImage = Properties.Resources.loop_50;
            Click += LoopManager_Click;
        }

        private void LoopManager_Click(object? sender, EventArgs e)
        {
            _loopType = Utility.NextEnum(_loopType);
            Utility.WriteLineColor(_loopType, ConsoleColor.Green);
            _loopCount = 0;
        }

        [Category("Custom Controls")]
        public int LoopN { get => _loopN; set => _loopN = value; }

        public bool IsLooping()
        {
            switch (_loopType)
            {
                case LoopType.NoLoop:
                    return false;
                case LoopType.LoopAll:
                    throw new NotImplementedException();
                case LoopType.Loop1time:
                    _loopCount = 1;
                    break;
                case LoopType.LoopNtimes:
                    _loopCount = _loopN;
                    break;
                case LoopType.InfiniteLoop:
                    return true;
            }

            if (_loopCounter >= _loopCount)
                return false;
            _loopCounter++;
            return true;
        }
    }
}
