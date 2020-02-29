namespace VendingMachine
{
    public class Snack : Product
    {
        public int WeightInGrams { get; set; }

        public Snack(string name, int price, ProductType productTypeId, int weightInGrams) : base(name, price, productTypeId)
        {
            this.WeightInGrams = weightInGrams;
        }

    }
}