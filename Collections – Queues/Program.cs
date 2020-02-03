using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections___Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adds Queue with name primes and data type int
            Queue<int> primes = new Queue<int>();

            //adder data til Primes Queue
            primes.Enqueue(3);
            primes.Enqueue(4);
            primes.Enqueue(5);
            primes.Enqueue(6);
            primes.Enqueue(7);

            //making total variable 
            int total = 0;

            // using a wile to check on Queue and adding the inserts to total.
            while (primes.Count > 0)
            {
                total += primes.Dequeue();
                
            }

            //printing out total of Queues
            Console.WriteLine($"Total = {total}");


        }
    }
}
