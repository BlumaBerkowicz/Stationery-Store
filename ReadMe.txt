
Welcome to my first WEB Api site, and thank you for reading this file.


How To Use:
In order to run this project:
Vs 2022 version (and on). 
DB- SQL. 
For creating the DB, you can use code-first abilities. All what you need is: 
Open your package manager console, 

Write: 1. add-migration [MyDataBaseName]
 		2.Update-DataBase. 	
And your DB is ready for use!


About:
The project represents a clothes store. It includes a login page, when the user gets an option of registering in case of new user. After a successfuly login, you get to a page that offers you to update your user details, or getting into the store. In the store page you can add products to your cart, that is saved in the session storage. There is an option of filtering the products that you see using category, words from product description, minimum price or maximum price as parameters. You can click and go to your cart page, where you can see your cart, remove products from it, and save your order. 

Written:
Server side – ASP.NET 7. 
Client side – JS. 

The project uses WEB API, and is based on REST technology. 
I was strict in password strength issue: I used zxcvbn-core package to check password strength in user register and while updating details.
I worked with layers that are connected with DI, in order of making my application more encapsulated and flexible.
I used async/await along the way, to make sure my application has the scalability advantage.
I communicated with the DB (SQL) using Microsoft ORM - EF. I worked in DB first method.
I have a swagger that describes my project structure.
I used DTO layer in order of preventing circular dependency, the objects are mapped by AutoMapper.
I used configuration files for managing environment settings.
I used an activity logger that writes to a file when login action accures , and sends an email when there is an attempt of changing the order sum.

MiddleWares: 
I wrote 2 custom middleWares for the project, one that puts each request details in the DB, and another which is in charge on error handling, as is written beneath. 

Validation and error handling:
I used entity validation.
The errors are written to the log, and the user gets just an internal error.








