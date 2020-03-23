using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VendingMachine.Models;
using VendingMachine.Models.Coins;

namespace VendingMachine
{
    public class FilePersistency : IPersistency
    {

        public void SaveCoins(List<Coin> coins)
        {
            using (FileStream fileStream = new FileStream(@"SaveCoins.VM", FileMode.Create))
            {
                using (StreamWriter steamWriter = new StreamWriter(fileStream))
                {
                    JsonSerializerSettings jss = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None, Formatting = Formatting.Indented };
                    string objectAsJsonString = JsonConvert.SerializeObject(coins, jss);
                    steamWriter.WriteAsync(objectAsJsonString).Wait();
                    steamWriter.Flush();
                }
            }
        }

        public void SaveProducts(Dictionary<ProductType, Stack<Product>> products)
        {
            using (FileStream fileStream = new FileStream(@"Products.VM", FileMode.Create))
            {
                using (StreamWriter steamWriter = new StreamWriter(fileStream))
                {
                    JsonSerializerSettings jss = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };
                    string objectAsJsonString = JsonConvert.SerializeObject(products, jss);
                    steamWriter.WriteAsync(objectAsJsonString).Wait();
                    steamWriter.Flush();
                }
            }
        }

        public List<Coin> LoadCoins()
        {


            using (FileStream fileStream = new FileStream(@"SaveCoins.VM", FileMode.OpenOrCreate))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string objectAsJsonString = streamReader.ReadToEndAsync().Result;
                    JsonSerializerSettings jss = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None };
                    List<Coin> coins = JsonConvert.DeserializeObject<List<Coin>>(objectAsJsonString, jss);
                    return coins;
                }
            }


        }

        public Dictionary<ProductType, Stack<Product>> LoadProducts()
        {
            using (FileStream fileStream = new FileStream(@"Products.VM", FileMode.OpenOrCreate))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string objectAsJsonString = streamReader.ReadToEndAsync().Result;
                    JsonSerializerSettings jss = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    Dictionary<ProductType, Stack<Product>> products =
                        JsonConvert.DeserializeObject<Dictionary<ProductType, Stack<Product>>>(objectAsJsonString, jss);
                    return products;
                }
            }
        }

    }
}
