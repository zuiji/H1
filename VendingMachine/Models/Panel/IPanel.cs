namespace VendingMachine
{
    public interface IPanel
    {
        bool DrawerStage { get; }

        void AccessPanel();

    }
}