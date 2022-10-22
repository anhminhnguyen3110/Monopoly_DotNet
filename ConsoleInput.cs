using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class ConsoleInput
    {
        public static int ConsoleInt(string message, int min, int max)
        {
            Console.WriteLine(message);
            int num;
            while (true)
            {

                if (Int32.TryParse(Console.ReadLine(), out num) && num >= min && num <= max)
                {
                    Console.WriteLine("\n***\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter an integral value between {0} and {1}.", min, max);
                }
            }
            return num;
        }
        public static string ConsoleString(string message, int min_len, int max_len)
        {
            Console.WriteLine(message);
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input.Length >= min_len && input.Length <= max_len)
                {
                    Console.WriteLine("\n***\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a string of length between {0} and {1}.", min_len, max_len);
                }
            }
            return input;
        }
    }
}
