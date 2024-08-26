using System.ComponentModel;



namespace MediaPlayerWinforms.CustomControls
{
    class CustomQueuePanel : FlowLayoutPanel
    {
        private int _maxNumberOfPanel = 30;
        
        private List<PictureBox> _listVideoBloc = [];

        public event Action<string> LoadAndPlay;

        [Category("Custom Controls")]
        public int MaxNumberOfPanel { get => _maxNumberOfPanel; set => _maxNumberOfPanel = value; }

        public CustomQueuePanel() => AutoScroll = true;

        private void RemoveControl(Control control)
        {
            Controls.Remove(control);
            control.Dispose();
        }
        public void Next()
        {
            //if (_listVideoBloc.Count > 0)
            //    RemoveControl(_listVideoBloc[0]);
            //else
            //    Console.WriteLine("_listButtons Empty");
        }

        public void Precedent(string path)
        {
            //CustomPictureBox pb = new(path, BoxSize);
            //pb.LoadAndPlay += LoadAndPlay;

            //_listVideoBloc.Insert(0, pb);
            //Controls.Add(pb);
            //Controls.SetChildIndex(pb,0);
        }

        public void Add(string path)
        {
            //CustomPictureBox pb = new(path, BoxSize);
            //pb.LoadAndPlay += LoadAndPlay;

            //_listVideoBloc.Add(pb);
            //Controls.Add(pb);
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
                        customPictureBox.Enabled = false;
                }
            }
        }
    }
}
