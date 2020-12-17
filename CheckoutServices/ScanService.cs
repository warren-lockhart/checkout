using CheckoutRepositories;
using CheckoutServices.Models;
using System.Collections.Generic;

namespace CheckoutServices
{
    public class ScanService : IScanService
    {
        private readonly IDataStore _itemDataStore;
        private IEnumerable<ScannedItem> _items;

        public ScanService(IDataStore itemDataStore)
        {
            _itemDataStore = itemDataStore;
            _items = new List<ScannedItem>();
        }

        public void Scan(string item)
        {
            throw new System.NotImplementedException();

            // 1. Data Store Check.

            // 2. If not present, add ScannedItem

            // 3. If present, increment.
        }

        public double Total()
        {
            throw new System.NotImplementedException();

            // Loop through scanned items collection

            // 1. Get data store item

            // 2. If there is an offer, get multiples of offer quantity and remainder

            // 3. Get item sum accordingly and add to running total
        }
    }
}
