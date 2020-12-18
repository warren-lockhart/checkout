using CheckoutRepositories.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutRepositories
{
    public class ItemsDataStore : IDataStore
    {
        private static IEnumerable<Item> Items = new List<Item>()
        {
            new Item { Name = "freddo", Price = 0.5M, Offer = new Offer { Quantity = 2, Price = 0.8M }},
            new Item { Name = "apple", Price = 0.6M },
            new Item { Name = "banana", Price = 0.6M, Offer = new Offer { Quantity = 2, Price = 1.0M }},
            new Item { Name = "orange", Price = 0.4M, Offer = new Offer { Quantity = 3, Price = 0.9M }},
            new Item { Name = "curly wurly", Price = 0.7M }
        };

        public Item Get(string name)
        {
            return Items.FirstOrDefault(i => i.Name == name);
        }

        public bool ItemCheck(string name)
        {
            return Items.Any(i => i.Name == name);
        }
    }
}
