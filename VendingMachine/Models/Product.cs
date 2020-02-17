namespace VendingMachine
{
    public abstract class Product
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public ProductType ProductType { get; set; }

        protected Product(string name, int price, ProductType productType)
        {
            this.Name = name;
            this.Price = price;
            this.ProductType = productType;
        }

    }
}