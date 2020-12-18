using CheckoutRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutServices
{
    public class ScanService : IScanService
    {
        private readonly IDataStore _itemDataStore;
        private readonly IShoppingList _shoppingList;

        public ScanService(IDataStore itemDataStore, IShoppingList shoppingList)
        {
            _itemDataStore = itemDataStore;
            _shoppingList = shoppingList;
        }

        public void Scan(string scannedItem)
        {
            var itemName = scannedItem.ToLower();

            if (!_itemDataStore.ItemCheck(itemName))
            {
                throw new Exception("Item is not in the store, please try another");
            }

            _shoppingList.AddOrIncrement(itemName);
        }

        public decimal Total()
        {
            decimal total = 0.0M;

            foreach (var item in _shoppingList.GetList())
            {
                var storeItem = _itemDataStore.Get(item.Name);

                decimal itemSum = 0.0M;

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
