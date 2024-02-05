using HackerrankTest.week2.exam;
using HackerrankTest.week3.exam;
using HackerrankTest.week4.exam;
using HackerrankTest.week5.exam;
using HackerrankTest.week6.exam;
using HackerrankTest.week7.Huffman_Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankTest
{
    public class Program
    {

        public static void Main(string[] args)
        {

            //Week2FlippingMatrixTest test = new Week2FlippingMatrixTest();
            //test.Start(args);


            //Week3PalindromeIndex test = new Week3PalindromeIndex();
            //int palPos = test.Start("aaa");

            //Week4TruckTour test = new Week4TruckTour();
            //int petrolPosStart = test.Start();
            //Console.WriteLine($"Petrol Pos. Start Pos w/Completion : {petrolPosStart}");

            //Week5Pairs test = new Week5Pairs();
            //int kDifCounter= test.Start();
            //Console.WriteLine($"Number of k-distances found : {kDifCounter}");


            //Week6ShortestReach test = new Week6ShortestReach();
            //test.Start();

            Week7HuffmanTree huffmaTest=new Week7HuffmanTree();
            huffmaTest.Start();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
