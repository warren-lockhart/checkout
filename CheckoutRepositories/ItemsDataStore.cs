using CheckoutRepositories.Entities;
using System.Collections.Generic;

namespace CheckoutRepositories
{
    public static class ItemsDataStore
    {
        public static IDictionary<string, Item> Items = new Dictionary<string, Item>()
        {

        };
    }
}
