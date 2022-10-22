using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomProgram.Lands
{
    public class AirportLand : ActivatedLand
    {
        public AirportLand(int id, string name, Color color):base(id, name, color)
        {
            this.Description = "Players will pay $50 to reach any land has not had an owner or their land";
            this._optional = true;
        }
    }
}
