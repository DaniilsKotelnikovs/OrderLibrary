using System;
using OrderLibrary.Models;
using OrderLibrary.Repositories;
using OrderLibrary.Configuration;
using OrderLibrary.Services.Interfaces;

namespace OrderLibrary.Services
{
    /// <summary>
    /// Provides services related to order operations.
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly OrderConfiguration _orderConfig;

        /// <summary>
        /// Initializes a new instance of the OrderService class.
        /// </summary>
        /// <param name="orderRepository">The order data repository.</param>
        /// <param name="orderConfig">The order-related configuration.</param>
        /// <param name="dateTimeProvider">The date-time provider.</param>
        public OrderService(IOrderRepository orderRepository, OrderConfiguration orderConfig, IDateTimeProvider dateTimeProvider)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _orderConfig = orderConfig ?? throw new ArgumentNullException(nameof(orderConfig));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        }

        /// <summary>
        /// Places an order based on provided details.
        /// </summary>
        /// <returns>The placed order.</returns>
        public Order PlaceOrder(int customerId, Kit kit, int quantity, DateTime expectedDeliveryDate)
        {
            ValidateOrderDetails(quantity, expectedDeliveryDate);

            var order = new Order
            {
                CustomerId = customerId,
                OrderedKit = kit,
                Quantity = quantity,
                ExpectedDeliveryDate = expectedDeliveryDate,
                TotalPrice = CalculateTotalPrice(kit.BasePrice, quantity)
            };

            _orderRepository.AddOrder(order);
            return order;
        }

        /// <summary>
        /// Lists all orders for a specific customer.
        /// </summary>
        /// <returns>A list of orders for the specified customer.</returns>
        public List<Order> ListAllCustomerOrders(int customerId)
        {
            return _orderRepository.GetOrdersByCustomerId(customerId);
        }

        /// <summary>
        /// Validates order details before placement.
        /// </summary>
        private void ValidateOrderDetails(int quantity, DateTime expectedDeliveryDate)
        {
            if (expectedDeliveryDate <= _dateTimeProvider.Now)
                throw new ArgumentException("Delivery date must be in the future.");

            if (quantity <= 0 || quantity > _orderConfig.MaxOrderQuantity)
                throw new ArgumentException($"Invalid quantity. Maximum allowed quantity is {_orderConfig.MaxOrderQuantity}.");
        }

        /// <summary>
        /// Calculates the total price for an order after applying applicable discounts.
        /// </summary>
        /// <returns>The total price after discounts.</returns>
        private decimal CalculateTotalPrice(decimal basePrice, int quantity)
        {
            decimal discount = 0;

            // Apply discount only if the base price matches the configured base price for discount
            if (basePrice == _orderConfig.BasePriceForDiscount)
            {
                if (quantity >= _orderConfig.ThresholdForLargeDiscount)
                    discount = _orderConfig.LargeDiscountRate;
                else if (quantity >= _orderConfig.ThresholdForSmallDiscount)
                    discount = _orderConfig.SmallDiscountRate;
            }

            return basePrice * quantity * (1 - discount);
        }
    }
}