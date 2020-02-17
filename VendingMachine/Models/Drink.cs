namespace VendingMachine
{
    public class Drink : Product
    {
        public double Size { get; set; }

        public Drink(string name, int price, ProductType productTypeId, double size) : base(name, price, productTypeId)
        {
            this.Size = size;
        }

    }
}