using AxWMPLib;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace MediaPlayerWinforms.CustomControls
{
    class CustomSlider : Control
    {
        // DEBUG
        Label labelDebug;

        // Draw Properties
        private readonly LinearGradientBrush linGrBrush = new LinearGradientBrush(
            new Point(0, 10),
            new Point(125, 10),
            Color.FromArgb(255, 0, 255, 0),  // Opaque red
            Color.FromArgb(255, 255, 0, 0));   // Opaque green
        private Color sliderColor = Color.Black;

        // Others
        private int value = 100;
        private int maximum = 125;
        private CustomMediaPlayer mediaPlayer;
        System.Windows.Forms.Timer hoverCall;

        public int Value { get => value; set => this.value = value; }
        public int Maximum { get => maximum; set => maximum = value; }

        [Category("Custom Controls")]
        public CustomMediaPlayer MediaPlayer
        {
            get => mediaPlayer;
            set
            {
                mediaPlayer = value;
                Invalidate();
            }
        }

        [Category("Custom Controls")]
        public Label LabelDebug { get => labelDebug; set => labelDebug = value; }

        /// <summary>
        /// Draw the triangle in background representing the volume max
        /// </summary>
        /// <param name="e"></param>
        private void FillBackTriangle(PaintEventArgs e)
        {
            e.Graphics.FillPolygon(Brushes.White, new Point[] {
                new(0,Height),
                new(Width, Height),
                new(Width, 0) });
        }

        /// <summary>
        /// Draw the triangle representing the current volume
        /// </summary>
        /// <param name="e"></param>
        /// <param name="val"> value of the current volume</param>
        /// <exception cref="ArgumentException"> value greater than volume max</exception>
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
            hoverCall = new()
            {
                Interval = 500,
                Enabled = false,
            };
            hoverCall.Tick += new EventHandler(OnHoverCallTick);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            FillBackTriangle(e);
            FillForeTriangle(e, Value);

            if (IsHover())
                DrawValueText(e.Graphics);

            
        }

        /// <summary>
        /// Paint value text
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="sliderWidth"></param>
        private void DrawValueText(Graphics graph)
        {
            Point clientPos = PointToClient(MousePosition);
            int valueToDraw = clientPos.X * Maximum / Width;
            string text = valueToDraw.ToString() + "%";
            var textSize = TextRenderer.MeasureText(text, Font);
            var rectText = new Rectangle(clientPos.X - textSize.Width / 2, clientPos.Y - textSize.Height / 2, textSize.Width, textSize.Height + 2);

            using var brushText = new SolidBrush(ForeColor);
            using var brushTextBack = new SolidBrush(Color.Black);
            using var textFormat = new StringFormat();

            textFormat.Alignment = StringAlignment.Center;
            graph.FillRectangle(brushTextBack, rectText);
            graph.DrawString(text, Font, brushText, rectText, textFormat);
        }

        private void OnHoverCallTick(object? s, EventArgs e) => Invalidate();

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hoverCall.Enabled = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hoverCall.Enabled = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Point clientPos = PointToClient(MousePosition);
            int newVolume = clientPos.X * Maximum / Width;
            Value = newVolume;

            labelDebug.Text = newVolume.ToString();

            mediaPlayer.Audio.Volume = newVolume;
        }

        private bool IsHover()
        {
            Point clientPos = PointToClient(MousePosition);
            return clientPos.Y >= 0 && clientPos.Y < Height &&
                   clientPos.X >= 0 && clientPos.X < Width;
        }

    }
}
