using CheckoutRepositories;
using CheckoutRepositories.Entities;
using Moq;
using System.Collections.Generic;

namespace CheckoutTests
{
    public static class MockHelper
    {
        public static Mock<IDataStore> GetMockDataStore()
        {
            var mockDataStore = new Mock<IDataStore>();

            mockDataStore.Setup(r => r.ItemCheck(It.IsAny<string>())).Returns((string item) =>
            {
                var expectedItems = new List<string>() { "orange", "apple", "freddo" };

                if (expectedItems.Contains(item))
                {
                    return true;
                }

                return false;
            });

            mockDataStore.Setup(r => r.Get(It.IsAny<string>())).Returns((string item) =>
            {
                if (item == "orange")
                {
                    return new Item { Name = "orange", Price = 0.4M, Offer = new Offer { Quantity = 3, Price = 0.9M } };
                }

                if (item == "apple")
                {
                    return new Item { Name = "apple", Price = 0.6M };
                }

                if (item == "freddo")
                {
                    return new Item { Name = "freddo", Price = 0.5M, Offer = new Offer { Quantity = 2, Price = 0.8M } };
                }

                return new Item();
            });

            return mockDataStore;
        }
    }
}
