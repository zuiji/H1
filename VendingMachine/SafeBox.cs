using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GetAnswer;
using VendingMachine.Models;
using VendingMachine.Models.Coins;

namespace VendingMachine
{
    class SafeBox
    {
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

        public int GetCoinValue
        {
            get { return TotalValueOfCoinsInSafeBox(); }
        }

        public List<Coin> GetReturnCoins(int value)
        {
            List<Coin> returnCoins = new List<Coin>();

            while (returnCoins.Sum(i => i.Value) < value)
            {
                var missingValue = value - returnCoins.Sum(i => i.Value);

                bool coinExists = false;
                foreach (int i in Singletons.getallowedCoinValues().OrderByDescending(i => i))
                {
                    if (missingValue >= i)
                    {
                        if (AmountOfCoins.Exists(x => x.Value == i))
                        {
                            returnCoins.Add(AmountOfCoins.FirstOrDefault(x => x.Value == i));
                            AmountOfCoins.Remove(AmountOfCoins.FirstOrDefault(x => x.Value == i));
                            coinExists = true;
                            break;
                        }
                    }
                }

                if (!coinExists)
                {
                    throw new Exception("Not able to return the requested amount of coins");
                }
            }
            IPersistency filePersistency = Singletons.GetPersistancyClass();
            filePersistency.SaveCoins(AmountOfCoins);
            return returnCoins;
        }

        private List<Coin> AmountOfCoins { get; set; }

        public SafeBox()
        {
            AmountOfCoins = Singletons.GetPersistancyClass().LoadCoins();
            if (AmountOfCoins == null)
            {
                AddCoins();
            }

        }

        public void InputCoins(List<Coin> coins)
        {
            AmountOfCoins.AddRange(coins);
            Singletons.GetPersistancyClass().SaveCoins(AmountOfCoins);
        }

        public void InputCoins(Coin coin)
        {
            AmountOfCoins.Add(coin);
            Singletons.GetPersistancyClass().SaveCoins(AmountOfCoins);
        }

        private void AddCoins()
        {
            if (AmountOfCoins == null)
            {
                AmountOfCoins = new List<Coin>();
            }
            Random rand = new Random();

            while (GetCoinValue <= 500)
            {
                AmountOfCoins.Add(new Coin(Singletons.getallowedCoinValues()[rand.Next(Singletons.getallowedCoinValues().Length - 1)]));
                Console.WriteLine($"You added a coin with the value {AmountOfCoins.LastOrDefault()} to the machine");
            }
            Singletons.GetPersistancyClass().SaveCoins(AmountOfCoins);
        }

        public void SeeAllCoins()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Coin coin in AmountOfCoins)
            {
                builder.AppendLine(coin.ToString());
            }

            Console.WriteLine(builder.ToString());
        }

        public void RemoveCoins()
        {

            while (GetCoinValue >= 520)
            {
                AmountOfCoins = AmountOfCoins.OrderByDescending(i => i.Value).ToList();
                Console.WriteLine($"Removing a coin with the value {AmountOfCoins.FirstOrDefault()} from the machine");
                AmountOfCoins.RemoveAt(0);
            }
            Singletons.GetPersistancyClass().SaveCoins(AmountOfCoins);

            Console.WriteLine($"You do now have a Total amount in the machine on {GetCoinValue}Kr.");
        }

        int TotalValueOfCoinsInSafeBox()
        {
            int value = 0;

            foreach (Coin coin in AmountOfCoins)
            {
                value += coin.Value;
            }
            return value;
        }

        public void SafeBoxOptions()
        {
            int answer =
                GetAnswers.GetChoiceFromListAsInt("What do you wish to do", "Refill coins", "Empty coins", "See all coins", "See total coin value");
            switch (answer)
            {
                case 0:
                    SafeBoxRefillCoins();
                    Console.WriteLine("press any button to continue");
                    Console.ReadKey(true);
                    break;
                case 1:
                    SafeBoxRemoveCoins();
                    Console.WriteLine("press any button to continue");
                    Console.ReadKey(true);
                    break;
                case 2:
                    SeeAllCoins();
                    Console.WriteLine("press any button to continue");
                    Console.ReadKey(true);
                    break;
                case 3:
                    Console.WriteLine($"The machine has {GetCoinValue}Kr. in coins");
                    Console.WriteLine("press any button to continue");
                    Console.ReadKey(true);
                    break;
            }
        }

        void SafeBoxRefillCoins()
        {
            AddCoins();
        }

        void SafeBoxRemoveCoins()
        {
            RemoveCoins();
        }
    }
}