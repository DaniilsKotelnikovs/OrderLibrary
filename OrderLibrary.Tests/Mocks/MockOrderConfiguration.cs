using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLibrary.Tests.Mocks
{
    using OrderLibrary.Configuration;

    /// <summary>
    /// Provides mock order configurations for testing purposes.
    /// </summary>
    public static class MockOrderConfiguration
    {
        /// <summary>
        /// Gets a default mock order configuration.
        /// </summary>
        /// <returns>A mock order configuration.</returns>
        public static OrderConfiguration GetDefault()
        {
            return new OrderConfiguration
            {
                ThresholdForSmallDiscount = 10,
                SmallDiscountRate = 0.05m,
                ThresholdForLargeDiscount = 50,
                LargeDiscountRate = 0.15m,
                BasePriceForDiscount = 98.99m,
                MaxOrderQuantity = 999
            };
        }
    }
}
