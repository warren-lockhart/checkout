using CheckoutRepositories;
using CheckoutServices;
using Moq;
using System;
using Xunit;

namespace CheckoutTests
{
    public class ScanServiceTests
    {
        private readonly Mock<IDataStore> _mockDataStore;
        private readonly IShoppingList _shoppingList;

        private readonly IScanService _scanService;

        public ScanServiceTests()
        {
            _mockDataStore = MockHelper.GetMockDataStore();
            _shoppingList = new ShoppingList();

            _scanService = new ScanService(_mockDataStore.Object, _shoppingList);
        }

        [Fact]
        public void Scan_ItemNotInStore_ThrowsException()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _scanService.Scan("tangerine"));
        }

        [Fact]
        public void Scan_ItemInStore_DoesNotThrow()
        {
            // Act
            _scanService.Scan("orange");
        }


        [Theory]
        [InlineData("apple", 0.6)]
        [InlineData("orange", 0.4)]
        [InlineData("freddo", 0.5)]
        public void Total_SingleItemNoOffer_ExpectedValue(string item, decimal expected)
        {
            // Act
            _scanService.Scan(item);
            var total = _scanService.Total();

            // Assert
            Assert.Equal(expected, total);
        }

        [Fact]
        public void Total_MultipleItemsOffer_ExpectedValue()
        {
            // Act
            _scanService.Scan("freddo");
            _scanService.Scan("freddo");
            _scanService.Scan("freddo");

            var total = _scanService.Total();

            // Assert
            Assert.Equal(1.3M, total);
        }

        [Fact]
        public void Total_MixedItems_ExpectedValue()
        {
            // Act
            _scanService.Scan("freddo");
            _scanService.Scan("apple");
            _scanService.Scan("freddo");
            _scanService.Scan("orange");

            var total = _scanService.Total();

            // Assert
            Assert.Equal(1.8M, total);
        }

        [Fact]
        public void Total_MixedItems_OrderIrrelevant()
        {
            // Act
            _scanService.Scan("apple");
            _scanService.Scan("orange");
            _scanService.Scan("freddo");
            _scanService.Scan("freddo");

            var total = _scanService.Total();

            // Assert
            Assert.Equal(1.8M, total);
        }
    }
}
