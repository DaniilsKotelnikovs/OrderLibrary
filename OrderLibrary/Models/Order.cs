namespace OrderLibrary.Models
{
    /// <summary>
    /// Represents a customer order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the type of kit ordered.
        /// </summary>
        public Kit OrderedKit { get; set; }

        /// <summary>
        /// Gets or sets the quantity of kits ordered.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the expected delivery date for the order.
        /// </summary>
        public DateTime ExpectedDeliveryDate { get; set; }

        /// <summary>
        /// Gets or sets the total price for the order after applying discounts.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Default constructor that initializes the OrderKit property.
        /// </summary>
        public Order()
        {
            OrderedKit = new Kit();
        }
    }
}
