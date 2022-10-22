using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomProgram.Cards;
using SplashKitSDK;

namespace CustomProgram.Lands
{
    public class ChanceLand : ActivatedLand
    {
        private readonly List<Card> _cards;
        public ChanceLand(int id, string name, Color color) : base(id, name, color)
        {
            _cards = new List<Card> { };
            this._optional = false;
            this.Description = "Player draw one card and do the effect in that card";
        }

        public void AddNewCard(Card card)
        {
            this._cards.Add(card);
        }

        public List<Card> Cards
        {
            get
            {
                return this._cards;
            }
        }

        public override void CreateEvent(Player player)
        {
        }
    }
}
