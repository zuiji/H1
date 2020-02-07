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
            //doing so StandardMessages are able to be cached. 
            StandardMessages standardMessages = new StandardMessages();

            //doing so Program are able to be cached.
            Program program = new Program();

            //creating my Squares sides.
            Square square = new Square(1.25);
            Square square2 = new Square(2.5);
            Square square3 = new Square(8.58);
            Square square4 = new Square(80);
            Square square5 = new Square(6.95);

            //typing out my welcome message.
            standardMessages.WelcomeMessage();

            //typing out Circumference message.
            standardMessages.Circumference(square, square2, square3, square4, square5);

            //typing out Area message.
            standardMessages.Area(square, square2, square3, square4, square5);

            //calling my break method.
            program.Exit();
        }

        //Exit method 
        public void Exit()
        {
            Console.WriteLine($"Sorry to see you leave GoodBye");
            Console.ReadKey();
            Environment.Exit(-1);
        }
    }
}
