using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankTest.other.zig_zag
{

    public class MyZigZagClass
    {

        #region Constructors
        public MyZigZagClass(int pNElem, string[] pCsvNumbers)
        {

            List<int> queueNumbers = new List<int>();
            for (int i = 0; i < pNElem; i++)
            {
                try
                {

                    queueNumbers.Add(Convert.ToInt32(pCsvNumbers[i]));
                }
                catch (Exception ex)
                {
                    throw new Exception($"Invalid number:{pCsvNumbers[i]}");
                }

            }

            MyArr = queueNumbers.ToArray();
            NElem = pNElem;
            SeparatorIndex = (pCsvNumbers.Length + 1) / 2;
        }

        #endregion

        #region Public Attributes

        public int[] MyArr { get; set; }

        public int SeparatorIndex { get; set; }

        public int NElem { get; set; }

        #endregion

        #region Public Methods

        public void Copy(int[] orig, int[] dest, int start, int length)
        {
            int j = 0;
            while (j < length)
            {
                dest[j] = orig[start + j];
                j++;

            }
        }
        public void DoBubble(int[] myArr, int start, int end, bool reverse)
        {

            for (int i = start; i < end; i++)
            {

                for (int j = i + 1; j < end; j++)
                {

                    int valI = myArr[i];
                    int valJ = myArr[j];

                    if (!reverse)
                    {
                        if (valI > valJ)
                        {
                            myArr[i] = valJ;
                            myArr[j] = valI;
                        }

                    }
                    else
                    {

                        if (valI < valJ)
                        {
                            myArr[i] = valJ;
                            myArr[j] = valI;
                        }
                    }

                }

            }

        }


        public void ZigZagArray()
        {
            DoBubble(MyArr, 0, MyArr.Length, false);


            int firstElemMin = MyArr[0];
            int LastElemMax = MyArr[NElem - 1];


            int divisionIndex = (NElem - 2 + 1) / 2 - 1;//We have to substract 1 because 1 2 3 4 5 6 7 --> x x x y y y y -->the selected index goes to the second half

            int[] firstHalf = new int[divisionIndex];
            int[] secondHalf = new int[divisionIndex + 1];

            Copy(MyArr, firstHalf, 1, firstHalf.Length);
            Copy(MyArr, secondHalf, 1 + firstHalf.Length, secondHalf.Length);

            DoBubble(firstHalf, 0, firstHalf.Length, false);
            DoBubble(secondHalf, 0, secondHalf.Length, true);


            MyArr[0] = firstElemMin;
            MyArr[1 + firstHalf.Length] = LastElemMax;


            for (int i = 0; i < firstHalf.Length; i++)
                MyArr[i + 1] = firstHalf[i];

            for (int i = 0; i < secondHalf.Length; i++)
                MyArr[i + 2 + firstHalf.Length] = secondHalf[i];//2 for the middle element + first element

        }


        public string CSVArr()
        {
            string output = "";
            foreach (int elem in MyArr)
            {
                output += elem + " ";

            }

            return output;
        }


        #endregion


    }

    public class ZigZagExcerise
    {

        static void MainZigZag(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

            int i = 0;
            int nTestCases = 0;
            int nElem = int.MaxValue - 10;
            List<MyZigZagClass> zigzags = new List<MyZigZagClass>();
            while (true)
            {

                string line = Console.ReadLine();

                if (i == 0)
                    nTestCases = Convert.ToInt32(line);
                else if (i == 1)
                {
                    nElem = Convert.ToInt32(line);

                }
                else
                {
                    string[] csvNumbers = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    MyZigZagClass newZigzag = new MyZigZagClass(nElem, csvNumbers);

                    newZigzag.ZigZagArray();

                    zigzags.Add(newZigzag);

                }

                i++;

                if (i >= nTestCases + 2)//The test cases + first 2 rows
                {
                    break;
                }
            }

            foreach (MyZigZagClass currZigZag in zigzags)
            {
                Console.WriteLine(currZigZag.CSVArr());
            }

        }
    }
}
