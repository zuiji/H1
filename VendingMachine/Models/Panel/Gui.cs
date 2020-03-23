using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
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
                using (SHA512 shaM = new SHA512Managed())
                {
                    var h = shaM.ComputeHash(Encoding.UTF8.GetBytes(temp));

                    var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                    foreach (var b in h)
                        hashedInputStringBuilder.Append(b.ToString("X2"));


                    if (hashedInputStringBuilder.ToString() == ConfigurationManager.AppSettings["AdminCode"])
                    {
                        AccessPanel.AccessPanel();

                        trys = 3;
                    }
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
                    AccessUserMode();
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
