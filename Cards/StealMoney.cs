using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace CustomProgram.Cards
{
    public class StealMoney : Card
    {
        public StealMoney()
        {
            this.Name = "Thief!";
            this.Description = "This card will steal other money and give it to you";
            this.Color = Color.Green;
        }
        public override void CreateEvent(Player player, GameMaster gameMaster)
        {
            foreach(Player p in gameMaster.Players)
            {
                if(player != p)
                {
                    double amount = (double)Math.Floor(p.Money / 10);
                    p.SubstractMoney(amount);
                    player.AddMoney(amount);
                }
            }
        }
    }
}
