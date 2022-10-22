using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomProgram.Lands;
using SplashKitSDK;

namespace CustomProgram.Cards
{
    public class AddMoney : Card
    {
        public AddMoney()
        {
            this.Name = "Gain money";
            this.Description = "This card will add you 200";
            this.Color = Color.Green;
        }
        public override void CreateEvent(Player player, GameMaster gameMaster)
        {
            player.AddMoney(200);
        }
    }
}
