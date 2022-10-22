using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using CustomProgram.Lands;

namespace CustomProgram.Cards
{
    public class HeadToAirStation : Card
    {
        public HeadToAirStation()
        {
            this.Name = "To airport";
            this.Description = "This card will move you to airport";
            this.Color = Color.Yellow;
        }
        public override void CreateEvent(Player player, GameMaster gameMaster)
        {
            player.CurrentLandPosition = 27;
        }
    }
}
