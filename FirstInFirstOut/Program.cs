using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstInFirstOut
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Guest> guests = new Queue<Guest>();

            StandardMessagesView standardMessages = new StandardMessagesView();
            standardMessages.WelcomeMenu();
            string inputFromUser = "";
            inputFromUser = standardMessages.InputSelectMessage(inputFromUser);
            Console.WriteLine();

            switch (inputFromUser)
            {
                case "1":
                    Console.WriteLine("1");
                    break;
                case "2":
                    Console.WriteLine("2");
                    break;
                case "3":
                    Console.WriteLine("3");
                    break;
                case "4":
                    Console.WriteLine("4");
                    break;
                case "5":
                    Console.WriteLine("5");
                    break;
                case "6":
                    Console.WriteLine("6");
                    break;
                default:
                    Console.WriteLine("7");
                    break;
            }

        }

        void AddGuest()
        {

        }
    }
}
