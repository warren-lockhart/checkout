using CheckoutServices.Models;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutServices
{
    public class ShoppingList : IShoppingList
    {
        private readonly ICollection<ScannedItem> _activeList;

        public ShoppingList()
        {
            _activeList = new List<ScannedItem>();
        }

        public void AddOrIncrement(string name)
        {
            if (!_activeList.Any(i => i.Name == name))
            {
                _activeList.Add(new ScannedItem { Name = name, Quantity = 1 });
            }
            else
            {
                var existingItem = _activeList.First(i => i.Name == name);
                existingItem.Quantity++;
            }
        }

        public IEnumerable<ScannedItem> GetList()
        {
            return _activeList;
        }
    }
}
