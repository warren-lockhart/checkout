using CheckoutRepositories.Entities;
using System.Collections.Generic;

namespace CheckoutRepositories
{
    public static class ItemsDataStore
    {
        public static IEnumerable<Item> Items = new List<Item>()
        {
            new Item { Name = "freddo", Price = 0.5, Offer = new Offer { Quantity = 2, Price = 0.4 }},
            new Item { Name = "apple", Price = 0.6 },
            new Item { Name = "banana", Price = 0.6, Offer = new Offer { Quantity = 2, Price = 1.0 }},
            new Item { Name = "orange", Price = 0.4, Offer = new Offer { Quantity = 3, Price = 0.9 }},
            new Item { Name = "curly wurly", Price = 0.7 }
        };
    }
}
