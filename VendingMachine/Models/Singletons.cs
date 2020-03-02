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
    }
}
