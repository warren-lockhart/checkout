using CheckoutServices.Models;
using System.Collections.Generic;

namespace CheckoutServices
{
    public interface IShoppingList
    {
        void AddOrIncrement(string name);

        IEnumerable<ScannedItem> GetList();
    }
}
