using System.Collections.Generic;
using VendingMachine.Models.Coins;

namespace VendingMachine
{
    public interface IPersistency
    {
        void SaveCoins(List<Coin> coins);
        void SaveProducts(Dictionary<ProductType, Stack<Product>> products);
        List<Coin> LoadCoins();
        Dictionary<ProductType, Stack<Product>> LoadProducts();
    }
}