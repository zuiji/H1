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

            int Anwser = GetAnswers.GetChoiceFromListAsInt("Will you open door", "Yes", "No");
            switch (Anwser)
            {
                case 0:
                    Gui.Clear();
                    Console.WriteLine("door is now open");
                    int Answer =
                        GetAnswers.GetChoiceFromListAsInt("Will you Refill the products or Access the SafeBox", "Refill", "safeBox");
                    switch (Answer)
                    {
                        case 0:
                            vendingMachine.RefillStock(new Refiler());
                            break;
                        case 1:
                            vendingMachine.SafeBoxOptions();
                            break;
                    }
                    break;
                case 1:
                    Gui.Clear();
                    Console.WriteLine("Door is not open And you will exit service more");
                    Thread.Sleep(3000);
                    Gui gui = new Gui();
                    gui.AccessUserMode();
                    break;
            }

        }


    }
}