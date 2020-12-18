using CheckoutRepositories.Entities;

namespace CheckoutRepositories
{
    public interface IDataStore
    {
        bool ItemCheck(string name);

        Item Get(string name);
    }
}
