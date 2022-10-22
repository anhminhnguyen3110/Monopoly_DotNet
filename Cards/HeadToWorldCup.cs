using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomProgram.Lands;
using SplashKitSDK;
namespace CustomProgram.Cards
{
    public class HeadToWorldCup : Card
    {

        public HeadToWorldCup()
        {
            this.Name = "To WorldCup";
            this.Description = "This card will move you to world cup";
            this.Color = Color.Yellow;
        }
        public override void CreateEvent(Player player, GameMaster gameMaster)
        {
            player.CurrentLandPosition = 18;
        }
    }
}
