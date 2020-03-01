using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class UserPanel : IPanel
    {
        public bool DrawerStage { get; }

        public void AccessPanel()
        {
            Console.WriteLine("welcome");
            Console.WriteLine(
                $"You can buy the following products\n{ProductType.CocaCola}\n{ProductType.Bounty}\n{ProductType.Cocio}\n{ProductType.Fanta}\n{ProductType.Mars}\n{ProductType.Snickers}");

        }
    }
}
