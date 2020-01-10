# AddressBook
This is a .net core 3.1 application that uses a microservices architecture. 


# Architecture Summary:

This application is composed of:

1) 3 Microservices: 

---> AddressManager API that will deal with the address functionalities. A Get request is currently implemented for demo: get an address by Id 

---> UserManager API that will deal with the user domain data. A get request is implemented for demo: get a user by Id.

---> And the AddressBook API that will actually manage the user addresses. A get request is implemented: get all user addresses grouped by city. 

2) An API Gateways that gives access to the microservices functionalities. 


An event bus can be used later in order to synchronize the data between the microservices. 

# How To run the Microservices?

All the microservices are code-first APIs. By starting all the API at the same time, all the databases will be created with the seed data. You can use the Swagger interface in order to test the microservices individually or with the API gateways.

# Tests
Each microservice has a functional and a unit test. These tests also run successfully. 
