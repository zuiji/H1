using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    class MachineStock
    {
        public Dictionary<ProductType, Stack<Product>> Products { get; set; }
        public MachineStock()
        {
            Products = new Dictionary<ProductType, Stack<Product>>();

            //todo set in products
            Products.Add(ProductType.CocaCola, new Stack<Product>(12));
            for (int i = 0; i < 12; i++)
            {
                Products[ProductType.CocaCola]?.Push(new Drink("cola", 20, ProductType.CocaCola, 0.50));
            }

            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
        }

        public void AddItemsToStock(Dictionary<ProductType, Stack<Product>> items)
        {
            foreach (var itemsKey in items.Keys)
            {
                if (!Products.ContainsKey(itemsKey))
                {
                    Products.Add(itemsKey, new Stack<Product>(12));
                }
                while (items[itemsKey].Any())
                {   //adds to Products and pops from items 
                    Products[itemsKey].Push(items[itemsKey].Pop());
                }
            }
        }

        void ProductCheck()
        {
            foreach (var productsKey in Products.Keys)
            {

                if (Products[productsKey].FirstOrDefault() is Drink)
                {
                    Console.WriteLine("Dette er en drink");
                }
                else if (Products[productsKey].FirstOrDefault() is Snack)
                {
                    Console.WriteLine("Dette er en snack");
                }
            }
        }

        public List<Product> getAlmostEmptyStock()
        {
            List<Product> productAlmostOutOfStock = new List<Product>();
            foreach (ProductType productsId in Products.Keys)
            {
                if (Products[productsId].Count < 3)
                {
                    productAlmostOutOfStock.Add(Products[productsId].Peek());
                }
            }

            return productAlmostOutOfStock;
        }

    }
}