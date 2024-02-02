using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankTest.other.encora
{
    public class Encora
    {
        static void MainEncora(string[] args)
        {


            int[] input = new int[] { 7, 8, 9, 11, 12 };

            input = input.OrderBy(x => x).ToArray();


            int minNumber = int.MaxValue;

            foreach (int number in input)
            {
                if (number > 0)
                {

                    if (minNumber > number)
                    {
                        minNumber = number;

                    }

                }

            }


            if (minNumber > 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                int counter = 2;


                while (counter < input.Length)
                {
                    if (!input.Any(x => x == counter))
                    {

                        break;
                    }

                    counter++;

                }
                //TODO eval que no haya discontinues
                Console.WriteLine(counter);
            }

            Console.ReadKey();


        }
    }
}
