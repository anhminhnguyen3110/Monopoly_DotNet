using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomProgram.Lands
{
    public class BeachLand : CityLand
    {
        public BeachLand(int id, string name, Color color, double realPrice) : base(id, name, color, realPrice, 0, 25, 50)
        {
            this.RentingPrice = 0;
            this.Purchasable = true;
            this.Description = "This land can only buy one an cannot buy from other player, gain 4 beach will win the game";
        }
        public void Notify(int x)
        {
            this.Level = x;
            if(x == 1)
            {
                this.RentingPrice = 25;
            }else if(x == 2)
            {
                this.RentingPrice = 50;
            }
            else if (x == 3)
            {
                this.RentingPrice = 100;
            }else if(x == 4)
            {
                this.RentingPrice = 1000;
            }
        }
        //public void 
    }
}
