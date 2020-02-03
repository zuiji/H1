using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstInFirstOut
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Queue<Guest> guests = new Queue<Guest>();
            Logik logic = new Logik();
            StandardMessagesView standardMessages = new StandardMessagesView();
            while (true)
            {
                standardMessages.WelcomeMenu();
                string inputFromUser = "";
                inputFromUser = standardMessages.InputSelectMessage();
                Console.WriteLine();

                switch (inputFromUser)
                {
                    case "1":
                        string name = inputFromUser = standardMessages.InputAddName();
                        byte age = Convert.ToByte(inputFromUser = standardMessages.InputAddAge());
                        logic.AddGuest(guests , name , age);
                        break;
                    case "2":

                       logic.DeleteGuest(guests);
                        break;
                    case "3":
                       int numberOfGuests = logic.ShowTheNumberOfGuests(guests);
                       standardMessages.ShowNumbersOfGuests(numberOfGuests);
                        break;
                    case "4":
                        Console.WriteLine("4");
                        break;
                    case "5":
                        Console.WriteLine("5");
                        break;
                    case "6":
                        logic.PrintAllItems(guests);
                        break;
                    default:
                        logic.Exit();
                        break;
                }

            }
        }
    }
}
