using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Refiler
    {
       public Dictionary<ProductType, Stack<Product>> DeliverProducs(Dictionary<ProductType, Stack<Product>> order)
       {
           Task.Delay(1000).Wait();
           return order;
       }
    }
}