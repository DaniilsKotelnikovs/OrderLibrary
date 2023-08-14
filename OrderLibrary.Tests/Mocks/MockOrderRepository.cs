using OrderLibrary.Models;
using OrderLibrary.Repositories;

namespace OrderLibrary.Tests.Mocks
{
    /// <summary>
    /// A mock implementation of IOrderRepository for testing purposes.
    /// </summary>
    public class MockOrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();

        /// <summary>
        /// Adds a new order to the mock storage.
        /// </summary>
        /// <param name="order">The order to add.</param>
        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        /// <summary>
        /// Retrieves all orders from the mock storage.
        /// </summary>
        /// <returns>A list of orders.</returns>
        public List<Order> GetAllOrders()
        {
            return _orders;
        }

        /// <summary>
        /// Retrieves orders associated with a specific customer from the mock storage.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>A list of orders for the specified customer.</returns>
        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return _orders.Where(o => o.CustomerId == customerId).ToList();
        }
    }
}
