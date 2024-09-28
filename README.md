    # eCommerceInsanity: A Robust C# E-commerce Backend

**Project Highlights**

*This project focuses on building a robust e-commerce backend using C# and PostgreSQL. I've carefully designed the data models with a strong emphasis on normalization and well-defined relationships, demonstrating my understanding of best practices for database architecture.*

**Table of Contents**

* [Data Model](#data-model)
* [Entity Relationship Diagram (ERD)](#entity-relationship-diagram-erd)
* [Technologies Used](#technologies-used)
* [Key Features](#key-features)
* [Future Enhancements](#future-enhancements)
* [Getting Started](#getting-started)

**Data Model**

*The data model consists of the following entities:*

* `Product`: *Represents a product in the store, with details like name, description, price, stock quantity, and SKU.*
* `Category`: *Organizes products into categories for easy navigation.*
* `Order`: *Stores information about customer orders, including user, order date, total amount, and status.*
* `OrderItem`: *Represents an individual item within an order, linked to a specific product and its variation (if applicable).*
* `User`: *Stores user information (extended from ASP.NET Core Identity's `IdentityUser`).*
* `Variation`:  *Handles product variations like size or color.*
* `Review`:  *Captures customer reviews for products, including ratings and comments.*
* `Address`: *Stores shipping and billing addresses for users.*
* `Cart`: *Represents a user's shopping cart, containing a collection of `CartItems`.*
* `CartItem`:  *Represents an individual item within a cart, linking to a product and its variation.*
* `ProductImage`: *Stores information about product images, such as filename or URL in cloud storage.*
* `ReviewImage`:  *Stores information about images associated with customer reviews.*

## Data Model <a name="data-model"></a>
<details>
<summary style="color: #007bff; font-weight: bold;">Click to expand/collapse Data Model details</summary>
**The data model comprises these key entities:**

* **`Product`**
    * `Id` (int, Primary Key)
    * `Name` (string, Required)
    * `Description` (string)
    * `Price` (decimal, Required)
    * `CategoryId` (int, Foreign Key referencing `Category`)
    * `ImageUrl` (string)
    * `StockQuantity` (int, Required)
    * `SKU` (string, Required)

* **`Category`**
    * `Id` (int, Primary Key)
    * `Name` (string, Required)

* **`Order`**
    * `Id` (int, Primary Key)
    * `UserId` (string, Foreign Key referencing `User`, Required)
    * `OrderDate` (DateTime)
    * `TotalAmount` (decimal, Required)
    * `Status` (string) 

* **`OrderItem`**
    * `Id` (int, Primary Key)
    * `OrderId` (int, Foreign Key referencing `Order`, Required)
    * `ProductId` (int, Foreign Key referencing `Product`, Required)
    * `VariationId` (int, Nullable, Foreign Key referencing `Variation`)
    * `Quantity` (int, Required)
    * `PriceAtPurchase` (decimal, Required)

* **`User`**
    * `Id` (string, Primary Key) (Inherited from `IdentityUser`)
    * `FirstName` (string, Required)
    * `LastName` (string, Required)
    * `DateOfBirth` (DateTime, Nullable)

* **`Variation`**
    * `Id` (int, Primary Key)
    * `ProductId` (int, Foreign Key referencing `Product`, Required)
    * `AttributeName` (string, Required)
    * `AttributeValue` (string, Required)
    * `PriceAdjustment` (decimal, Nullable)
    * `StockQuantity` (int, Required)
    * `SKU` (string, Nullable) 

* **`Review`**
    * `Id` (int, Primary Key)
    * `UserId` (string, Foreign Key referencing `User`, Required)
    * `ProductId` (int, Foreign Key referencing `Product`, Required)
    * `Rating` (int, Required)
    * `Comment` (string, Nullable)
    * `CreatedAt` (DateTime)

* **`Address`**
    * `Id` (int, Primary Key)
    * `UserId` (string, Foreign Key referencing `User`, Required)
    * `AddressTypeId` (int, Foreign Key referencing `AddressType`, Required)
    * `AddressLine1` (string, Required)
    * `AddressLine2` (string, Nullable)
    * `UnitIdentifier` (string, Nullable)
    * `City` (string, Required)
    * `State` (string, Required)
    * `PostalCode` (string, Required)

* **`AddressType`**
    * `Id` (int, Primary Key)
    * `Name` (string, Required)

* **`OrderAddress`**
    * `Id` (int, Primary Key)
    * `OrderId` (int, Foreign Key referencing `Order`, Required)
    * `AddressId` (int, Foreign Key referencing `Address`, Required)
    * `AddressTypeId` (int, Foreign Key referencing `AddressType`, Required)

* **`Cart`**
    * `Id` (int, Primary Key)
    * `UserId` (string, Foreign Key referencing `User`, Required)

* **`CartItem`**
    * `Id` (int, Primary Key)
    * `CartId` (int, Foreign Key referencing `Cart`, Required)
    * `ProductId` (int, Foreign Key referencing `Product`, Required)
    * `VariationId` (int, Nullable, Foreign Key referencing `Variation`)
    * `Quantity` (int, Required)

* **`ProductImage`**
    * `Id` (int, Primary Key)
    * `ProductId` (int, Foreign Key referencing `Product`, Required)
    * `ImageFileName` (string, Required)

* **`ReviewImage`**
    * `Id` (int, Primary Key)
    * `ReviewId` (int, Foreign Key referencing `Review`, Required)
    * `ImageFileName` (string, Required)
</details>
## Entity Relationship Diagram (ERD) <a name="entity-relationship-diagram-erd"></a>

[![ERD](./Images/eCommerce%20ERD.png)](https://www.yworks.com/yed-live/?file=https://gist.githubusercontent.com/joetid09/bfcd8bb99b3dadb51d8b6026e5a61f65/raw/6ccb1e191bd2bb74561103a38c6c8cdd4dbeb0b7/eCommerce%20ERD)

*The ERD provides a visual representation of the database structure and relationships. It's hosted on yWorks and can be viewed by clicking the image above.* 

## Technologies Used <a name="technologies-used"></a>

* C#
* .NET 8
* ASP.NET Core Web API
* PostgreSQL
* Entity Framework Core
* AutoMapper
* FluentValidation
* Swashbuckle (for API documentation)
* Serilog (for logging)

## Key Features <a name="key-features"></a>

* Solid data model tailored for e-commerce with product variations.
* Clean C# code following SOLID principles and best practices.
* Efficient database interactions using Entity Framework Core.
* Robust API endpoints for managing products, orders, users, and more.

## Future Enhancements <a name="future-enhancements"></a>

* User authentication and authorization
* Advanced search using PostgreSQL's full-text search
* Payment gateway integration
* Real-time cart updates
* Product recommendations

## Getting Started <a name="getting-started"></a>

1. **Prerequisites:** .NET 8 SDK, PostgreSQL
2. **Database Setup:** Create a PostgreSQL database and configure the connection string.
3. **Run Migrations:** `dotnet ef database update` to create the database schema.
4. **Seed Data:** Populate the database with sample products, categories, etc.
5. **Run the Application:** `dotnet run` to start the API.
