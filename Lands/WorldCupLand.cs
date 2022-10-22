using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Lands
{
    public class WorldCupLand : ActivatedLand
    {
        public WorldCupLand(int id, string name, Color color) : base(id, name, color)
        {
            this._optional = true;
            this.Description = "Pay $50 to increase rent price of a house";
        }
    }
}
