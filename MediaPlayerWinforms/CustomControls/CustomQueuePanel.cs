namespace MediaPlayerWinforms.CustomControls
{
    class CustomQueuePanel : Panel
    {
        int lastIndex = 0;
        bool isFirstTop = false;
        public CustomQueuePanel() => AutoScroll = true;

        public void AddToWaitlistDisplay(List<CustomPictureBox> waitlist)
        {
            for (int i = waitlist.Count - 1; i >= lastIndex; i--)
            {
                waitlist[i].Dock = DockStyle.Top;
                waitlist[i].Margin = new Padding(0, 40, 0, 0); // Adjust padding as needed
                Controls.Add(waitlist[i]);
            }
        }
    }
}
