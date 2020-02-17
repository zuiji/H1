namespace VendingMachine
{
    class Door
    {
        private bool doorState;

        public bool DoorState
        {
            get => doorState;
            set => doorState = value;
        }

        bool IsDoorOpen()
        {
            return true;
        }
    }
}