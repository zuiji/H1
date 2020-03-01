using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GetAnswer;

namespace VendingMachine
{
    static class VendingMachine
    {
        public static SafeBox SafeBox { get; set; }

        public static OutputDrawer OutputDrawer { get; set; }

        public static IPanel Panel { get; set; }

        public static Door MachineDoor { get; set; }

        public static MachineStock MachineStock { get; set; }

        private static string adminCode = "1234";
        public static string AdminCode { get { return adminCode; } private set { adminCode = value; } }

        public static void RefillStock(Refiler refiler)
        {
            List<Product> outOfProducts = MachineStock.GetAlmostEmptyStock();
            Dictionary<ProductType, Stack<Product>> order = new Dictionary<ProductType, Stack<Product>>();

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
        }


        public static void SafeBoxOptions()
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

        static void SafeBoxRefillCoins()
        {
            if (SafeBox.HaveReturnCoin && InService())
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

        static void SafeBoxRemoveCoins()
        {
            if (SafeBox.HaveReturnCoin && InService())
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

        public static void Pay()
        {
            int payedCoin = 0;
            int amountToPay = 0;

            int Answer =
                GetAnswers.GetChoiceFromListAsInt("Please inset Coins so its match the product price", "1", "2", "5", "10", "20");
            switch (Answer)
            {
                case 1:
                    payedCoin += Answer;
                    break;
                case 2:
                    payedCoin += Answer;
                    break;
                case 5:
                    payedCoin += Answer;
                    break;
                case 10:
                    payedCoin += Answer;
                    break;
                case 20:
                    payedCoin += Answer;
                    break;

            }

            if (payedCoin == amountToPay)
            {
                MachineWheel machineWheel = new MachineWheel();
                machineWheel.Turn();
            }

            if (payedCoin > amountToPay)
            {
                int returnOfCoins = payedCoin - amountToPay;
                Console.WriteLine($"You will get{returnOfCoins} kr.- back");
            }

        }

        static void BorughtProduct()
        {

        }

        static bool InService()
        {
            return Panel is ServicePanel;
        }

        static void EnableServiceMode()
        {
            if (!InService() && adminCode == "1234")
            {
                Panel = new ServicePanel();
            }
        }
    }
}