using System.Collections.Generic;

namespace VendingMachine
{
    class MachineSafeBox
    {
        public bool coinInput { get; set; }
        public bool HaveReturnCoin { get; set; }
        public int getCoinValue { get; set; }
        private List<Coin> AmountOfCoins { get; }

        public MachineSafeBox()
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
        void ValueOfCoinsToReturn()
        {

        }
    }
}