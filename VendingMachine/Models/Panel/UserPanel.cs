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
            throw new NotImplementedException();
        }
    }
}
