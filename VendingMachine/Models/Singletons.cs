using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
   static class Singletons
    {
        private static VendingMachine VendingMachine { get; set; }

        public static VendingMachine GetVendingMachine()
        {
            if (VendingMachine == null)
            {
                VendingMachine = new VendingMachine();
            }

            return VendingMachine;
        }

        private static MachineStock MachineStock { get; set; }

        public static MachineStock GetMachineStock()
        {
            if (MachineStock== null)
            {
                MachineStock = new MachineStock();
            }

            return MachineStock;
        }

        private static SafeBox SafeBox { get; set; }

        public static SafeBox GetSafeBox()
        {
            if (SafeBox == null)
            {
                SafeBox = new SafeBox();
            }

            return SafeBox;
        }

        private static MachineWheel MachineWheel {get; set;}

        public static MachineWheel getMachineWheel()
        {
            if (MachineWheel == null)
            {
                MachineWheel = new MachineWheel();
            }

            return MachineWheel;
        }

        private static Gui Gui { get; set; }

        public static Gui getGui()
        {
            if (Gui == null)
            {
                Gui = new Gui();
            }

            return Gui;
        }

        private static IPersistency _filePersistency;

        public static IPersistency GetPersistancyClass()
        {
            if (_filePersistency == null)
            {
                _filePersistency = new FilePersistency();
            }

            return _filePersistency;
        }

        private static Dictionary<ProductType, Product> ProductExamples { get; set; }

        public static Dictionary<ProductType, Product> getProductExamples()
        {
            if (ProductExamples == null)
            {
                ProductExamples = new Dictionary<ProductType, Product>();
                ProductExamples.Add(ProductType.CocaCola, new Drink("cola", 20, ProductType.CocaCola, 0.50));
                ProductExamples.Add(ProductType.Fanta, new Drink("Fanta", 15, ProductType.Fanta, 0.50));
                ProductExamples.Add(ProductType.Cocio, new Drink("Cocio", 12, ProductType.Cocio, 0.50));
                ProductExamples.Add(ProductType.Snickers, new Snack("Snickers", 10, ProductType.Snickers, 50));
                ProductExamples.Add(ProductType.Mars, new Snack("Mars", 10, ProductType.Mars, 50));
                ProductExamples.Add(ProductType.Bounty, new Snack("Bounty", 10, ProductType.Bounty, 50));
            }

            return ProductExamples;
        }

        private static int[] AllowedCoinValues {get; set;}

        public static int[] getallowedCoinValues()
        {
            if (AllowedCoinValues == null)
            {
                AllowedCoinValues = new[] {1, 2, 5, 10, 20};
            }

            return AllowedCoinValues;

        }

    }
}
