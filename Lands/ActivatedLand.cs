using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Lands
{
    public abstract class ActivatedLand:Land
    {
        protected ActivatedLand(int id, string name, Color color) :base(id, name, color)
        {
            Purchasable = false;
        }

        public double DefaultCost { get; set; }

        public virtual void CreateEvent(Player player) { }
        public virtual void CreateEvent(Player player, CityLand cityLand) { }
    }
}
