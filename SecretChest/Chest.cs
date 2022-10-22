using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram.SecretChest
{
    public class Chest
    {
        private List<Chest> _chests;
        public double Money { get; set; }
        public Random Random { get; }

        public int Chance { get; set; }
        public int Amount { get; set; }
        public Chest(int chance, double money)
        {
            Random = new Random();
            _chests = new List<Chest>();
            Money = money;
            Chance = chance;
            Amount = (int)Random.Next(1, 3);
        }

        public void Generate()
        {
            int addChestOrNot = (int)Random.Next(1, 100);
            //Console.WriteLine($"addChestOrNot:" + addChestOrNot.ToString());
            //Console.WriteLine($"Chance:" + Chance.ToString());
            if (addChestOrNot < Chance)
            {
                this._chests.Add(new Chest(Chance - 20, Money));
                this._chests[0].Generate();
            }
        }

        public double GetAllMoney()
        {
            double money = 0;
            money += Money * Amount;

            if (_chests.Count > 0)
            {
                money += _chests[0].GetAllMoney();
            }
            return money;
        }
    }
}
