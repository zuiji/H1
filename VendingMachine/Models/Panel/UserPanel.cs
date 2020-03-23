using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
            while (true)
            {
                Console.WriteLine("welcome");

                //Enum.Getname returnere alle navne i en enum;
                ProductType productType =
                    GetAnswers.GetChoiceFromEnum<ProductType>("What do you want to buy");
                Gui.Clear();
                try
                {
                    Product product = vendingMachine.BroughtProduct(productType);

                    if (product != null)
                    {
                        EnjoyYourBuy(product);
                    }
                    else
                    {
                        canceled();
                    }
                }
                catch (OutOfStockException)
                {
                    SoldOut();
                }

            }
        }

        private void canceled()
        {
            Console.WriteLine($"The payment was canceled");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Gui.Clear();
        }

        void SoldOut()
        {
            Console.WriteLine($"sorry the selected product was sold out.");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Gui.Clear();
        }

        void EnjoyYourBuy(Product product)
        {
            Console.WriteLine($"Enjoy your {product.Name}... Have a nice day");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Gui.Clear();
        }
    }
}
