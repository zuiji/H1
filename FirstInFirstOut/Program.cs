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
            Logic logic = new Logic();
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
                        Clear();
                        string name = inputFromUser = standardMessages.InputAddName();
                        byte age = Convert.ToByte(inputFromUser = standardMessages.InputAddAge());
                        logic.AddGuest(guests, name, age);
                        break;
                    case "2":
                        Clear();
                        standardMessages.GuestLeaves(guests);
                        break;
                    case "3":
                        Clear();
                        int numberOfGuests = logic.ShowTheNumberOfGuests(guests);
                        standardMessages.ShowNumbersOfGuests(numberOfGuests);
                        break;
                    case "4":
                        Clear();
                        byte minAge = 0;
                        byte maxAge = 0;
                        minAge = logic.ShowMinAgeOnGuests(guests, minAge);
                        maxAge = logic.ShowMaxAgeOnGuests(guests, maxAge);
                        standardMessages.MinAge(minAge);
                        standardMessages.MaxAge(maxAge);
                        break;
                    case "5":
                        Clear();
                        name = inputFromUser = standardMessages.FindGuest();
                        logic.FindAGuest(guests, name);
                        standardMessages.GuestFound(name);
                        break;
                    case "6":
                        Clear();
                        logic.PrintAllItems(guests);
                        break;
                    default:
                        logic.Exit();
                        break;
                }

            }
        }

        static void Clear()
        {
            Console.Clear();
        }
    }
}
