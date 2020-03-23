using System;
using System.Threading;
using GetAnswer;
using VendingMachine.Models;

namespace VendingMachine
{
    class ServicePanel : IPanel
    {
        VendingMachine vendingMachine = Singletons.GetVendingMachine();
        public bool DrawerStage { get; }
        public void AccessPanel()
        {
            
            Gui.Clear();
            Console.WriteLine("door is now open");
            Thread.Sleep(1000);
            while (true)
            {
                Gui.Clear();
                int answer = GetAnswers.GetChoiceFromListAsInt("Will you Refill the products or Access the SafeBox", "Open stock", "Open safeBox", "Exit to userMode");
                switch (answer)
                {
                    case 0:
                        vendingMachine.StockOptions();
                        break;
                    case 1:
                        Singletons.GetSafeBox().SafeBoxOptions();
                        break;
                    case 2:
                        return;
                }
            }
        }
    }
}