using CustomProgram.Lands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Command
{
    internal class WorldCupCommand : GameCommand
    {
        private CityLand _cityLand;
        private GameMaster _gameMaster;
        public WorldCupCommand(CityLand cityLand, GameMaster gameMaster)
        {
            this._cityLand = cityLand;
            this._gameMaster = gameMaster;
        }
        public override void execute()
        {
            foreach(Land land in _gameMaster.Board.Lands)
            {
                if (land.Purchasable)
                {
                    CityLand cityLand = land as CityLand;
                    if(cityLand.IsWorldCup == true)
                    {
                        cityLand.IsWorldCup = false;
                    }
                }
            }
            _cityLand.IsWorldCup = true;
        }
    }
}
