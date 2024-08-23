using System.ComponentModel;
using System.Diagnostics;
using System.IO;



namespace MediaPlayerWinforms.CustomControls
{
    class CustomQueuePanel : FlowLayoutPanel
    {
        private int _maxNumberOfPanel = 30;
        private Size _boxSize = new(200, 50);
        private List<CustomPictureBox> _listButtons = [];

        public event Action<string> LoadAndPlay;

        [Category("Custom Controls")]
        public int MaxNumberOfPanel { get => _maxNumberOfPanel; set => _maxNumberOfPanel = value; }

        [Category("Custom Controls")]
        public Size BoxSize { get => _boxSize; set => _boxSize = value; }

        public CustomQueuePanel() => AutoScroll = true;

        private void RemoveControl(Control control)
        {
            Controls.Remove(control);
            control.Dispose();
        }
        public void Next()
        {
            if (_listButtons.Count > 0)
                RemoveControl(_listButtons[0]);
            else
                Debug.WriteLine("_listButtons Empty");
        }

        public void Precedent(string path)
        {
            CustomPictureBox pb = new(path, BoxSize);
            pb.LoadAndPlay += LoadAndPlay;

            _listButtons.Insert(0, pb);
            Controls.Add(pb);
            Controls.SetChildIndex(pb,0);
        }

        public void Add(string path)
        {
            CustomPictureBox pb = new(path, BoxSize);
            pb.LoadAndPlay += LoadAndPlay;

            _listButtons.Add(pb);
            Controls.Add(pb);
        }

        public void GoToThisVideoInQueuePanel(string path)
        {
            foreach (Control control in Controls)
            {
                if (control is CustomPictureBox)
                {
                    CustomPictureBox customPictureBox = (CustomPictureBox)control;
                    if (customPictureBox.VideoPath == path)
                    {
                        Add(path);
                        break;
                    }
                    else
                        RemoveControl(customPictureBox);
                }
            }
        }
    }
}
