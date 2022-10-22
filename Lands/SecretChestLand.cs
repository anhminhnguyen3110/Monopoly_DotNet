using CustomProgram.Command;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CustomProgram.Lands
{
    public class SecretChestLand : ActivatedLand
    {
        public SecretChestLand(int id, string name, Color color):base(id, name, color)
        {
           this._optional = false;
            this.Description = "Player will have a chance to open chest and in chest will have another chest";
        }
        public override void CreateEvent(Player player)
        {
            player.Invoker(new OpenChestCommand(player));
        }
    }
}
