using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

using CustomProgram.Lands;
namespace CustomProgram
{
    public class Board
    {
        private static Board _instance = null;
        private Land[] _lands;
        private Board()
        {
            _lands = new Land[36];
        }

        public static Board GetInstance()
        {
            if (_instance == null)
            {
                return new Board();
            }
            return _instance;
        }
        public void CreateBoard()
        {
            //first line
            Lands[0] = new StartLand(0,"Start land", Color.White);

            Lands[1] = new CityLand(1, "DortMund", Color.RGBColor(237, 16, 102), 60, 50, 2, 25);
            Lands[2] = new CityLand(2, "Hamburg", Color.RGBColor(237, 16, 102), 60, 50, 2, 28);
            Lands[3] = new CityLand(3, "Berlin", Color.RGBColor(237, 16, 102), 60, 50, 4, 30);

            Lands[4] = new ChanceLand(4, "Chance", Color.White);

            Lands[5] = new BeachLand(5, "Nice", Color.RGBColor(255,255,191), 200);

            Lands[6] = new CityLand(6,"Paris",Color.RGBColor(255, 124, 7), 100, 50, 6, 33);
            Lands[7] = new CityLand(7, "Lyon", Color.RGBColor(255, 124, 7), 100, 50, 6, 35);
            Lands[8] = new CityLand(8, "Reim", Color.RGBColor(255, 124, 7), 120, 50, 8, 38);

            Lands[9] = new PrisonLand(9 ,"Prison", Color.White);


            Lands[10] = new CityLand(10, "Tokyo", Color.RGBColor(224, 0, 11), 140, 100, 10, 70);
            Lands[11] = new CityLand(11, "Osaka", Color.RGBColor(224, 0, 11), 140, 100, 10, 75);
            Lands[12] = new CityLand(12, "Kyoto", Color.RGBColor(224, 0, 11), 160, 100, 12, 80);

            Lands[13] = new BeachLand(13, "Nice", Color.RGBColor(255, 255, 191), 200);

            Lands[14] = new CityLand(14, "Seoul", Color.RGBColor(242, 255, 31), 180, 100, 14, 85);
            Lands[15] = new TaxLand(15, "Tax", Color.White);
            Lands[16] = new CityLand(16, "Beijing", Color.RGBColor(242, 255, 31), 200, 100, 16, 90);
            Lands[17] = new SecretLand(17, "Secret", Color.White, 0);
            Lands[18] = new WorldCupLand(18, "WorldCup", Color.White);

            Lands[19] = new CityLand(19, "Sydney", Color.RGBColor(0, 168, 20), 220,150,18,113);
            Lands[20] = new CityLand(20, "Melbourne", Color.RGBColor(0, 168, 20), 240,150,20,120);

            Lands[21] = new ChanceLand(21, "Chance", Color.White);
            Lands[22] = new BeachLand(22, "Hawaii", Color.RGBColor(255, 255, 191), 200);

            Lands[23] = new CityLand(23, "New York", Color.RGBColor(19, 47, 255), 260, 150, 22, 128);
            Lands[24] = new CityLand(24, "Las Vegas", Color.RGBColor(19, 47, 255), 260, 150, 22, 135);
            Lands[25] = new SecretLand(25, "Secret", Color.White, 0);
            Lands[26] = new CityLand(26, "Califonia", Color.RGBColor(19, 47, 255), 280, 150, 24, 143);
            Lands[27] = new AirportLand(27, "Airport", Color.White);

            Lands[28] = new CityLand(28, "Amsterdam", Color.RGBColor(105, 0, 124), 300, 200, 26, 170);
            Lands[29] = new CityLand(29, "Rome", Color.RGBColor(105, 0, 124), 320, 200, 28, 180);

            Lands[30] = new ChanceLand(30, "Chance", Color.White);
            Lands[31] = new BeachLand(31, "Dubai", Color.RGBColor(255, 255, 191), 200);
            Lands[32] = new SecretLand(32, "Secret", Color.White, 0);

            Lands[33] = new CityLand(33, "Manchester", Color.RGBColor(0, 221, 224), 350, 200, 35, 190);
            Lands[34] = new CityLand(34, "London", Color.RGBColor(0, 221, 224), 400, 200, 50, 200);
            Lands[35] = new SecretChestLand(35, "Chest", Color.White);
        }

        public Land[] Lands
        {
            get
            {
                return this._lands;
            }
        }
    }
}
