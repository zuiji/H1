using System;
using System.Collections.Generic;

namespace VendingMachine
{
    class SafeBox
    {
        public bool coinInput { get; set; }
        public bool HaveReturnCoin
        {
            get
            {
                if (AmountOfCoins.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public int getCoinValue
        {
            get { return ValueOfCoinsToReturn(); }
        }

        private List<Coin> AmountOfCoins { get; set; }

        public SafeBox()
        {
            AddCoins();
        }

        public void AddCoins()
        {
            AmountOfCoins = new List<Coin>();
            AmountOfCoins.Add(new Coin(1));
            AmountOfCoins.Add(new Coin(5));
            AmountOfCoins.Add(new Coin(10));
            AmountOfCoins.Add(new Coin(20));
            AmountOfCoins.Add(new Coin(5));
            AmountOfCoins.Add(new Coin(2));
            AmountOfCoins.Add(new Coin(10));
            AmountOfCoins.Add(new Coin(20));
            AmountOfCoins.Add(new Coin(20));
            AmountOfCoins.Add(new Coin(10));
        }

        public void RemoveCoins()
        {
            foreach (Coin amountOfCoin in AmountOfCoins)
            {
                while (getCoinValue >= 500)
                {
                    AmountOfCoins.RemoveAt(0);
                }
            }

            Console.WriteLine($"you do now have a Total amount in the machine on {getCoinValue}");
        }

        int ValueOfCoinsToReturn()
        {
            int value = 0;
            foreach (Coin coin in AmountOfCoins)
            {
                value += coin.Value;
            }
            return value;
        }
    }
}