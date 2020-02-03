using System;
using System.Collections.Generic;

namespace FirstInFirstOut
{


    public class Logik
    {

        public void AddGuest(Queue<Guest> guests, string name, byte age)
        {
            guests.Enqueue(new Guest(name, age));

        }

        public void DeleteGuest(Queue<Guest> guests)
        {
            guests.Dequeue();
        }

        public int ShowTheNumberOfGuests(Queue<Guest> guests)
        {
            return guests.Count;
        }

        public void ShowMinAndMaxGuests()
        {

        }

        public void FindAnItem()
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