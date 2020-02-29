using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetAnswer;

namespace VendingMachine
{
   public class Gui
    {
        public IPanel AccessPanel;

        public void AccessUserMode()
        {
            AccessPanel = new UserPanel();
            AccessPanel.AccessPanel();
        }

        public void AccessServiceMode()
        {
            AccessPanel = new ServicePanel();
            AccessPanel.AccessPanel();
        }

        public Gui()
        {
            PowerOn();
        }
        public void PowerOn()
        {
           int Anwser =  GetAnswers.GetChoiceFromListAsInt("User Mode or Service Mode", "UserMode", "ServiceMode");
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
    }
}
