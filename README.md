Store Inventory Manager
This application is designed for use by a retail store employee to record incoming orders of different products. The logic and data are managed in a RESTful HTTP service, while the user interface is a console application. The user can examine customer information, searchable by name, and examine the sortable order history, including orders to specific locations and by specific customers. Orders are validated and store inventory is tracked as orders are fulfilled or rejected.

Technologies Used:
C#, SQL Server, DevOps, Azure, ASP.NET Core Web API, ADO.NET, REST

Roles / Responsibilities 
Designed tables in a database using third normal form
Created a console UI to send information requests from a client to a server based on user input
Designed an API server application to relay information between a client and a database
 

Features:

Add new customers
Search customers by name
Display store items
Persistent data such as prices, store locations, store inventory
Exception handling
Testing using Moq
 

To-Dos:

Input Validation
Display details of an order
Display all order history of a customer
Display all order history of a store location
 

Improvements:

Include a CI pipeline to analyze with SonarCloud
More unit testing
Better use of OOP in the console app
More error handling
