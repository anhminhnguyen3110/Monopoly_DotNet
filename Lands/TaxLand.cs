using CustomProgram.Command;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CustomProgram.Lands
{
    public class TaxLand : ActivatedLand
    {
        public TaxLand(int id, string name, Color color):base(id, name, color)
        {
            this._optional = false;
            this.Description = "Player have to pay tax here";
            this.DefaultCost = 0.1;
        }
        public override void CreateEvent(Player player)
        {
            player.Invoker(new PayTaxCommand(player, DefaultCost));
        }
    }
}
