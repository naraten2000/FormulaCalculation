using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            while (!exit)
            {
                WriteRule();

                var input = Console.ReadLine();
                var result = Calculate(input);
                Console.WriteLine(string.Format(@"Input:""{0}"" Result:{1}", input, result));
                Console.WriteLine();
                Console.WriteLine("Do you want to try again? If so, press Y, otherwist, press Enter");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                if (key.Key != ConsoleKey.Y)
                {
                    exit = true;
                }
            }
        }

        private static double Calculate(string input)
        {
            // Remove all spaces
            input = input.Replace(" ", string.Empty);
            var operation = new Operation(input);
            var result = operation.CalculateResult();
            return result;
        }

        private static void WriteRule()
        {
            Console.WriteLine("Please enter formula:");
            Console.WriteLine();
        }
    }
}
