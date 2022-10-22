using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.PlayerStateDesign
{
    public abstract class PlayerState
    {
        public abstract void Move(Player player, int diceResult);
        public abstract void Dice(Player player, RollingDice dice);
    }
}
