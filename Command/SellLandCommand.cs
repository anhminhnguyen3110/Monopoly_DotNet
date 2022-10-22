using CustomProgram.Lands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Command
{
    internal class SellLandCommand:GameCommand
    {
        private Player _player;

        public SellLandCommand(Player player)
        {
            this._player = player;
        }
        public override void execute()
        {
            int i = _player.CityLands.Count;
            Land cityLand = _player.CityLands[i - 1];
            if (cityLand.GetType() == typeof(BeachLand))
            {
                _player.AddMoney(_player.CityLands[i - 1].RealPrice);
                _player.RemoveLand(_player.CityLands[i - 1]);
                (cityLand as BeachLand).ReturnToDefault();
                return;
            }
            _player.AddMoney(_player.CityLands[i - 1].RealPrice);
            _player.CityLands[i - 1].ReturnToDefault();
            _player.RemoveLand(_player.CityLands[i - 1]);
        }
    }
}
