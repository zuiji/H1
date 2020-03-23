using System;
using System.Threading;

namespace VendingMachine
{
    public class MachineWheel
    {
        private bool isTurning = false;

        public void Turn()
        {
            Console.WriteLine("Your Order is on its way");
            Thread.Sleep(5000);
            Gui.Clear();
            StopTurn();
        }

        void StopTurn()
        {
            Console.WriteLine("Your Push are now in the Drawer");
        }
    }
}