using CustomProgram.Lands;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.views
{
    public class DrawBuilding: Shape, IDraw
    {
        public CityLand CityLand { get; set; }
        public bool IsVisible { get; set; }

        public DrawBuilding(Color color, double x, double y)
        {
            X = x;
            Y = y;
            Color = color;
            IsVisible = true;
        }
        public void Draw()
        {
            if (IsVisible)
            {
                SplashKit.DrawText(CityLand.Level.ToString(), Color, "Roboto", 20, X-9, Y-15);
                SplashKit.DrawText(CityLand.RentingPrice.ToString(), Color.Black, "Roboto", 15, X-7.5, Y+10);
                if (CityLand.IsWorldCup)
                {
                    SplashKit.FillCircle(Color.Purple, new Circle() { Radius = 4, Center = new Point2D() { X = X + 18, Y = Y - 24 } });
                }
            }
        }

        public override bool IsAt(Point2D pt)
        {
            throw new NotImplementedException();
        }
    }
}
