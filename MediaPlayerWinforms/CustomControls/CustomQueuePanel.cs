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

        [Category("Custom Controls")]
        public int MaxNumberOfPanel { get => _maxNumberOfPanel; set => _maxNumberOfPanel = value; }

        [Category("Custom Controls")]
        public Size BoxSize { get => _boxSize; set => _boxSize = value; }

        public CustomQueuePanel() => AutoScroll = true;


        public void Next()
        {
            if (_listButtons.Count > 0)
                Controls.Remove(_listButtons[0]);
            else
                Debug.WriteLine("_listButtons Empty");
        }

        public void Precedent(string path)
        {
            CustomPictureBox pb = new(path, BoxSize);
            _listButtons.Insert(0, pb);
            Controls.Add(pb);
            Controls.SetChildIndex(pb,0);
        }

        public void Add(string path)
        {
            CustomPictureBox pb = new(path, BoxSize);
            _listButtons.Add(pb);
            Controls.Add(pb);
        }


    }
}
