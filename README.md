# EmployeesAPI-Project

## Contributors
Marian Dumitriu, Guarav Dogra, James Dickson, Steven Maddox, Stanni Lewis
## Description
This project is to build a REST API application for the Northwind database, with the API exposing useful information and functionality around Employees. The project has made use of Scrum (a single backlog/sprint) for project management. 

The project itself poses some key issues:

* What data do we want users to be able to retrieve, and how we will structure the endpoint urls.  
* Who is the user and what information do they need? What should they be able to do?
* How are errors handled? - if the user enters an invalid parameter, what should be returned?

## How it works
We used C# and visual studio to pull data from the northwind databsae and display this data on a webpage. This can be used along with a search function to search for specific people in the database based on specific search parameters such as ID, Name, Location ETC.


## Setup 
1. Download Visual Studio 2022.
2. You will have to have installed the northwind database. See the file 'Visual Studio SQL NorthwindDB Set Up'
3. Clone the repository: https://github.com/MarianD1246/EmployeesAPI-Project.git 
4. Startup the solution in Visual Studio 2022.
5. Run the solution in debug mode.
6. A webpage will load to the default route listing all employees.
7. Alternatively you can look up the API documentation at the base URL.  

We also had the following requiremed the use of DTOs to return the desired information for each call. Along with the following optional requirements:
* SwaggerUI documentation 
* Unit testing of the controller methods (you will need to mock the Repository interface)

## Technologies used
* C#
* Visual Studio
* Git/Github
* Entity Framework
* SQL
* Swagger
* Moq InMemoryDatabse. 


## Running tests
The tests themselves aernt dependant on the Northwind database being installed on your machine so you will be able to run them without it being correctly installed.


# Retrospective
## Challenges
* Communication between sub teams was sometimes strained, and led to mixups. 
* Hyperfocus on certain elements of the project over a more holistic approach leading to a relatively thin API
* Relatively new to mocking and dependency inversions so tests may not be as rigourous and thorough as they should be.
* Difficulties rewriting controller due to dependency inversions. 
* Balancing the workload vs the time constraint.

## What we have learned



## Mood Diagram





