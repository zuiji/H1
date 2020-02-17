using System;

namespace VendingMachine
{
    class Panel
    {
        public bool inService { get; set; }
        public bool isReady { get; set; }
        private string adminCode = "1234";



        bool DoorOpen()
        {
            return false;
        }

        bool OutputDrawerIsOpen()
        {
            return false;
        }

        bool IsInService()
        {
            return inService = false;
        }

        bool IsReady()
        {
            return true;
        }

        void AdminPanel()
        {
            if (inService == (adminCode == "1234"))
            {
                ServicePanel servicePanel = new ServicePanel();
                servicePanel.AdminMode();
            }
            else
            {
                throw new ArgumentException("You need to set it in service");
            }

        }
        void BuyProduct()
        {

        }
    }
}