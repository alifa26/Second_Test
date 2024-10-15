using System;
using System.IO;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;


namespace BinarySearchTree
{
   
}

namespace ConsoleApp2{
    public class Program {

        static double devides(double num, double denum) {
            if (denum == 0)
            { throw new System.DivideByZeroException(); }
            return num / denum;
        }
        static void safeDivide(double num, double denum) {


            try
            {
                Console.WriteLine("{0} devide by {1} equals: {2}", num, denum, devides(num, denum));
            }
            catch (DivideByZeroException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public class Circle
        {
            
            public double Radius { get; set; }

            public Circle(double radius)
            {
                Radius = radius;
            }

            public double Area()
            {
                return Math.PI * Radius * Radius;
            }

            public double Circumference()
            {
                return 2 * Math.PI * Radius;
            }
        }


        static void Main(string[] args)
        {
            string content = File.ReadAllText("sample.txt");
            Console.WriteLine(content);
            
        }
    }    

}
