using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.views
{
    public class PlayerUI
    {
        private Bitmap _player1;
        private Bitmap _player2;
        private Bitmap _player3;
        private Bitmap _player4;
        private double _x;
        private double _y;
        public PlayerUI()
        {

        }
        public static void drawPlayer(GameMaster gameMaster)
        {
            int i = 0;
            foreach (Player player in gameMaster.Players)
            {
                if (i == 0)
                {
                    double[] result = BoardUI.GetCenter(player.CurrentLandPosition);
                    SplashKit.DrawBitmap(new Bitmap(player.Name, player.Image), result[0] - 25, result[1] - 15); //player 1
                }
                if (i == 1)
                {
                    double[] result = BoardUI.GetCenter(player.CurrentLandPosition);
                    SplashKit.DrawBitmap(new Bitmap(player.Name, player.Image), result[0] + 15, result[1] - 15); //player 2
                }
                if (i == 2)
                {
                    double[] result = BoardUI.GetCenter(player.CurrentLandPosition); 
                    SplashKit.DrawBitmap(new Bitmap(player.Name, player.Image), result[0] - 25, result[1] + 10); // player 3
                }
                if (i == 3)
                {
                    double[] result = BoardUI.GetCenter(player.CurrentLandPosition);
                    SplashKit.DrawBitmap(new Bitmap(player.Name, player.Image), result[0] + 15, result[1] + 10); // player 4
                }
                i++;
            }
        }
    }
}
