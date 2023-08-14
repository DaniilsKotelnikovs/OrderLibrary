# OrderLibrary
 A C# library designed to handle order placements for DNA testing kits.

Overview
This library provides functionalities to handle order placements for various types of kits, primarily DNA testing kits. It offers features to place orders, list customer orders, and apply discount rules based on the quantity.

Key Features
Place an Order: Allows placing an order by specifying the kit type, quantity, customer ID, and expected delivery date.
List Customer Orders: Retrieves all orders placed by a specific customer.
Discount Rules: Applies discounts based on the quantity of the order.
Classes and Their Responsibilities
Kit:

Represents a type of kit with its associated price.
Properties:
KitType: The type of the kit (e.g., "DNA").
BasePrice: The base price for the kit.
Order:

Represents an order placed by a customer.
Properties:
Id: Unique identifier for the order.
CustomerId: Identifier for the customer placing the order.
OrderKit: The kit associated with the order.
Quantity: The number of kits ordered.
TotalPrice: The total price for the order, after any discounts.
ExpectedDeliveryDate: The expected date of delivery for the order.
OrderService:

Provides methods to handle order-related operations.
Methods:
PlaceOrder(): Places an order and returns the order details.
ListAllCustomerOrders(): Lists all orders for a specific customer.
IDateTimeProvider:

Interface for providing the current date and time. Useful for testing and mocking.
OrderConfiguration:

Contains configurations related to order placements, such as discount thresholds and rates.
Discount Rules
A 5% discount is applied for orders of 10 or more kits.
A 15% discount is applied for orders of 50 or more kits.
The base price for the DNA testing kit is 98.99 EUR. Discounts are applied only if the kit's base price matches this value.
Validation Rules
The delivery date must be in the future.
The desired quantity must be a positive round number.
The desired quantity must not exceed 999.
Future Considerations
The library is designed to accommodate multiple kit variants in the future.
Each kit variant may have a different base price.
The library is built with the consideration that it will be integrated into a larger system with data storage capabilities.