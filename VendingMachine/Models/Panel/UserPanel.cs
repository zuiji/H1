using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        {//todo Add payment. 
            Console.WriteLine("welcome");
            //Enum.Getname returnere alle navne i en enum;
            ProductType productType =
                GetAnswers.GetChoiceFromEnum<ProductType>("What do you want to buy");

            Product product = vendingMachine.BroughtProduct(productType);

            if (product != null)
            {
                EnjoyYourBuy(product);
            }
            else
            {
                SoldOut(product);
            }

        }

        void SoldOut(Product product)
        {
            Console.WriteLine($"sorry your {product} was sold out.");
        }

        void EnjoyYourBuy(Product product)
        {
            Console.WriteLine($"Enjoy your {product}... Have a nice day");
        }
    }
}
