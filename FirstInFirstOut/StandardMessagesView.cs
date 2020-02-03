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
            Console.WriteLine("2. Delete items");
            Console.WriteLine("3. Show the number of items");
            Console.WriteLine("4. Show min and max items");
            Console.WriteLine("5. Find an item");
            Console.WriteLine("6. Print all item");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
            Console.WriteLine();
        }

        public string InputSelectMessage(string inputFromUser)
        {
            Console.Write("Enter your choice: ");
            inputFromUser = Convert.ToString(Console.ReadKey().KeyChar);
            return inputFromUser;
        }


    }
}
