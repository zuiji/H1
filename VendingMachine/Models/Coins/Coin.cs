using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Models.Coins
{
    public class Coin : IComparable<Coin>
    {
        public int Value { get; }

        public Coin(int value)
        {

            if (Singletons.getallowedCoinValues().Contains(value))
            {
                Value = value;
            }
            else
            {
                throw new ArgumentException("The coin must have a value of 1,2,5,10 or 20");
            }

        }

        public int CompareTo(Coin other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            return Value.CompareTo(other.Value);
        }

        private sealed class ValueRelationalComparer : IComparer<Coin>
        {
            public int Compare(Coin x, Coin y)
            {
                if (ReferenceEquals(x, y))
                {
                    return 0;
                }

                if (ReferenceEquals(null, y))
                {
                    return 1;
                }

                if (ReferenceEquals(null, x))
                {
                    return -1;
                }

                return x.Value.CompareTo(y.Value);
            }
        }

        public static IComparer<Coin> ValueComparer { get; } = new ValueRelationalComparer();

        public override string ToString()
        {
            return $"{Value}Kr.";
        }
    }
}