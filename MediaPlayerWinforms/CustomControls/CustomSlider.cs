using AxWMPLib;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace MediaPlayerWinforms.CustomControls
{
    class CustomSlider : Control
    {
        Label labelVolume;

        // Draw Properties
        private readonly LinearGradientBrush linGrBrush = new LinearGradientBrush(
            new Point(0, 10),
            new Point(125, 10),
            Color.FromArgb(255, 0, 255, 0),  // Opaque red
            Color.FromArgb(255, 255, 0, 0));   // Opaque green
        private Color sliderColor = Color.Black;

        // Others
        private int _value = 100;
        private int maximum = 125;
        System.Windows.Forms.Timer hoverCall;

        public event Action<int> OnMouseDownForMediaPlayer;

        public int Value 
        { get => _value; set
            {
                if (value < 0)
                    _value = 0;
                else if (value > maximum)
                    _value = maximum;
                else
                    _value = value;

                labelVolume.Text = _value.ToString()+"%";
                Invalidate();
            } 
        }
        public int Maximum { get => maximum; set => maximum = value; }

        [Category("Custom Controls")]
        public Label LabelVolume { get => labelVolume; set => labelVolume = value; }



        /// <summary>
        /// Draw the background rectangle representing the maximum volume level
        /// </summary>
        /// <param name="e"></param>
        private void FillBackRectangle(PaintEventArgs e)
        {
            var rect = new Rectangle(0, Height / 2, Width, Height / 2);
            e.Graphics.FillRectangle(Brushes.White, rect);
        }

        /// <summary>
        /// Draw the rectangle representing the current volume
        /// </summary>
        /// <param name="e"></param>
        /// <param name="val">Value of the current volume</param>
        private void FillForeRectangle(PaintEventArgs e, int val)
        {
            if (val > Maximum)
                throw new ArgumentException("val > Width");

            var rect = new Rectangle(0, Height / 2, val, Height / 2);
            e.Graphics.FillRectangle(linGrBrush, rect);
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

            FillBackRectangle(e);
            FillForeRectangle(e, Value);

            if (IsHover())
                DrawValueText(e.Graphics);

            
        }


        /// <summary>
        /// Paint value text above the rectangle
        /// </summary>
        /// <param name="graph"></param>
        private void DrawValueText(Graphics graph)
        {
            Point clientPos = PointToClient(MousePosition);
            int valueToDraw = clientPos.X * Maximum / Width;
            string text = valueToDraw.ToString() + "%";
            var textSize = TextRenderer.MeasureText(text, Font);

            var rectText = new Rectangle(clientPos.X - textSize.Width / 2,
                                         Height / 2 - textSize.Height - 5, // Adjust position above the rectangle
                                         textSize.Width, textSize.Height + 2);

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

            OnMouseDownForMediaPlayer.Invoke(newVolume);
        }

        private bool IsHover()
        {
            Point clientPos = PointToClient(MousePosition);
            return clientPos.Y >= 0 && clientPos.Y < Height &&
                   clientPos.X >= 0 && clientPos.X < Width;
        }

    }
}
