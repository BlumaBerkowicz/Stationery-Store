# Stationary Store
The project represents a website for selling stationery.
The site has the option to register, log in, change and update user information.
On the products page, you have the option to add a product to the cart, filter products by category, price, or name, as well as go to the cart page.
On the cart page, you can remove a product, see the amount of products in the cart, and place the order.

# Technologies Used:
The project was written in .NET7
For Frontend: HTML, CSS, JavaScript
For Backend: C#, ASP.NET
For Database: SQL

Written in web API.
Written in full adherence to REST principles.
When registering on the website, the strength of the password is checked by the ZXCVBN-CORE package.
We worked in the layering method using Dependency Injection.
In order to gain encapsulating, hiding and flexibility.
We used await for scalability.
We used the EF orm in the DB FIRST method.
There is documented swagger.
We modified dto to prevent circular dependencies, and abstraction of objects.
We mapped the objects by auto mapper.
There is a configuration file for data that may change.
Writing to logs.
The log sends an email in case of an error.

# There are two middlewares:
1.ErrorHandlingMiddleware for catching the errors.
2. RatingMiddleware for documenting all http requests to the SERVER and saving them in the DB.

# How to Run
Pre-requisites:
Microsoft Visual Studio 2022 version (and on). 
Microsoft SQL Server Management Studio (SSMS)

1- Install the following:
Microsoft Visual Studio
Microsoft SQL Server Management Studio (SSMS)
2-clone th repository in the vs.
3-You can use the capabilities of CODE FIRST and this is how the DB will be created.
