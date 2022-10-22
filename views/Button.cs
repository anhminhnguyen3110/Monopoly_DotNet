using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.views
{
    public class Button : Shape, IDraw
    {
        private double _width;
        private double _height;
        public bool IsVisible { get; set; }

        public double DefaultX { get; set; }
        public double DefaultY { get; set; }

        public int _textSize;
        public string Content { get; set; }
        public Button(String content, Color color, double x, double y, double height, double width, int textSize)
        {
            this.Color = color;
            this.X = x;
            this.Y = y;
            IsVisible = true;
            Height = height;
            Width = width;
            Content = content;
            this.DefaultX = x;
            this.DefaultY = y;
            this._textSize = textSize;
        }
        public override bool IsAt(Point2D pt)
        {
            double xp = pt.X;
            double yp = pt.Y;
            if (xp >= this.X && yp >= this.Y && xp <= this.X + Width && yp <= this.Y + Height && IsVisible)
            {
                return true;
            }

            return false;
        }
        public void Disappear()
        {
            this.IsVisible = false;
            this.X = 10000;
            this.Y = 10000;
        }

        public void Appear()
        {
            this.IsVisible = true;
            this.X = this.DefaultX;
            this.Y = this.DefaultY;
        }

        public double Width
        {
            get
            {
                return this._width;
            }
            set
            {
                this._width = value;
            }
        }

        public void Draw()
        {
            if (this.IsVisible)
            {
                SplashKit.DrawRectangle(Color, new Rectangle() { X = X, Y = Y, Height = Height, Width = Width });
                SplashKit.DrawText(Content, Color.Black, "Roboto", _textSize, X + 20, Y + 20);
            }
        }
        public double Height
        {
            get
            {
                return this._height;
            }
            set
            {
                this._height = value;
            }
        }

    }
}
