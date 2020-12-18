using CheckoutRepositories;
using CheckoutServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutServices
{
    public class ScanService : IScanService
    {
        private readonly IDataStore _itemDataStore;
        private ICollection<ScannedItem> _items;

        public ScanService(IDataStore itemDataStore)
        {
            _itemDataStore = itemDataStore;
            _items = new List<ScannedItem>();
        }

        public void Scan(string scannedItem)
        {
            var itemName = scannedItem.ToLower();

            if (!_itemDataStore.ItemCheck(itemName))
            {
                throw new Exception("Item is not in the store, please try another");
            }

            if (!_items.Any(i => i.Name == itemName))
            {
                _items.Add(new ScannedItem { Name = itemName, Quantity = 1 });
            }
            else
            {
                var existingItem = _items.First(i => i.Name == itemName);
                existingItem.Quantity++;
            }
        }

        public double Total()
        {
            var total = 0.0;

            foreach (var item in _items)
            {
                var storeItem = _itemDataStore.Get(item.Name);

                var itemSum = 0.0;

                if (storeItem?.Offer != null)
                {
                    var multiples = item.Quantity / storeItem.Offer.Quantity;
                    var remainder = item.Quantity % storeItem.Offer.Quantity;

                    itemSum = multiples * storeItem.Offer.Price + remainder * storeItem.Price;
                }
                else
                {
                    itemSum = item.Quantity * storeItem.Price;
                }

                total += itemSum;
            }

            return total;
        }
    }
}
