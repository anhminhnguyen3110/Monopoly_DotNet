using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.views
{
    public class ShowTurn:IDraw
    {
        public void DrawCircle(int x, int y)
        {
            SplashKit.FillCircle(Color.Pink, new Circle() { Center = new Point2D() { X = x + 100, Y = y + 65 }, Radius = 18 });
        }
        public void Draw(GameMaster gameMaster)
        {
            int i = 0;
            foreach (Player player in gameMaster.Players)
            {
                if (i == 0)
                {
                    int x = 10;
                    int y = 10;
                    SplashKit.DrawRectangle(player.Color, new Rectangle() { X = x, Y = y, Height = 100, Width = 140 });
                    SplashKit.DrawText(player.Name, Color.Black, "Roboto", 20, x + 2, y + 15);
                    SplashKit.DrawText(player.Money.ToString(), Color.Black, "Roboto", 30, x + 2, y + 50);
                    if(gameMaster.GetCurrentPlayerIndex() == 0)
                    {
                        DrawCircle(x,y);
                    }
                }
                else if (i == 1)
                {
                    int x = 1050;
                    int y = 10;
                    SplashKit.DrawRectangle(player.Color, new Rectangle() { X = x, Y = y, Height = 100, Width = 140 });
                    SplashKit.DrawText(player.Name, Color.Black, "Roboto", 20, x + 2, y + 15);
                    SplashKit.DrawText(player.Money.ToString(), Color.Black, "Roboto", 30, x + 2, y + 50);
                    if (gameMaster.GetCurrentPlayerIndex() == 1)
                    {
                        DrawCircle(x, y);
                    }
                }
                else if (i == 2)
                {
                    int x = 10;
                    int y = 680;
                    SplashKit.DrawRectangle(player.Color, new Rectangle() { X = x, Y = y, Height = 100, Width = 140 });
                    SplashKit.DrawText(player.Name, Color.Black, "Roboto", 20, x + 2, y + 15);
                    SplashKit.DrawText(player.Money.ToString(), Color.Black, "Roboto", 30, x + 2, y + 50);
                    if (gameMaster.GetCurrentPlayerIndex() == 2)
                    {
                        DrawCircle(x, y);
                    }
                }
                else if (i == 3)
                {

                    int x = 1050;
                    int y = 680;
                    SplashKit.DrawRectangle(player.Color, new Rectangle() { X = x, Y = y, Height = 100, Width = 140 });
                    SplashKit.DrawText(player.Name, Color.Black, "Roboto", 20, x + 2, y + 15);
                    SplashKit.DrawText(player.Money.ToString(), Color.Black, "Roboto", 30, x + 2, y + 50);
                    if (gameMaster.GetCurrentPlayerIndex() == 3)
                    {
                        DrawCircle(x, y);
                    }
                }
                i++;
            }
        }
    }
}
