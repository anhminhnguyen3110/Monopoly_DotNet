using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Command
{
    public class MoveCommand : GameCommand
    {
        public static bool isPlayerMoving;
        private Player _player;
        private int _diceResult;
        public MoveCommand(Player player, int diceResult)
        {
            this._player = player;
            this._diceResult = diceResult;
        }

        public int Round(Player player,int numberOfMove, int numberOfLandInTheBoard)
        {
            if(numberOfMove > numberOfLandInTheBoard)
            {
                player.Round += 1;
            }
            return (numberOfMove % numberOfLandInTheBoard);
        }

        public override void execute()
        {
            Player player = this._player;
            int diceResult = this._diceResult;
            int playerDestination = Round(player, player.CurrentLandPosition + diceResult, 36);
            isPlayerMoving = true;
            while (playerDestination != player.CurrentLandPosition)
            {
                player.CurrentLandPosition += 1;
                if (player.CurrentLandPosition == 0)
                {
                    player.AddMoney(300);
                }
            }
            isPlayerMoving = false;
        }
    }
}
