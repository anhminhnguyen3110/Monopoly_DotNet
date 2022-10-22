using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram.Cards
{
    public class Stun : Card
    {
        public Stun()
        {
            this.Name = "Being stun!";
            this.Description = "This card will stun you 1 turn";
            this.Color = Color.Red;
        }
        public override void CreateEvent(Player player, GameMaster gameMaster)
        {
            player.SetState(player.StunnedState);
        }
    }
}
