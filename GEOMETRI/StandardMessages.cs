using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometry
{
    public class StandardMessages
    {

        //This is my welcomeMessages 
        public void WelcomeMessage()
        {
            Console.WriteLine(">>>--- Welcome to geometry exercise A ---<<<");
            Console.WriteLine();
        }

        //This is my Circumference messages and it does type out the circumference's 
        public void Circumference(Square square, Square square2, Square square3, Square square4, Square square5)
        {
            Console.WriteLine("Circumference");
            Console.WriteLine(square.Circumference());
            Console.WriteLine(square2.Circumference());
            Console.WriteLine(square3.Circumference());
            Console.WriteLine(square4.Circumference());
            Console.WriteLine(square5.Circumference());
            Console.WriteLine();
        }

        //This is my Area Messages
        public void Area(Square square, Square square2, Square square3, Square square4, Square square5)
        {
            Console.WriteLine("Area");
            Console.WriteLine(square.Area());
            Console.WriteLine(square2.Area());
            Console.WriteLine(square3.Area());
            Console.WriteLine(square4.Area());
            Console.WriteLine(square5.Area());
        }

    }
}
