using HackerrankTest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankTest.week2.exam
{

    public class MaxHalfDifference
    { 
        public int Index { get; set; }

        public int Diff { get; set; }
    }

    public class MyMatrixReversor
    {
        #region Protected Static Conts

        public static string _INPUT_FILE = "./week2/exam/input.txt";

        public static string _INPUT_FILE_2 = "./week2/exam/input2.txt";

        #endregion

        #region Protected Attributs

        public int[,] MyMatrix { get; set; }

        protected int N { get; set; }

        #endregion


        #region Public COnstr

        public MyMatrixReversor(int n)
        {
            MyMatrix = new int[2 * n, 2 * n];
            N = 2 * n;

        }

        public int LowerHalfForRow(int row)
        {
            int sum = 0;
            for (int j = 0; j < N / 2; j++)
            {
                sum += MyMatrix[row, j];


            }
            return sum;
        }

        public int UpperHalfForCol(int col)
        {
            int sum = 0;
            for (int i = 0; i < N / 2; i++)
            {
                sum += MyMatrix[i, col];


            }
            return sum;
        }

        public int HigherHalfForRow(int row)
        {

            int sum = 0;
            for (int j = N / 2; j < N; j++)
            {
                sum += MyMatrix[row, j];


            }
            return sum;
        }

        public int LowerHalfForCol(int col)
        {
            int sum = 0;
            for (int i = N - 2; i < N; i++)
            {
                sum += MyMatrix[i, col];


            }
            return sum;
        }

        public void DoReverseRow(int row)
        {

            for (int j = 0; j < N / 2; j++)
            {
                int j2 = N - j - 1;

                int valHalf1 = MyMatrix[row, j];
                int valHalf2 = MyMatrix[row, j2];

                MyMatrix[row, j2] = valHalf1;
                MyMatrix[row, j] = valHalf2;

            }
        }

        public void DoReverseCol(int col)
        {

            for (int i = 0; i < N / 2; i++)
            {
                int i2 = N - i - 1;

                int valHalf1 = MyMatrix[i, col];
                int valHalf2 = MyMatrix[i2, col];

                MyMatrix[i2, col] = valHalf1;
                MyMatrix[i, col] = valHalf2;

            }


        }

        public int SumFirstQuadrant()
        {
            int sum = 0;
            for (int i = 0; i < N / 2; i++)
            {
                for (int j = 0; j < N / 2; j++)
                {

                    sum += MyMatrix[i, j];



                }

            }
            return sum;


        }


        protected void ReOrderCols()
        {

            MaxHalfDifference maxHalfDiff = null;
            //We have to find the column with the highest different btw lower half (back) and higher half (up)
            for (int col = 0; col < MyMatrix.GetLength(1); col++)
            {
                int upperHalfCol = UpperHalfForCol(col);
                int lowerHalfCol = LowerHalfForCol(col);

                if (maxHalfDiff == null)
                {
                    maxHalfDiff = new MaxHalfDifference() { Index = col, Diff = lowerHalfCol - upperHalfCol };

                }
                else
                {
                    int currDif = lowerHalfCol - upperHalfCol;

                    if (currDif > maxHalfDiff.Diff)
                    {
                        maxHalfDiff.Index = col;
                        maxHalfDiff.Diff = currDif;

                    }
                }
            }

            if (maxHalfDiff.Diff > 0)
                DoReverseCol(maxHalfDiff.Index);

        }

        protected void ReOrderRows()
        {
            MaxHalfDifference maxHalfDiff = null;
            for (int row = 0; row < MyMatrix.GetLength(0); row++)
            {
                int lowerHalfRow = LowerHalfForRow(row);
                int higherHalfRow = HigherHalfForRow(row);


                if (maxHalfDiff == null)
                {
                    maxHalfDiff = new MaxHalfDifference() { Index = row, Diff = higherHalfRow - lowerHalfRow };

                }
                else
                {

                    int currDif = higherHalfRow - lowerHalfRow;

                    if (currDif > maxHalfDiff.Diff)
                    {
                        maxHalfDiff.Index = row;
                        maxHalfDiff.Diff = currDif;
                    }
                }
            }

            if (maxHalfDiff.Diff > 0)
                DoReverseRow(maxHalfDiff.Index);

        }


        //I can jus switch one row/column
        // I assume that it is the one that provides the maximun gain 
        public int ReOrder()
        {

            ReOrderCols();

            ReOrderRows();

            return SumFirstQuadrant();

        }


        #endregion

        #region Public Methods

        public void SetRow(int row, int[] rowArr)
        {
          

            if (MyMatrix.Length < row + 1)
                throw new Exception($"Invalid row {row}");

            for (int i = 0; i < rowArr.Length; i++)
            {
                MyMatrix[row, i] = rowArr[i];

            }
        }

        #endregion

    }



    public class Week2FlippingMatrixTest
    {

        private List<List<int>> GetInput()
        {

            List<List<int>> resp = new List<List<int>>();
            string[] lines = FileToLineArray.ReadFile(MyMatrixReversor._INPUT_FILE);

            int queries = Convert.ToInt32(lines[0]);
            int n = Convert.ToInt32(lines[1]);


            List<int> queriesList = new List<int>();
            queriesList.Add(queries);
            resp.Add(queriesList);

            List<int> nList = new List<int>();
            nList.Add(n);
            resp.Add(nList);

            int i = 0;
            foreach(string line in lines)
            {
                if (i < 2)
                {
                    i++;//we skip the first 2 rows already added
                    continue;
                    
                }

                string[] numbers = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);


                List<int> currRow = new List<int>();
                numbers.ToList().ForEach(x => currRow.Add(Convert.ToInt32(x)));

                resp.Add(currRow);


            }


            return resp;
        }


        private List<List<int>> GetInput2()
        {

            List<List<int>> resp = new List<List<int>>();
            string[] lines = FileToLineArray.ReadFile(MyMatrixReversor._INPUT_FILE);
            

            int i = 0;
            foreach (string line in lines)
            {

                string[] numbers = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);


                List<int> currRow = new List<int>();
                numbers.ToList().ForEach(x => currRow.Add(Convert.ToInt32(x)));

                resp.Add(currRow);


            }


            return resp;
        }

        public  int Start(string[] args)
        {
            try
            {
                int inputVer = 1;

                List<List<int>> matrix = null;
                int queries ;
                int n = -1; ;

                if (inputVer == 1)
                {

                    matrix = GetInput();
                    queries = matrix[0][0];
                    n = matrix[1][0];

                }
                else if (inputVer == 2) {

                    matrix = GetInput2();
                    n = matrix.Count / 2;
                }


                if (inputVer == 1)
                {
                    //INPUT OFFICIAL
                    MyMatrixReversor myMatrixReversor = new MyMatrixReversor(n);
                    for (int i = 2; i < 2 + 2 * n; i++)// first 2 rows + 2*n rows
                    {

                        List<int> rowList = matrix[i];

                        int[] rowArr = rowList.ToArray();
                        int row = i - 2;

                        myMatrixReversor.SetRow(row, rowArr);
                    }


                    int quadSum = myMatrixReversor.ReOrder();
                    Console.WriteLine($"First Quadrant Sum : {quadSum}");

                    return quadSum;
                }
                else if (inputVer == 2)
                {

                    //INPUT REAL
                    MyMatrixReversor myMatrixReversor = new MyMatrixReversor(n);
                    for (int i = 0; i < matrix.Count; i++)// first 2 rows + 2*n rows
                    {

                        List<int> rowList = matrix[i];

                        int[] rowArr = rowList.ToArray();
                        int row = i;

                        myMatrixReversor.SetRow(row, rowArr);
                    }


                    int quadSum = myMatrixReversor.ReOrder();
                    Console.WriteLine($"First Quadrant Sum : {quadSum}");

                    return quadSum;


                }
                else
                    throw new Exception($"Input version not implemented :{inputVer}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"CRITICAL ERROR:{ex.Message}");

                return -1;
            }

        }
    }
}
