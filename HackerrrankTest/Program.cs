using HackerrankTest.week2.exam;
using HackerrankTest.week3.exam;
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


            Week3PalindromeIndex test= new Week3PalindromeIndex();
            int palPos=test.Start("aaa");

            Console.WriteLine($"Palyndrome position: {palPos}");


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
