using CustomProgram.Lands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Command
{
    public class BreakTown:GameCommand
    {
        private CityLand _cityLand;
        public BreakTown(CityLand cityLand)
        {
            _cityLand= cityLand;
        }
        public override void execute()
            {
                Player player = _cityLand.CurrentLandOwner;
                player.RemoveLand(_cityLand);
                _cityLand.ReturnToDefault();
            }
    }
}
