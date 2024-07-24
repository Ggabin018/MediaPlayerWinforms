﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using AxWMPLib;

namespace VlcPlayerWinforms.CustomControls
{
    public enum TextPosition
    {
        Left,
        Right,
        Center,
        Sliding,
        None
    }
    class CustomProgressBar : ProgressBar
    {
        //Fields
        private Color channelColor = Color.LightSteelBlue;
        private Color sliderColor = Color.RoyalBlue;
        private Color foreBackColor = Color.RoyalBlue;
        private int channelHeight = 6;
        private int sliderHeight = 6;
        private TextPosition showValue = TextPosition.Right;
        private string symbolBefore = "";
        private string symbolAfter = "";
        private bool showMaximun = false;
        private bool showCur = false;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;


        //Others
        private bool paintedBack = false;
        private bool stopPainting = false;
        private Rectangle prevRectText = Rectangle.Empty;
        private Rectangle prevRectBar = Rectangle.Empty;


        public CustomProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            ForeColor = Color.White;
        }

        //Properties
        [Category("Custom Controls")]
        public Color ChannelColor { 
            get => channelColor;
            set
            {
                channelColor = value;
                Invalidate();
            }
        }

        [Category("Custom Controls")]
        public Color SliderColor
        {
            get => sliderColor; set
            {
                sliderColor = value;
                Invalidate();
            }
        }

        [Category("Custom Controls")]
        public Color ForeBackColor
        {
            get => foreBackColor; set
            {
                foreBackColor = value;
                Invalidate();
            }
        }

        [Category("Custom Controls")]
        public int ChannelHeight
        {
            get => channelHeight; set
            {
                channelHeight = value;
                Invalidate();
            }
        }

        [Category("Custom Controls")]
        public int SliderHeight
        {
            get => sliderHeight; set
            {
                sliderHeight = value;
                Invalidate();
            }
        }

        [Category("Custom Controls")]
        public TextPosition ShowValue { get => showValue; 
            set
            {
                showValue = value;
                Invalidate();
            }
        }

        [Category("Custom Controls")]
        public string SymbolBefore
        {
            get => symbolBefore; set
            {
                symbolBefore = value;
                Invalidate();
            }
        }

        [Category("Custom Controls")]
        public string SymbolAfter
        {
            get => symbolAfter; set
            {
                symbolAfter = value;
                Invalidate();
            }
        }

        [Category("Custom Controls")]
        public bool ShowMaximun
        {
            get => showMaximun; set
            {
                showMaximun = value;
                Invalidate();
            }
        }

        [Category("Custom Controls")]
        public bool ShowCur
        {
            get => showCur; 
            set
            {
                showCur = value;
                Invalidate();
            }
        }

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


        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Font Font { get => base.Font; set => base.Font = value; }

        [Category("Custom Controls")]
        public override Color ForeColor { get => base.ForeColor; set => base.ForeColor = value; }
        


        //-> Paint the background & channel
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (!stopPainting)
            {
                if (!paintedBack)
                {
                    //Fields
                    Graphics graph = pevent.Graphics;
                    Rectangle rectChannel = new Rectangle(0, 0, Width, ChannelHeight);
                    using (var brushChannel = new SolidBrush(channelColor))
                    {
                        if (channelHeight >= sliderHeight)
                            rectChannel.Y = Height - channelHeight;
                        else rectChannel.Y = Height - ((channelHeight + sliderHeight) / 2);

                        //Painting
                        graph.Clear(Parent.BackColor);//Surface
                        graph.FillRectangle(brushChannel, rectChannel);//Channel

                        //Stop painting the back & Channel
                        if (DesignMode == false)
                            paintedBack = true;
                    }
                }
                //Reset painting the back & channel
                if (Value == Maximum || Value == Minimum)
                    paintedBack = false;
            }
        }
        //-> Paint slider
        protected override void OnPaint(PaintEventArgs e)
        {
            // mouse hover
            Point clientPos = PointToClient(MousePosition);

            if (!stopPainting)
            {
                //Fields
                Graphics graph = e.Graphics;
                double scaleFactor = (((double)Value - Minimum) / ((double)Maximum - Minimum));
                int sliderWidth = (int)(Width * scaleFactor);
                Rectangle rectSlider = new Rectangle(0, 0, sliderWidth, sliderHeight);
                using (var brushSlider = new SolidBrush(sliderColor))
                {
                    if (sliderHeight >= channelHeight)
                        rectSlider.Y = Height - sliderHeight;
                    else rectSlider.Y = Height - ((sliderHeight + channelHeight) / 2);

                    //Painting
                    if (sliderWidth > 1) //Slider
                    {
                        // Clear previous text
                        if (prevRectBar != Rectangle.Empty)
                        {
                            using (var brushClear = new SolidBrush(channelColor))
                            {
                                graph.FillRectangle(brushClear, prevRectBar);
                            }
                        }
                        // Paint
                        graph.FillRectangle(brushSlider, rectSlider);
                        // Update previous text rectangle
                        prevRectBar = rectSlider;
                    }
                        
                    if (showValue != TextPosition.None) //Text
                        DrawValueText(graph, sliderWidth, rectSlider);

                    // painting time near mouse
                    if (showCur &&
                        clientPos.Y > Location.Y &&
                        clientPos.Y < Location.Y + 30)
                        DrawValueTime(graph);
                    else
                    {
                        if (prevRectText != Rectangle.Empty)
                        {
                            using (var brushClear = new SolidBrush(Parent.BackColor))
                            {
                                graph.FillRectangle(brushClear, prevRectText);
                            }
                        }
                    }
                }
            }
            if (Value == Maximum) stopPainting = true;//Stop painting
            else stopPainting = false; //Keep painting
        }

        //-> Paint value text
        private void DrawValueText(Graphics graph, int sliderWidth, Rectangle rectSlider)
        {
            //Fields
            string text = symbolBefore + Value.ToString() + symbolAfter;
            if (showMaximun) text = text + "/" + symbolBefore + Maximum.ToString() + symbolAfter;
            var textSize = TextRenderer.MeasureText(text, Font);
            var rectText = new Rectangle(0, 0, textSize.Width, textSize.Height + 2);
            using (var brushText = new SolidBrush(ForeColor))
            using (var brushTextBack = new SolidBrush(foreBackColor))
            using (var textFormat = new StringFormat())
            {
                switch (showValue)
                {
                    case TextPosition.Left:
                        rectText.X = 0;
                        textFormat.Alignment = StringAlignment.Near;
                        break;

                    case TextPosition.Right:
                        rectText.X = Width - textSize.Width;
                        textFormat.Alignment = StringAlignment.Far;
                        break;

                    case TextPosition.Center:
                        rectText.X = (Width - textSize.Width) / 2;
                        textFormat.Alignment = StringAlignment.Center;
                        break;

                    case TextPosition.Sliding:
                        rectText.X = sliderWidth - textSize.Width;
                        textFormat.Alignment = StringAlignment.Center;
                        //Clean previous text surface
                        using (var brushClear = new SolidBrush(Parent.BackColor))
                        {
                            var rect = rectSlider;
                            rect.Y = rectText.Y;
                            rect.Height = rectText.Height;
                            graph.FillRectangle(brushClear, rect);
                        }
                        break;

                }

                //Painting
                graph.FillRectangle(brushTextBack, rectText);
                graph.DrawString(text, Font, brushText, rectText, textFormat);

            }
        }

        // Paint time over the progress bar at the mouse location
        private void DrawValueTime(Graphics graph)
        {
            
            //Fields
            Point clientPos = PointToClient(MousePosition);
            string text = $"{TimeSpan.FromSeconds(clientPos.X * Maximum / Width):hh\\:mm\\:ss}";

            var textSize = TextRenderer.MeasureText(text, Font);
            // textSize.Width+1 because it's too close so the last digit is not display
            var rectText = new Rectangle(0, 0, textSize.Width+1, textSize.Height + 2);
            

            using (var brushText = new SolidBrush(ForeColor))
            using (var brushTextBack = new SolidBrush(foreBackColor))
            using (var textFormat = new StringFormat())
            {
                rectText.X = clientPos.X;

                // Clear previous text
                if (prevRectText != Rectangle.Empty)
                {
                    using (var brushClear = new SolidBrush(Parent.BackColor))
                    {
                        graph.FillRectangle(brushClear, prevRectText);
                    }
                }

                // Painting
                graph.FillRectangle(brushTextBack, rectText);
                graph.DrawString(text, Font, brushText, rectText, textFormat);

                // Update previous text rectangle
                prevRectText = rectText;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            Point clientPos = PointToClient(MousePosition);

            if (showCur &&
                        clientPos.Y > Location.Y &&
                        clientPos.Y < Location.Y + 30)
            {
                int newTime = clientPos.X * Maximum / Width;
                Value = newTime;
                mediaPlayer.Ctlcontrols.currentPosition = newTime;
            }
                
            
        }

    }
}
