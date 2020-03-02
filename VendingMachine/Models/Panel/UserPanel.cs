using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetAnswer;
using VendingMachine.Models;

namespace VendingMachine
{
    class UserPanel : IPanel
    {
        public bool DrawerStage { get; }
        private VendingMachine vendingMachine = Singletons.GetVendingMachine();
        public void AccessPanel()
        {//todo 
            Console.WriteLine("welcome");
            //Enum.Getname returnere alle navne i en enum;
            int answer =
                GetAnswers.GetChoiceFromListAsInt("What do you want to buy", Enum.GetNames(typeof(ProductType)).ToArray());

            switch (answer)
            {
                case (int)ProductType.CocaCola:
                    vendingMachine.BorughtProduct(ProductType.CocaCola);
                    break;
                case (int)ProductType.Fanta:
                    vendingMachine.BorughtProduct(ProductType.Fanta);
                    break;
                case (int)ProductType.Cocio:
                    vendingMachine.BorughtProduct(ProductType.Cocio);
                    break;
                case (int)ProductType.Snickers:
                    vendingMachine.BorughtProduct(ProductType.Snickers);
                    break;
                case (int)ProductType.Bounty:
                    vendingMachine.BorughtProduct(ProductType.Bounty);
                    break;
                case (int)ProductType.Mars:
                    vendingMachine.BorughtProduct(ProductType.Mars);
                    break;
            }
        }
    }
}
