using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Command
{
    public class StunCommand:GameCommand
    {
        private Player _player;
        public StunCommand(Player player)
        {
            this._player = player;
        }
        public override void execute()
        {
            this._player.SetState(this._player.StunnedState);
        }
    }
}
