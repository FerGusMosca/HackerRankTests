using HackerrankTest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankTest.week1.exam
{
    public class Week1FindMedianTest
    {
        #region Privte Static Consts

        private static string _FIND_MEDIAN_FILE = "./week1/exam/input.txt";

        #endregion


        #region Private Methods

        public int[] GetNumbers()
        {
            string[] liensCSV = FileToLineArray.ReadFile(_FIND_MEDIAN_FILE);

            List<int> ints = new List<int>();

            int i = 0;
            int size = 0;
            foreach (string line in liensCSV)
            {
                if (i == 0)
                { 
                    size=Convert.ToInt32(line);
                    i++;
                
                }


                string[] numbers = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                numbers.ToList().ForEach(x => ints.Add(Convert.ToInt32(x)));


            }

            return ints.ToArray();
        }

        #endregion


        #region Public Methods

        public void Start()
        {

            int[] numbers = GetNumbers();


            numbers.OrderBy(x => x);

            int pos = 0;
            if (numbers.Length % 2 == 0)
            {
                //Odd numbers
                pos = numbers.Length / 2;

            }
            else
            {
                int half =Convert.ToInt32(Math.Floor(Convert.ToDouble(numbers.Length) / 2)) ;
                pos = half + 1;
            }


            Console.WriteLine(numbers[pos]);

        }

        #endregion

    }
}
