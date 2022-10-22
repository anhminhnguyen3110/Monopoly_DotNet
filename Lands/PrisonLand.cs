using CustomProgram.Command;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomProgram.Lands
{
    public class PrisonLand : ActivatedLand
    {
        public PrisonLand(int id, string name, Color color):base(id, name, color)
        {
            this._optional = false;
            this.Description = "Player will be in jailed state";
        }
        public override void CreateEvent(Player player)
        {
            player.Invoker(new JailCommand(player));
        }
    }
}
