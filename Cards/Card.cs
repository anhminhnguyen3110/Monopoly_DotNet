using CustomProgram.Lands;
using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.Cards
{
    public abstract class Card
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public abstract void CreateEvent(Player player, GameMaster gameMaster);
    }
}
