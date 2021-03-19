# Golly G General Stores Master Control Program

## Project Overview

Golly G General Stores Master Control Program is a store management web application designed to allow the authorized 
user to login, create orders for customers at store locations, and inspect customer, location, order, and product information. 
All such data is managed within a cloud-hosted database and retrieved on demand.


## Languages and Technologies Used

* C#
* T-SQL
* HTML/CSS
* Javascript

* .NET5
* Entity Framework Core
* ASP.NET
* Azure T-SQL database
* Azure DevOps CI/CD pipeline using YAML
* Azure app service
* SonarCloud through Azure pipeline CI


## Project Features

* User interface through a single-page web app
* Register a new customer with extensive customer details
* Search and view customer data, queried asyncronously from a database hosted on Azure Cloud
* Place orders for customers at locations, supporting multiple product entries
* Search and view orders by customer or location, queried asyncronously from a database hosted on Azure Cloud

To-Do items:

* Implement user interface for order creation
* Implement user interface for order viewing
* Complete user interface for customer viewing
* Adopt Bootstrap for improved user interface styling
* Improve user login security

## Getting Started

Clone this repository locally using `git clone https://github.com/2102-feb08-net/brandon-project1.git`


## Usage

NOTE: This application is designed to store information in a T-SQL database. The SQL file for the creation of the database is provided in the top of the project repository. If the creator's database is not currently online, the User will need to create a database using the SQL file provided. The 'connectionstring' for the project will be stored in the secrets.json.

* Open the local repository in VS Code
* Make sure the debug/run configurations are set on the Project1.WebUI project.
* Using these configuration will open the app on a localhost port indicated in the terminal.
