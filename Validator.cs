using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Validator
    {
        public static double IsValidDouble()
        {
            for (; ; )
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                {
                    return result;
                }
                Console.Write("That input isn't valid, Please type in a valid number:");
            }
        }

        public static bool YesOrNo()
        {
            string input;
            while (true)
            {
                Console.Write("(y/n):");
                input = Console.ReadLine().ToLower();
                if (String.Equals("n", input))
                {
                    return false;
                }
                else if (String.Equals("y", input))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("That is an invalid entry!");
                }
            }

        }

        public static bool OneOrTwo()
        {
            string input;
            while (true)
            {
                Console.WriteLine("Press one to post to twitter");
                Console.WriteLine("Press two to pull from twitter");
                input = Console.ReadLine().ToLower();
                if (String.Equals("1", input))
                {
                    return true;
                }
                else if (String.Equals("2", input))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("That is an invalid entry!");
                }
            }
        }
    }
}
