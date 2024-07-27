using AxWMPLib;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace VlcPlayerWinforms.CustomControls
{
    class CustomSlider : Control
    {
        // Draw Properties
        private readonly LinearGradientBrush linGrBrush = new LinearGradientBrush(
            new Point(0, 10),
            new Point(125, 10),
            Color.FromArgb(255, 0, 255, 0),  // Opaque red
            Color.FromArgb(255, 255, 0, 0));   // Opaque green
        private Color sliderColor = Color.RoyalBlue;

        // Others
        private int value = 100;
        private int maximum = 125;
        private AxWindowsMediaPlayer mediaPlayer;

        public int Value { get => value; set => this.value = value; }
        public int Maximum { get => maximum; set => maximum = value; }

        [Category("Custom Controls")]
        public AxWindowsMediaPlayer MediaPlayer
        {
            get => mediaPlayer;
            set
            {
                mediaPlayer = value;
                Invalidate();
            }
        }

        private void FillBackTriangle(PaintEventArgs e)
        {
            e.Graphics.FillPolygon(Brushes.White, new Point[] {
                new(0,Height),
                new(Width, Height),
                new(Width, 0) });
        }

        private void FillForeTriangle(PaintEventArgs e, int val)
        {
            if (val > Maximum)
                throw new ArgumentException("val > Width");
            e.Graphics.FillPolygon(linGrBrush, new Point[] {
                new(0,Height),
                new(val, Height - Height*val/Width), // max != width possible...
                new(val, Height) });
        }

        public CustomSlider()
        {
            SetStyle(ControlStyles.UserPaint, true);
            ForeColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            FillBackTriangle(e);
            FillForeTriangle(e, Value);

            if (IsHover())
            {
                MessageBox.Show("hehe");
                Point clientPos = PointToClient(MousePosition);
                using (var brushSlider = new SolidBrush(sliderColor))
                {
                    Rectangle rectSlider = new Rectangle(clientPos.X, clientPos.Y, 100, 100);
                    e.Graphics.FillRectangle(brushSlider, rectSlider);
                }
            }

        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            
            if (IsHover())
            {
                MessageBox.Show("la");
                Point clientPos = PointToClient(MousePosition);
                int newVolume = clientPos.X * Maximum / Width;
                Value = newVolume;
                mediaPlayer.settings.volume = newVolume;
            }
        }

        private bool IsHover()
        {
            Point clientPos = PointToClient(MousePosition);
            return clientPos.Y > Location.Y && clientPos.Y < Location.Y + Height &&
                clientPos.X > Location.X && clientPos.X < Location.X + Width;
        }

    }
}
