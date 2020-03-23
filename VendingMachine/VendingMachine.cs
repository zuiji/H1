using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using GetAnswer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VendingMachine.Models;
using VendingMachine.Models.Coins;

namespace VendingMachine
{
    class VendingMachine
    {

        public SafeBox SafeBox { get; set; }

        public OutputDrawer OutputDrawer { get; set; }

        public IPanel Panel { get; set; }

        public Door MachineDoor { get; set; }

        public MachineStock MachineStock { get; set; }

        public VendingMachine()
        {
            MachineStock = Singletons.GetMachineStock();
            SafeBox = Singletons.GetSafeBox();
        }

        public void RefillStock(Refiler refiler)
        {
            List<Product> outOfProducts = MachineStock.GetAlmostEmptyStock();
            Dictionary<ProductType, Stack<Product>> order = new Dictionary<ProductType, Stack<Product>>();

            if (outOfProducts != null)
            {
                //runs over the list of Product outOfProduct and adding it to new stack of Products
                foreach (Product outOfProduct in outOfProducts)
                {
                    order.Add(outOfProduct.ProductType, new Stack<Product>());
                    for (int i = 0; i < 10; i++)
                    {
                        order[outOfProduct.ProductType]?.Push(outOfProduct.GetCopy());
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

        private bool Pay(int price)
        {
            List<Coin> payedCoin = new List<Coin>();
            while (true)
            {

                if (!int.TryParse(GetAnswers.GetChoiceFromListAsString($"Please inset Coins so its match the product price\nprice: {price}Kr.\nYou have inserted: {payedCoin.Sum(i => i.Value)}Kr.", "1", "2", "5", "10", "20", "Cancel"), out int answer))
                {
                    if (payedCoin.Count > 0)
                    {
                        Console.WriteLine($"You will get {payedCoin.Sum(i => i.Value)} kr.- back");
                    }
                    break;
                }

                payedCoin.Add(new Coin(answer));

                if (payedCoin.Sum(i => i.Value) == price)
                {
                    SafeBox.InputCoins(payedCoin);
                    Singletons.getMachineWheel().Turn();
                    return true;
                }

                if (payedCoin.Sum(i => i.Value) > price)
                {
                    SafeBox.InputCoins(payedCoin);
                    List<Coin> returnOfCoins = SafeBox.GetReturnCoins(payedCoin.Sum(i => i.Value) - price);
                    Console.WriteLine($"You will get {returnOfCoins.Sum(i => i.Value)} kr.- back");
                    Singletons.getMachineWheel().Turn();
                    return true;
                }
            }

            return false;
        }

        public Product BroughtProduct(ProductType productType)
        {//Todo Complete this. 
            if (Singletons.GetMachineStock().OutOfStock(productType))
            {
                throw new OutOfStockException("The product is out of stock");
            }
            if (Pay(Singletons.getProductExamples()[productType].Price))
            {
                return MachineStock.RemoveProductFromStock(productType);
            }
            else
            {
                return null;
            }
        }

        public void StockOptions()
        {
            int answer = GetAnswers.GetChoiceFromListAsInt("What do you want to do", "Refill stock", "See all items in stock", "See number of items in stok");

            switch (answer)
            {
                case 0:
                    RefillStock(new Refiler());
                    Console.WriteLine("press any button to continue");
                    Console.ReadKey(true);
                    break;

                case 1:
                    PrintAllItemsOut();
                    Console.WriteLine("press any button to continue");
                    Console.ReadKey(true);
                    break;
                case 2:
                    PrintNumberOfItems();
                    Console.WriteLine("press any button to continue");
                    Console.ReadKey(true);
                    break;
            }

        }

        private void PrintNumberOfItems()
        {
            foreach (ProductType productsKey in MachineStock.Products.Keys)
            {
                Console.WriteLine($"Number of {Singletons.getProductExamples()[productsKey].Name}: {MachineStock.Products[productsKey].Count}");
            }
        }

        private void PrintAllItemsOut()
        {

            foreach (Stack<Product> products in MachineStock.Products.Values)
            {
                JsonSerializerSettings jss = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None, Formatting = Formatting.Indented };
                string objectAsJsonString = JsonConvert.SerializeObject(products, jss);
                Console.WriteLine(objectAsJsonString);

            }
        }
    }
}
