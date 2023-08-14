using OrderLibrary.Models;

namespace OrderLibrary.Repositories
{
    /// <summary>
    /// Defines the contract for order data operations.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Adds a new order to the storage.
        /// </summary>
        /// <param name="order">The order to add.</param>
        void AddOrder(Order order);

        /// <summary>
        /// Retrieves all orders from the storage.
        /// </summary>
        /// <returns>A list of orders.</returns>
        List<Order> GetAllOrders();

        /// <summary>
        /// Retrieves orders associated with a specific customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>A list of orders for the specified customer.</returns>
        List<Order> GetOrdersByCustomerId(int customerId);
    }
}