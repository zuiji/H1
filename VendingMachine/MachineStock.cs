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

            //adding Drinks here
            Products.Add(ProductType.CocaCola, new Stack<Product>(12));
            for (int i = 0; i < 12; i++)
            {
                Products[ProductType.CocaCola]?.Push(new Drink("cola", 20, ProductType.CocaCola, 0.50));
            }
            Products.Add(ProductType.Fanta, new Stack<Product>(12));
            for (int i = 0; i < 12; i++)
            {
                Products[ProductType.Fanta]?.Push(new Drink("Fanta", 20, ProductType.Fanta, 0.50));
            }
            Products.Add(ProductType.Cocio, new Stack<Product>(12));
            for (int i = 0; i < 12; i++)
            {
                Products[ProductType.Cocio]?.Push(new Drink("Cocio", 15, ProductType.Cocio, 0.50));
            }

            //Adding snacks here 
            Products.Add(ProductType.Snickers, new Stack<Product>(12));
            for (int i = 0; i < 12; i++)
            {
                Products[ProductType.Snickers]?.Push(new Snack("Snickers", 10, ProductType.Snickers, 50));
            }
            Products.Add(ProductType.Mars, new Stack<Product>(12));
            for (int i = 0; i < 12; i++)
            {
                Products[ProductType.Mars]?.Push(new Snack("Mars", 10, ProductType.Mars, 50));
            }
            Products.Add(ProductType.Bounty, new Stack<Product>(12));
            for (int i = 0; i < 12; i++)
            {
                Products[ProductType.Bounty]?.Push(new Snack("Bounty", 10, ProductType.Bounty, 50));
            }
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

        public Product RemoveProductFromStock(ProductType productType)
        {

            if (Products.ContainsKey(productType) && Products[productType].Any())
            {
                return Products[productType].Pop();
            }

            return null;
            //MachineStock.Products[productType].Pop();

        }

        public List<Product> GetAlmostEmptyStock()
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