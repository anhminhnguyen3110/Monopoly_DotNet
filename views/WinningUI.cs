using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.views
{
    public class WinningUI:IDraw
    {
        public bool IsVisible = false;
        private Player _winner;
        public double Height { get; set; }
        public double Width { get; set; }
       

        public void SetWinner(Player player)
        {
            _winner = player;
        }

        public void Draw()
        {
            //SetWinner(new Player("Minh", Color.Green, "\amsds"));
            if (IsVisible)
            {
                SplashKit.FillRectangle(Color.Red, new Rectangle() { X = 0, Y = 0, Height = 800, Width = 1200 });
                SplashKit.DrawText($"{_winner.Name} wins the game!!!", Color.Black,"Roboto",50, 380, 350);
            }
        }

    }
}
