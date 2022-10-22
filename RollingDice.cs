using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class RollingDice
    {

        public Random Random { get; }
        public RollingDice() => (Random, SidesCount) = (new Random(), 6);
        public int SidesCount { get; set; }

        public int[] Roll()
        {
            int[] result = new int[] { Random.Next(1, SidesCount + 1), Random.Next(1, SidesCount + 1) };
            return result;
        }
    }
}
