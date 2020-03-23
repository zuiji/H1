using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class OutOfStockException : Exception
    {
        public OutOfStockException(string message) : base(message)
        {
            
        }
    }
}
