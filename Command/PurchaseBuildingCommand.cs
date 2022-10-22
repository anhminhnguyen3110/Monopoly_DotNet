using CustomProgram.Lands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Command
{
    public class PurchaseBuildingCommand : GameCommand
    {
        private Player _player;
        private CityLand _cityLand;
        private int _targetLevel;
        public PurchaseBuildingCommand(Player player, CityLand cityLand, int targetLevel)
        {
            this._player = player;
            this._cityLand = cityLand;
            this._targetLevel = targetLevel;
        }
        public void MakePayment(Player player, CityLand cityLand, int targetLevel)
        {
            double price = 0;
            if (cityLand.CurrentLandOwner == null)
            {
                price = cityLand.RealPrice + (targetLevel - 1) * cityLand.UpgradePrice;
            }
            else if (cityLand.CurrentLandOwner == player)
            {
                if (targetLevel == 5)
                {
                    price = 150;
                }
                else
                {
                    price = (targetLevel - cityLand.Level) * cityLand.UpgradePrice;
                }
            }
            else if (cityLand.CurrentLandOwner != player)
            {
                price = cityLand.SellingPrice;
                if (player.Money < price)
                {
                    return;
                }
                cityLand.CurrentLandOwner.AddMoney(price);
                player.SubstractMoney(price);
                cityLand.ChangeOwner(player);
                return;
            }
            if (player.Money < price)
            {
                return;
            }
            player.SubstractMoney(price);
            cityLand.ChangeOwner(player);
            if(cityLand.UpgradeBuilding(targetLevel) == false)
            {
                return;
            }
            return;
        }

        public override void execute()
        {
            MakePayment(_player, _cityLand, _targetLevel);
            if(_cityLand.GetType() == typeof(BeachLand))
            {
                _player.AddObserver(_cityLand as BeachLand);
            }
        }
    }

}
