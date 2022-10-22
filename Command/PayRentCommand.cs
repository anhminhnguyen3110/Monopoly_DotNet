using CustomProgram.Lands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Command
{
    public class PayRentCommand : GameCommand
    {
        private Player _player;
        private CityLand _cityLand;

        public PayRentCommand(Player player, CityLand cityLand)
        {
            this._player = player;
            this._cityLand = cityLand; 
        }
        public override void execute()
        {
            Player player = this._player;
            CityLand cityLand = this._cityLand;
            if (player.Money < cityLand.RentingPrice)
            {
                while(player.Money > cityLand.RentingPrice)
                {
                    player.Invoker(new SellLandCommand(player));
                }
            }
            player.SubstractMoney(cityLand.RentingPrice);
            cityLand.CurrentLandOwner.AddMoney(cityLand.RentingPrice);
        }
    }
}


