using OrderLibrary.Models;

namespace OrderLibrary.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for order-related operations.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Places an order for a kit.
        /// </summary>
        Order PlaceOrder(int customerId, Kit kit, int quantity, DateTime expectedDeliveryDate);

        /// <summary>
        /// Lists all orders for a specific customer.
        /// </summary>
        List<Order> ListAllCustomerOrders(int customerId);
    }
}