namespace OrderLibrary.Models
{
    /// <summary>
    /// Represents a type of kit with its associated price.
    /// </summary>
    public class Kit
    {
        /// <summary>
        /// Gets or sets the type of the kit.
        /// </summary>
        public string KitType { get; set; }

        /// <summary>
        /// Gets or sets the base price for the kit.
        /// </summary>
        public decimal BasePrice { get; set; }
    }
}