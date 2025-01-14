﻿using System.ComponentModel;
using System.Drawing;
using System;
using System.Windows.Forms;

// https://raw.githubusercontent.com/ukushu/TextProgressBar/master/TextProgressBar.cs

namespace Kinovea.Force.UI.WinForms.Controls
{
    public enum ProgressBarDisplayMode
    {
        NoText,
        Percentage,
        CurrProgress,
        Value,
        CustomText,
        TextAndPercentage,
        TextAndCurrProgress
    }

    public partial class VeriticalProgressBar : ProgressBar
    {
        public VeriticalProgressBar()
        {
            InitializeComponent();
            Value = Minimum;
            FixComponentBlinking();
        }

        private void FixComponentBlinking()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }

        public void SetValue(int value)
        {
            // Don't redraw if nothing is changing.
            if (value == Value)
                return;

            if (value > Maximum)
                value = Maximum;

            if (value < Minimum)
                value = Minimum;

            // To get around this animation, we need to move the progress bar backwards.
            if (value == Maximum)
            {
                // Special case (can't set value > Maximum).
                Value = value;           // Set the value
                Value = value - 1;       // Move it backwards
            }
            else
            {
                Value = value + 1;       // Move past
            }
            Value = value;               // Move to correct value
        }

        [Description("Font of the text on ProgressBar"), Category("Additional Options")]
        public Font TextFont { get; set; } = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold | FontStyle.Italic);

        private SolidBrush _textColourBrush = (SolidBrush)Brushes.Black;
        [Category("Additional Options")]
        public Color TextColor
        {
            get
            {
                return _textColourBrush.Color;
            }
            set
            {
                _textColourBrush.Dispose();
                _textColourBrush = new SolidBrush(value);
            }
        }

        private SolidBrush _progressColourBrush = (SolidBrush)Brushes.LightGreen;
        [Category("Additional Options"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public Color ProgressColor
        {
            get
            {
                return _progressColourBrush.Color;
            }
            set
            {
                _progressColourBrush.Dispose();
                _progressColourBrush = new SolidBrush(value);
            }
        }

        private ProgressBarDisplayMode _visualMode = ProgressBarDisplayMode.CurrProgress;
        [Category("Additional Options"), Browsable(true)]
        public ProgressBarDisplayMode VisualMode
        {
            get
            {
                return _visualMode;
            }
            set
            {
                _visualMode = value;
                Invalidate();//redraw component after change value from VS Properties section
            }
        }

        private string _text = string.Empty;

        [Description("If it's empty, % will be shown"), Category("Additional Options"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string CustomText
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                Invalidate();//redraw component after change value from VS Properties section
            }
        }

        private string _textToDraw
        {
            get
            {
                string text = CustomText;

                switch (VisualMode)
                {
                    case (ProgressBarDisplayMode.Percentage):
                        text = _percentageStr;
                        break;
                    case (ProgressBarDisplayMode.CurrProgress):
                        text = _currProgressStr;
                        break;
                    case ProgressBarDisplayMode.Value:
                        text = _currValueStr;
                        break;
                    case (ProgressBarDisplayMode.TextAndCurrProgress):
                        text = $"{CustomText}: {_currProgressStr}";
                        break;
                    case (ProgressBarDisplayMode.TextAndPercentage):
                        text = $"{CustomText}: {_percentageStr}";
                        break;
                }

                return text;
            }
            set { }
        }

        private string _percentageStr { get { return $"{(int)((float)Value - Minimum) / ((float)Maximum - Minimum) * 100} %"; } }

        private string _currProgressStr
        {
            get
            {
                return $"{Value}/{Maximum}";
            }
        }

        private string _currValueStr => Value.ToString();


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawProgressBar(g);

            DrawStringIfNeeded(g);
        }

        private void DrawProgressBar(Graphics g)
        {
            Rectangle rect = ClientRectangle;

            //ProgressBarRenderer.DrawHorizontalBar(g, rect);
            ProgressBarRenderer.DrawVerticalBar(g, rect);

            rect.Inflate(-3, -3);

            if (Value > 0)
            {
                int y = (int)Math.Round(((Maximum - (float)Value) / Maximum) * rect.Height);
                int length = (int)Math.Round(((float)Value / Maximum) * rect.Height);
                Rectangle clip = new Rectangle(rect.X, y, rect.Width, length);

                g.FillRectangle(_progressColourBrush, clip);
            }
        }

        private void DrawStringIfNeeded(Graphics g)
        {
            if (VisualMode != ProgressBarDisplayMode.NoText)
            {

                string text = _textToDraw;

                SizeF len = g.MeasureString(text, TextFont);

                Point location = new Point(((Width / 2) - (int)len.Width / 2), ((Height / 2) - (int)len.Height / 2));

                g.DrawString(text, TextFont, (Brush)_textColourBrush, location);
            }
        }

        public new void Dispose()
        {
            _textColourBrush.Dispose();
            _progressColourBrush.Dispose();
            base.Dispose();
        }
    }
}
