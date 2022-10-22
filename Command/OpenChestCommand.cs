using CustomProgram.SecretChest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Command
{
    public class OpenChestCommand : GameCommand
    {
        private Player _player;
        public OpenChestCommand(Player player)
        {
            this._player = player;
        }
        public override void execute()
        {
            Chest chest = new Chest(100, 30);
            chest.Generate();
            this._player.AddMoney(chest.GetAllMoney());
        }
    }
}
