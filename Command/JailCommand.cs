using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Command
{
    public class JailCommand:GameCommand
    {
        private Player _player;
        public JailCommand(Player player)
        {
            this._player = player;
        }
        public override void execute()
        {
            this._player.CurrentLandPosition = 9;
            this._player.ContinueRoll = false;
            this._player.DoubleDice = 0;
            this._player.SetState(this._player.JailedState);
        }
    }
}
