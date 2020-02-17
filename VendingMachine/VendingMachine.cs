using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace VendingMachine
{
    class VendingMachine
    {
        public MachineSafeBox SafeBox { get; set; }

        public OutputDrawer OutputDrawer { get; set; }

        public Panel Panel { get; set; }

        public Door MachineDoor { get; set; }

        public MachineStock MachineStock { get; set; }

        void RefillStock(MachineRefiler machineRefiler)
        {
            List<Product> outOfProducts = MachineStock.getAlmostEmptyStock();
            Dictionary<ProductType, Stack<Product>> order = new Dictionary<ProductType, Stack<Product>>();

            //runs over the list of Product outOfProduct and adding it to new stack of Products
            foreach (Product outOfProduct in outOfProducts)
            {
                order.Add(outOfProduct.ProductType,new Stack<Product>());
                for (int i = 0; i < 10; i++)
                {
                    order[outOfProduct.ProductType]?.Push(outOfProduct);
                }
            }
            
            Dictionary<ProductType, Stack<Product>> delivery = machineRefiler.DeliverProducs(order);

            MachineStock.AddItemsToStock(delivery);

        }

        void Pay()
        {

        }
    }
}