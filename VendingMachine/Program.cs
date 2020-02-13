using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class VendingMachine
    {
        public MachineSafeBox SafeBox { get; set; }

        public OutputDrawer OutputDrawer { get; set; }

        public ServicePanel ServicePanel { get; set; }

        public Door MachineDoor { get; set; }

        public MachineStock MachineStock { get; set; }

        void RefillStock()
        {

        }

        void Pay()
        {

        }
    }

    class MachineStock
    {
        public List<Stack<Product>> Products { get; set; }
        public MachineStock()
        {
            Products = new List<Stack<Product>>();
            
            //todo set in products
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Drink(), new Drink() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
            //Products.Add(new Stack<Product>() { new Snack(), new Snack() });
        }

        void ProductCheck()
        {

            for (int i = 0; i < Products.Count; i++)
            {

                if (Products[i].FirstOrDefault() is Drink)
                {
                    Console.WriteLine("Dette er en drink");
                }
                else if (Products[i].FirstOrDefault() is Snack)
                {
                    Console.WriteLine("Dette er en snack");
                }
            }
        }

        void RefillStock()
        {

        }

    }

    class MachineWheel
    {
        private bool isTurning = false;

        void Turn()
        {

        }

        void StopTurn()
        {

        }
    }

    class OutputDrawer
    {
        private bool drawerOpen = false;

        void OpenDrawer()
        {

        }

        void CloseDrawer()
        {

        }
    }

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

    class ServicePanel
    {
        public bool inService { get; set; }
        public bool isReady { get; set; }

        void AdminPanel()
        {

        }

        void DoorOpen()
        {

        }

        void OutputDrawerIsOpen()
        {

        }

        void IsInService()
        {

        }

        void IsReady()
        {

        }

        void BuyProduct()
        {

        }
    }

    class VendingMachineAdminServicePanel
    {
        //ToDo
    }
    class machineRefiller
    {
        List<Product> DeliverProducs(List<Product> order)
        {
            throw new NotImplementedException();
        }
    }
    class MachineSafeBox
    {
        public bool coinInput { get; set; }
        public bool HaveReturnCoin { get; set; }
        public int getCoinValue { get; set; }
        private List<Coin> AmountOfCoins { get; }

        public MachineSafeBox()
        {
            AmountOfCoins = new List<Coin>();
            AmountOfCoins.Add(new Coin(1));
            AmountOfCoins.Add(new Coin(5));
            AmountOfCoins.Add(new Coin(10));
            AmountOfCoins.Add(new Coin(20));
            AmountOfCoins.Add(new Coin(5));
            AmountOfCoins.Add(new Coin(2));
            AmountOfCoins.Add(new Coin(10));
            AmountOfCoins.Add(new Coin(20));
            AmountOfCoins.Add(new Coin(20));
            AmountOfCoins.Add(new Coin(10));
        }
        void ValueOfCoinsToReturn()
        {

        }
    }
    class Coin
    {
        public int Value { get; }

        public Coin(int value)
        {
            var allowedValues = new[] { 1, 2, 5, 10, 20 };
            if (allowedValues.Contains(value))
            {
                Value = value;
            }
            else
            {
                throw new ArgumentException("The coin must have a value of 1,2,5,10 or 20");
            }

        }

    }

    public abstract class Product
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int ProductTypeID { get; set; }

        protected Product(string name, int price, int productTypeId)
        {
            this.Name = name;
            this.Price = price;
            this.ProductTypeID = productTypeId;
        }

    }

    public class Drink : Product
    {
        public double Size { get; set; }

        public Drink(string name, int price, int productTypeId, double size) : base(name, price, productTypeId)
        {
            this.Size = size;
        }

    }

    public class Snack : Product
    {
        public int WeightInGrams { get; set; }

        public Snack(string name, int price, int productTypeId, int weightInGrams) : base(name, price, productTypeId)
        {
            this.WeightInGrams = weightInGrams;
        }

    }
    class BroughtProduct
    {
        public int BroughtProductId { get; set; }

        void PopBroghtProduct(MachineStock stock, int productTypeId)
        {

        }
    }


}
