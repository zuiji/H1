using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstInFirstOut
{


    public class Logic
    {

        public void AddGuest(Queue<Guest> guests, string name, byte age)
        {
            guests.Enqueue(new Guest(name, age));
        }

        public int ShowTheNumberOfGuests(Queue<Guest> guests)
        {
            return guests.Count;
        }

        public byte ShowMinAgeOnGuests(Queue<Guest> guests, byte minAge)
        {
            List<Guest> minAgeList = guests.ToList();
            return Convert.ToByte(minAgeList);
        }

        public byte ShowMaxAgeOnGuests(Queue<Guest> guests)
        {
            return 0;
        }

        public void FindAGuest(Queue<Guest> guests)
        {

        }

        public void PrintAllItems(Queue<Guest> guests)
        {
            foreach (Guest guest in guests)
            {
                Console.WriteLine("{0}, {1}", guest.Name, guest.Age);
            }
        }

        public void Exit()
        {
            Console.WriteLine($"Sorry to see you leave GoodBye");
            Console.ReadKey();
            Environment.Exit(-1);
        }
    }
}