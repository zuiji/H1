using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GetAnswer;
using VendingMachine.Models;

namespace VendingMachine
{
    public class Gui
    {
        private VendingMachine vendingMachine = Singletons.GetVendingMachine();
        public IPanel AccessPanel;

        public void AccessUserMode()
        {
            AccessPanel = new UserPanel();
            AccessPanel.AccessPanel();
        }

        public void AccessServiceMode()
        {
            AccessPanel = new ServicePanel();
            Console.WriteLine("Enter your Service Code...");
            byte trys = 0;

            while (trys < 3)
            {
                Console.Write("Admin Code :");
                string temp = Console.ReadLine();

                if (temp == vendingMachine.AdminCode)
                {
                    AccessPanel.AccessPanel();

                    trys = 3;
                }
                trys++;
            }

            if (trys == 3)
            {

                Console.WriteLine("You did use to many try and will return to user panel.");
                Thread.Sleep(3000);

            }
        }

        public Gui()
        {

        }
        public void PowerOn()
        {
            int Anwser = GetAnswers.GetChoiceFromListAsInt("User Mode or Service Mode", "UserMode", "ServiceMode");
            switch (Anwser)
            {
                case 0:
                    AccessUserMode();
                    break;
                case 1:
                    AccessServiceMode();
                    break;
            }
        }

        public void PowerOff()
        {
            Environment.Exit(0);
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}
