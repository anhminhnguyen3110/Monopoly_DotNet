using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomProgram.Lands;

namespace CustomProgram.Cards
{
    public class CardFactory
    {
        public Random Random { get; set; } = new Random();
        public Card CreateCard()
        {
            int card = Random.Next(1, 6);
            switch (card)
            {
                case 1:
                    return new AddMoney();
                    break;
                case 2:
                    return new GoToJail();
                    break;
                case 3:
                    return new HeadToAirStation();
                    break;
                case 4:
                    return new HeadToWorldCup();
                    break;
                case 5:
                    return new StealMoney();
                    break;
                case 6:
                    return new Stun();
                    break;
            }
            return null;
        }
    }
}
