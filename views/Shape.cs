using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace CustomProgram.views
{
    public abstract class Shape
    {


        private Color _color;
        private double _x;
        private double _y;
        public Shape(Color color)
        {
            _color = color;
            _x = 0;
            _y = 0;
        }
        public Shape() : this(Color.Yellow)
        {

        }
        public Color Color
        {
            get
            {
                return this._color;
            }

            set
            {
                this._color = value;
            }
        }

        public abstract Boolean IsAt(Point2D pt);

        public double X
        {
            get
            {
                return this._x;
            }
            set
            {
                this._x = value;
            }
        }

        public double Y
        {
            get
            {
                return this._y;
            }
            set
            {
                this._y = value;
            }
        }

    }
}
