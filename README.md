# EmployeesAPI-Project

This project is to build a REST API application for the Northwind database, with the API exposing useful information and functionality around Employees. The project has made use of Scrum (a single backlog/sprint) for project management. The project itself poses some key issues:

* What data do we want users to be able to retrieve, and how we will structure the endpoint urls.  
* Who is the user and what information do they need? What should they be able to do?
* How are errors handled? - if the user enters an invalid parameter, what should be returned?

## Setup 
1. Clone the repository at https://github.com/MarianD1246/EmployeesAPI-Project.git 
2. Startup the solution in Visual Studio 2022.
3. Run the solution in debug mode.
4. A webpage will load to the default route listing all employees.
5. Alternatively you can look up the API documentation at https://localhost:<port>/ (replace <port> with your port number).

We also had the following requiremed the use of DTOs to return the desired information for each call. Along with the following optional requirements:
* SwaggerUI documentation 
* Use of Hypermedia as the Engine of Application State (HATEOAS)
* Unit testing of the controller methods (you will need to mock the Repository interface)

**The Deadline is Friday 1st April 4pm. At 4pm there will be a technical review, where you will explain what your API does, who the users of your API will be, what information can you request from the API (why will this be relevant to the user), demonstrate some requests (using postman or swagger), a retrospective.**
