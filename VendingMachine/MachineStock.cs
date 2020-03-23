using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;

namespace VendingMachine
{
    class MachineStock
    {

        public Dictionary<ProductType, Stack<Product>> Products { get; set; }

        public MachineStock()
        {
            Products = Singletons.GetPersistancyClass().LoadProducts();
            if (Products == null)
            {
                Products = new Dictionary<ProductType, Stack<Product>>();


                foreach (ProductType productExamplesKey in Singletons.getProductExamples().Keys)
                {
                    Products.Add(productExamplesKey, new Stack<Product>(12));
                    for (int i = 0; i < 12; i++)
                    {
                        Products[productExamplesKey]?.Push(Singletons.getProductExamples()[productExamplesKey].GetCopy());
                    }
                }

                Singletons.GetPersistancyClass().SaveProducts(Products);
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
            Singletons.GetPersistancyClass().SaveProducts(Products);
        }

        public Product RemoveProductFromStock(ProductType productType)
        {

            if (Products.ContainsKey(productType) && Products[productType].Any())
            {
                var product = Products[productType].Pop();
                Singletons.GetPersistancyClass().SaveProducts(Products);
                return product;
            }

            throw new OutOfStockException("The product is out of stock");
            //MachineStock.Products[productType].Pop();

        }

        public bool OutOfStock(ProductType productType)
        {
            if (!Products.ContainsKey(productType))
            {
                return true;
            }
            if (!Products[productType].Any())
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public List<Product> GetAlmostEmptyStock()
        {
            List<Product> productAlmostOutOfStock = new List<Product>();
            foreach (ProductType productsId in Products.Keys)
            {
                if (Products[productsId].Count < 3)
                {
                    productAlmostOutOfStock.Add(Singletons.getProductExamples()[productsId].GetCopy());
                }
            }

            return productAlmostOutOfStock;
        }

    }
}