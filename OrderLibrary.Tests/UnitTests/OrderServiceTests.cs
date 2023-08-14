using System;
using Xunit;
using Moq;
using OrderLibrary.Models;
using OrderLibrary.Services;
using OrderLibrary.Repositories;
using OrderLibrary.Tests.Mocks;
using OrderLibrary.Services.Interfaces;

namespace OrderLibrary.Tests.UnitTests
{
    /// <summary>
    /// Contains unit tests for the OrderService.
    /// </summary>
    public class OrderServiceTests
    {
        private readonly IOrderService _service;
        private readonly Mock<IDateTimeProvider> _mockDateTimeProvider = new Mock<IDateTimeProvider>();
        private readonly IOrderRepository _mockOrderRepository = new MockOrderRepository();

        /// <summary>
        /// Initializes a new instance of the OrderServiceTests class.
        /// </summary>
        public OrderServiceTests()
        {
            // Set up a fixed date-time for testing purposes.
            _mockDateTimeProvider.Setup(d => d.Now).Returns(new DateTime(2023, 8, 10, 0, 0, 0, DateTimeKind.Utc));

            // Initialize the OrderService with mock dependencies.
            _service = new OrderService(_mockOrderRepository, MockOrderConfiguration.GetDefault(), _mockDateTimeProvider.Object);
        }

        /// <summary>
        /// Tests if the PlaceOrder method returns a valid order with the correct discount applied based on quantity.
        /// </summary>
        [Theory]
        [InlineData(5, 0)]       // No discount for 5 items
        [InlineData(10, 0.05)]  // 5% discount for 10 items
        [InlineData(60, 0.15)]  // 15% discount for 60 items
        public void PlaceOrder_WithDifferentQuantities_ShouldApplyCorrectDiscount(int quantity, decimal expectedDiscountRate)
        {
            var kit = new Kit { KitType = "DNA", BasePrice = MockOrderConfiguration.GetDefault().BasePriceForDiscount };
            var order = _service.PlaceOrder(1, kit, quantity, _mockDateTimeProvider.Object.Now.AddDays(1));

            decimal expectedTotal = kit.BasePrice * quantity * (1 - expectedDiscountRate);

            Assert.NotNull(order);
            Assert.Equal(quantity, order.Quantity);
            Assert.Equal(expectedTotal, order.TotalPrice);
        }

        /// <summary>
        /// Tests if the PlaceOrder method throws an exception when provided with a past delivery date.
        /// </summary>
        [Fact]
        public void PlaceOrder_WithPastDeliveryDate_ShouldThrowException()
        {
            var kit = new Kit { KitType = "DNA", BasePrice = MockOrderConfiguration.GetDefault().BasePriceForDiscount };

            Assert.Throws<ArgumentException>(() => _service.PlaceOrder(1, kit, 10, _mockDateTimeProvider.Object.Now.AddDays(-1)));
        }

        /// <summary>
        /// Tests if the PlaceOrder method throws an exception when provided with a zero quantity.
        /// </summary>
        [Fact]
        public void PlaceOrder_WithZeroQuantity_ShouldThrowException()
        {
            var kit = new Kit { KitType = "DNA", BasePrice = MockOrderConfiguration.GetDefault().BasePriceForDiscount };

            Assert.Throws<ArgumentException>(() => _service.PlaceOrder(1, kit, 0, _mockDateTimeProvider.Object.Now.AddDays(1)));
        }

        /// <summary>
        /// Tests if the PlaceOrder method throws an exception when provided with a quantity exceeding the maximum allowed.
        /// </summary>
        [Fact]
        public void PlaceOrder_WithExcessiveQuantity_ShouldThrowException()
        {
            var kit = new Kit { KitType = "DNA", BasePrice = MockOrderConfiguration.GetDefault().BasePriceForDiscount };

            Assert.Throws<ArgumentException>(() => _service.PlaceOrder(1, kit, 1000, _mockDateTimeProvider.Object.Now.AddDays(1)));
        }

        /// <summary>
        /// Tests if the ListAllCustomerOrders method returns the correct number of orders for a specific customer.
        /// </summary>
        [Fact]
        public void ListAllCustomerOrders_ShouldReturnCorrectOrders()
        {
            var kit = new Kit { KitType = "DNA", BasePrice = MockOrderConfiguration.GetDefault().BasePriceForDiscount };

            _service.PlaceOrder(1, kit, 10, _mockDateTimeProvider.Object.Now.AddDays(1));
            _service.PlaceOrder(1, kit, 20, _mockDateTimeProvider.Object.Now.AddDays(2));
            _service.PlaceOrder(2, kit, 30, _mockDateTimeProvider.Object.Now.AddDays(3));

            var customerOrders = _service.ListAllCustomerOrders(1);

            Assert.Equal(2, customerOrders.Count);
        }
    }
}