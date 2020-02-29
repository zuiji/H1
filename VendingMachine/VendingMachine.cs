using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

        void RefillStock(Refiler refiler)
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

        void Pay()
        {

        }

        bool InService()
        {
            return Panel is ServicePanel;
        }

        void EnableServiceMode()
        {
            if (!InService() && adminCode == "1234")
            {
                Panel = new ServicePanel();
            }

        }
    }
}