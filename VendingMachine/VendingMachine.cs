using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GetAnswer;
using VendingMachine.Models;

namespace VendingMachine
{
    class VendingMachine
    {
        public SafeBox SafeBox { get; set; }

        public OutputDrawer OutputDrawer { get; set; }

        public IPanel Panel { get; set; }

        public Door MachineDoor { get; set; }

        public MachineStock MachineStock { get; set; }

        private string adminCode = "1234";
        public string AdminCode { get { return adminCode; } private set { adminCode = value; } }

        public VendingMachine()
        {
            MachineStock = Singletons.GetMachineStock();
            SafeBox = Singletons.GetSafeBox();
        }

        public void RefillStock(Refiler refiler)
        {
            List<Product> outOfProducts = MachineStock.GetAlmostEmptyStock();
            Dictionary<ProductType, Stack<Product>> order = new Dictionary<ProductType, Stack<Product>>();

            if (outOfProducts == null)
            {
                //runs over the list of Product outOfProduct and adding it to new stack of Products
                foreach (Product outOfProduct in outOfProducts)
                {
                    order.Add(outOfProduct.ProductType, new Stack<Product>());
                    for (int i = 0; i < 10; i++)
                    {
                        order[outOfProduct.ProductType]?.Push(outOfProduct);
                    }
                }
                Dictionary<ProductType, Stack<Product>> delivery = refiler.DeliverProducs(order);

                MachineStock.AddItemsToStock(delivery);
                Console.WriteLine("The machine are now refilled.");
            }
            else
            {
                Gui.Clear();
                Console.WriteLine("The machine is already full");
            }


        }


        public void SafeBoxOptions()
        {
            int Answer =
                GetAnswers.GetChoiceFromListAsInt("Will you Refill the safebox with coins or emty it for coins", "Refill", "emty");
            switch (Answer)
            {
                case 0:
                    SafeBoxRefillCoins();
                    break;
                case 1:
                    SafeBoxRemoveCoins();
                    break;
            }
        }

        void SafeBoxRefillCoins()
        {
            if (SafeBox.HaveReturnCoin)
            {
                if (SafeBox.getCoinValue >= 500)
                {
                    SafeBoxRemoveCoins();
                }
                else
                {
                    SafeBox.AddCoins();
                }
            }
        }

        void SafeBoxRemoveCoins()
        {
            if (SafeBox.HaveReturnCoin)
            {
                if (SafeBox.getCoinValue >= 500)
                {
                    SafeBox.RemoveCoins();
                }
                else
                {
                    SafeBoxRefillCoins();
                }
            }
        }

        public void Pay()
        {
            int payedCoin = 0;
            int amountToPay = 0;

            int Answer =
                GetAnswers.GetChoiceFromListAsInt("Please inset Coins so its match the product price", "1", "2", "5", "10", "20");

            switch (Answer)
            {
                case 0:
                    payedCoin += 1;
                    break;
                case 1:
                    payedCoin += 2;
                    break;
                case 2:
                    payedCoin += 5;
                    break;
                case 3:
                    payedCoin += 10;
                    break;
                case 4:
                    payedCoin += 20;
                    break;

            }

            if (payedCoin == amountToPay)
            {
                var machineWheel = new MachineWheel();
                machineWheel.Turn();
            }

            if (payedCoin > amountToPay)
            {
                int returnOfCoins = payedCoin - amountToPay;
                Console.WriteLine($"You will get{returnOfCoins} kr.- back");
            }

        }

        public Product BroughtProduct(ProductType productType)
        {
            return MachineStock.RemoveProductFromStock(productType);
        }

    }
}