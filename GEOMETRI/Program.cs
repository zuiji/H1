using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardMessages standardMessages = new StandardMessages();
            Program program = new Program();
            Square square = new Square(1.25);
            Square square2 = new Square(2.5);
            Square square3 = new Square(8.58);
            Square square4 = new Square(80);
            Square square5 = new Square(6.95);


            standardMessages.WelcomeMessage();
            Console.WriteLine("Circumference");
            Console.WriteLine(square.Circumference());
            Console.WriteLine(square2.Circumference());
            Console.WriteLine(square3.Circumference());
            Console.WriteLine(square4.Circumference());
            Console.WriteLine(square5.Circumference());

            Console.WriteLine();
            Console.WriteLine("Area");
            Console.WriteLine(square.Area());
            Console.WriteLine(square2.Area());
            Console.WriteLine(square3.Area());
            Console.WriteLine(square4.Area());
            Console.WriteLine(square5.Area());

            program.Break();
        }

        void Break()
        {
            Console.ReadKey();
        }
    }
}
