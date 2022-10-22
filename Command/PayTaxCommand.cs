using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Command
{
    public class PayTaxCommand : GameCommand
    {
        private Player _player;
        private double _priceTax;

        public PayTaxCommand(Player player, double priceTax)
        {
            this._player = player;
            this._priceTax = priceTax;
        }
        public override void execute()
        {
            Player player = this._player;
            int price = (int)Math.Floor(_priceTax * player.UpdateTotalMoney());
           
            if (player.Money < price)
            {
                while (player.Money > price)
                {
                    player.Invoker(new SellLandCommand(player));
                }
            }
            player.SubstractMoney(price);
        }
    }
}
