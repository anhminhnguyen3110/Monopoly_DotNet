using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomProgram.Lands;
using SplashKitSDK;
namespace CustomProgram.views
{
    public class BoardUI : IDraw
    {
        private double _x;
        private double _y;
        private Board _board;
        private bool IsClickable { get; set; }
        public BoardUI(double x,double y, Board board)
        {
            this._x = x;
            this._y = y;
            _board = board;
            IsClickable = true;
        }


        public Board Board
        {
            get
            {
                return this._board;
            }
        }

        public static double[] GetLoc(int i)
        {
            double x = 0;
            double y = 0;
            int ind = 0;
            double xDownRight = 930;
            double yDownRight = 720;

            double xDownLeft = 210;
            double yDownLeft = 720;

            double xTopLeft = 210;
            double yTopLeft = 0;

            double xTopRight = 930;
            double yTopRight = 0;
            if (i < 9)
            {
                ind = i;
                x = xDownRight - ind * 80;
                y = yDownRight;
            }
            else if (i < 18)
            {
                ind = i - 9;
                x = xDownLeft;
                y = yDownLeft - ind * 80;
            }
            else if (i < 27)
            {
                ind = i - 18;
                x = xTopLeft + ind * 80;
                y = yTopLeft;
            }
            else
            {
                ind = i - 27;
                x = xTopRight;
                y = yTopRight + ind * 80;
            }
            return new double[] {x, y};
        }
        public static double[] GetCenter(int i)
        {
            double[] ret = GetLoc(i);
            double x1 = ret[0];
            double y1 = ret[1];
            double x = x1 + 80 / 2;
            double y = y1 + 80 / 2;
            return new double[] { x, y };
        }
        public bool IsAt(Point2D pt, double x, double y)
        {
            double xp = pt.X;
            double yp = pt.Y;
            if (xp >= x && yp >= y && xp <= x + 80 && yp <= y + 80)
            {
                return true;
            }

            return false;
        }
        public int CheckLandClick(Point2D pt)
        {
            int ret = 0;
            if (IsClickable)
            {
                for (int i = 0; i < 36; i++)
                {
                    double[] result = GetLoc(i);
                    if (IsAt(pt, result[0], result[1]))
                    {
                        return i;
                    }
                }
                return ret;
                
            }
            return 40;
        }

        public void Draw()
        {
            Board board = this._board;
            int xDownRight = 930;
            int yDownRight = 720;

            int xDownLeft = 210;
            int yDownLeft = 720;

            int xTopLeft = 210;
            int yTopLeft = 0;

            int xTopRight = 930;
            int yTopRight = 0;

            for(int i = 0; i < 36;i++)
            {
                if(i < 9)
                {
                    double[] ret = GetLoc(i);
                    double x = ret[0];
                    double y = ret[1];
                    //ret = GetCenter(i);
                    //double x1 = ret[0];
                    //double y1 = ret[1];
                    if (board.Lands[i].Purchasable == true)
                    {
                        CityLand cityLand = board.Lands[i] as CityLand;
                        SplashKit.FillRectangle(cityLand.Color, new Rectangle() { X = x, Y = y, Height = 10, Width = 80});
                    }
                    //SplashKit.FillCircle(Color.Brown, new Circle() { Center = new Point2D() { X = x1, Y = y1 }, Radius = 4 });
                    SplashKit.DrawText(board.Lands[i].Name, Color.Black, "Roboto", 14, x + 5, y + 10);
                    SplashKit.DrawRectangle(Color.Black, new Rectangle() { X = x, Y = y, Height = 80, Width = 80 });
                }
                else if (i < 18)
                {
                    double[] ret = GetLoc(i);
                    double x = ret[0];
                    double y = ret[1];
                    //ret = GetCenter(i);
                    //double x1 = ret[0];
                    //double y1 = ret[1];

                    if (board.Lands[i].Purchasable == true)
                    {
                        CityLand cityLand = board.Lands[i] as CityLand;
                        SplashKit.FillRectangle(cityLand.Color, new Rectangle() { X = x + 70, Y = y, Height = 80, Width = 10 });
                    }
                    //SplashKit.FillCircle(Color.Brown, new Circle() { Center = new Point2D() { X = x1, Y = y1 }, Radius = 4 });
                    SplashKit.DrawText(board.Lands[i].Name, Color.Black, "Roboto", 14, x + 5, y + 10);
                    SplashKit.DrawRectangle(Color.Black, new Rectangle() { X = x, Y = y, Height = 80, Width = 80 });
                }
                else if (i < 27)
                {
                    double[] ret = GetLoc(i);
                    double x = ret[0];
                    double y = ret[1];
                    //ret = GetCenter(i);
                    //double x1 = ret[0];
                    //double y1 = ret[1];

                    if (board.Lands[i].Purchasable == true)
                    {
                        CityLand cityLand = board.Lands[i] as CityLand;
                        SplashKit.FillRectangle(cityLand.Color, new Rectangle() { X = x, Y = y+70, Height = 10, Width = 80 });
                    }
                    //SplashKit.FillCircle(Color.Brown, new Circle() { Center = new Point2D() { X = x1, Y = y1 }, Radius = 4 });
                    SplashKit.DrawText(board.Lands[i].Name, Color.Black, "Roboto", 14, x + 5, y + 10);
                    SplashKit.DrawRectangle(Color.Black, new Rectangle() { X = x, Y = y, Height = 80, Width = 80 });
                }else
                {
                    double[] ret = GetLoc(i);
                    double x = ret[0];
                    double y = ret[1];
                    //ret = GetCenter(i);
                    //double x1 = ret[0];
                    //double y1 = ret[1];

                    if (board.Lands[i].Purchasable == true)
                    {
                        CityLand cityLand = board.Lands[i] as CityLand;
                        SplashKit.FillRectangle(cityLand.Color, new Rectangle() { X = x, Y = y, Height = 80, Width = 10 });
                    }
                    //SplashKit.FillCircle(Color.Brown, new Circle() { Center = new Point2D() { X = x1, Y = y1 }, Radius = 4 });
                    SplashKit.DrawText(board.Lands[i].Name, Color.Black, "Roboto", 13, x + 10, y + 10);
                    SplashKit.DrawRectangle(Color.Black, new Rectangle() { X = x, Y = y, Height = 80, Width = 80 });
                }
            }
        }
    }
}
