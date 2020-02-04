using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstInFirstOut
{
    class StandardMessagesView
    {
        public void WelcomeMenu()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("\tH1 Queue Operations Menu\t");
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("1. Add items");
            Console.WriteLine("2. Delete guest");
            Console.WriteLine("3. Show the number of guests");
            Console.WriteLine("4. Show min and max age of guests");
            Console.WriteLine("5. Find a guest");
            Console.WriteLine("6. Print all guests");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
            Console.WriteLine();
        }

        public string InputSelectMessage()
        {
            Console.Write("Enter your choice: ");
            string inputFromUser = Convert.ToString(Console.ReadKey().KeyChar);
            return inputFromUser;
        }

        public string InputAddName()
        {
            Console.WriteLine("Please insert Name ");
            string inputFromUser = Console.ReadLine();
            return inputFromUser;
        }
        public string InputAddAge()
        {
            Console.WriteLine("Please insert Age ");
            string inputFromUser = Console.ReadLine();
            return inputFromUser;
        }

        public void GuestLeaves(Queue<Guest> guests)
        {
            Guest firstToLeave = guests.Dequeue();
            Console.WriteLine($"{firstToLeave.Name} is about to leave.. goodbye");
        }

        public void ShowNumbersOfGuests(int numbersOfGuests)
        {
            Console.WriteLine($"The total numbers of Guests at the party {numbersOfGuests}");
        }

        public void MinAge(byte minAge)
        {
            Console.WriteLine($"The lowest age is {minAge}");
        }
    }
}
