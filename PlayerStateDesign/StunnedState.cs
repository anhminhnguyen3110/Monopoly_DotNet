using CustomProgram.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.PlayerStateDesign
{
    public class StunnedState : PlayerState
    {
        private int _stunnedTurn = 0;
        public override void Dice(Player player, RollingDice dice)
        {
            player.Invoker(new RollDiceCommand(player, dice));
            if (player.ContinueRoll == true || this._stunnedTurn == 2)
            {
                player.SetState(player.FreeState);
                this._stunnedTurn = 0;
            }
            this._stunnedTurn += 1;
        }

        public override void Move(Player player, int diceResult)
        {
            player.Invoker(new MoveCommand(player, 0));
        }
    }
}
