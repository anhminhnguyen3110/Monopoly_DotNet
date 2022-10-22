using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.views
{
    public class BoxInfo : Shape, IDraw
    {
        private double _width;
        private double _height;
        public bool IsVisible { get; set; }
        private List<string> _infos;
        public BoxInfo(List<string> infos, Color color, double x, double y, double height, double width)
        {
            this.Color = color;
            this.X = x;
            this.Y = y;
            Height = height;
            Width = width;
            _infos = infos;
        }

        public List<string> Infos
        {
            set
            {
                this._infos = value;
            }
        }

        public BoxInfo(Color color, double x, double y, double height, double width)
        {
            this.Color = color;
            this.X = x;
            this.Y = y;
            Height = height;
            Width = width;
            _infos = new List<string> { } ;
            this.IsVisible = true;
        }
        public void AddInfo(string info)
        {
            _infos.Add(info);
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
        public void Draw()
        {
            if (this.IsVisible)
            {
                SplashKit.DrawRectangle(Color, new Rectangle() { X = X, Y = Y, Height = Height, Width = Width });
                int i = 1;
                foreach (string info in _infos)
                {
                    SplashKit.DrawText(info, Color.Black, "Roboto", 13, X + 10, Y + i * 15);
                    i += 1;
                }
            }
        }
        public override bool IsAt(Point2D pt)
        {
            throw new NotImplementedException();
        }
    }
}
