using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Command
{
    public class RollDiceCommand : GameCommand
    {
        private Player _player;
        private RollingDice _rollDice;
        public RollDiceCommand(Player player, RollingDice rollDice)
        {
            this._player = player;
            this._rollDice = rollDice;
        }
        public override void execute()
        {
            int[] dice = _rollDice.Roll();
            if (dice[0] == dice[1])
            {
                _player.DoubleDice += 1;
                _player.ContinueRoll = true;
            }
            this._player.DiceResult = new Tuple<int,int>(dice[0], dice[1]);
        }

    }
}
