using CustomProgram.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.PlayerStateDesign
{
    public class FreeState : PlayerState
    {
        public override void Dice(Player player, RollingDice dice)
        {
            player.Invoker(new RollDiceCommand(player, dice));
        }

        public override void Move(Player player, int diceResult)
        {
            player.Invoker(new MoveCommand(player, diceResult));
        }
    }
}
