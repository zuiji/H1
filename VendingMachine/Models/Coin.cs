using System;
using System.Linq;

namespace VendingMachine
{
    class Coin
    {
        public int Value { get; }

        public Coin(int value)
        {
            var allowedValues = new[] { 1, 2, 5, 10, 20 };
            if (allowedValues.Contains(value))
            {
                Value = value;
            }
            else
            {
                throw new ArgumentException("The coin must have a value of 1,2,5,10 or 20");
            }

        }

    }
}