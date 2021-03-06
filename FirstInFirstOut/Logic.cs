﻿using System;
using System.Collections.Generic;

namespace FirstInFirstOut
{


    public class Logic
    {
        //Queue that added guest to the Queue
        public void AddGuest(Queue<Guest> guests, string name, byte age)
        {
            guests.Enqueue(new Guest(name, age));
        }

        //returns the amount of guests in the Queue
        public int ShowTheNumberOfGuests(Queue<Guest> guests)
        {
            return guests.Count;
        }

        //returns the lowest age from the Queue og guests
        public byte ShowMinAgeOnGuests(Queue<Guest> guests, byte minAge)
        {
            minAge = guests.Peek().Age;
            foreach (Guest guest in guests)
            {

                if (guest.Age < minAge)
                {
                    minAge = guest.Age;
                }
            }
            return minAge;
        }
        
        //returns the highest age from the Queue og guests
        public byte ShowMaxAgeOnGuests(Queue<Guest> guests, byte maxAge)
        {
            maxAge = guests.Peek().Age;
            foreach (Guest guest in guests)
            {

                if (guest.Age > maxAge)
                {
                    maxAge = guest.Age;
                }
            }
            return maxAge;
        }

        //finding a guest in the Queue
        public string FindAGuest(Queue<Guest> guests, string name)
        {
            name = guests.Peek().Name;
            foreach (Guest guest in guests)
            {
                if (guest.Name == name)
                {
                    name = guest.Name;
                }
                else
                {
                    return "Guest not found on the list";
                }
            }
            return name;
        }

        //printing out all from the list
        public void PrintAllItems(Queue<Guest> guests)
        {
            foreach (Guest guest in guests)
            {
                Console.WriteLine("{0}, {1}", guest.Name, guest.Age);
            }
        }

        //exit
        public void Exit()
        {
            Console.WriteLine($"Sorry to see you leave GoodBye");
            Console.ReadKey();
            Environment.Exit(-1);
        }
    }
}