using CustomProgram.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Cards
{
    public class GoToJail : Card
    {
        public GoToJail()
        {
            this.Name = "Jailed";
            this.Description = "This card will jail you";
            this.Color = Color.Red;
        }
        public override void CreateEvent(Player player, GameMaster gameMaster)
        {
            player.Invoker(new JailCommand(player));
        }
    }
}
