namespace OrderLibrary.Configuration
{
    /// <summary>
    /// Represents the order and discount configuration settings.
    /// </summary>
    public class OrderConfiguration
    {
        /// <summary>
        /// Gets or sets the quantity threshold for a small discount.
        /// </summary>
        public int ThresholdForSmallDiscount { get; set; }

        /// <summary>
        /// Gets or sets the rate for the small discount.
        /// </summary>
        public decimal SmallDiscountRate { get; set; }

        /// <summary>
        /// Gets or sets the quantity threshold for a large discount.
        /// </summary>
        public int ThresholdForLargeDiscount { get; set; }

        /// <summary>
        /// Gets or sets the rate for the large discount.
        /// </summary>
        public decimal LargeDiscountRate { get; set; }

        /// <summary>
        /// Gets or sets the base price for which the discount should be applied.
        /// </summary>
        public decimal BasePriceForDiscount { get; set; }

        /// <summary>
        /// Gets or sets the maximum allowed quantity for an order.
        /// </summary>
        public int MaxOrderQuantity { get; set; }
    }
}
