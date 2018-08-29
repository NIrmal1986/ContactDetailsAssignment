# ContactDetailsAssignment
This is a MVC application to store ContactDetails and perform simple CRUD operations


1. It is developed as Enterprise level MVC application architecture using Entity Framework, Generic Repository pattern and Unit of Work.
2. I have provided the sql scripts "ContactDB.sql" to create the database in Sql Server.
3. In this project we’ll be dealing with ContactDetails table to perform CURD operations using MVC and Entity framework.
4. Data Access Layer:
    a. I have used Generic Repository Pattern and Unit of work pattern to standardize our layer and Data First approach of EntityFramework version 5.
    b. Class Library named "DataModel" is DAL.
    c. I used Repository pattern to achieve following,
        i. It centralizes the data logic or Web service access logic.
        ii. It provides a substitution point for the unit tests.
        iii. It provides a flexible architecture that can be adapted as the overall design of the application evolves.
    d. Unit of Work is used to achieve following,
        i. To manage transactions.
        ii. To order the database inserts, deletes, and updates.
        iii. To prevent duplicate updates. Inside a single usage of a Unit of Work object, different parts of the code may mark the same 
            Invoice object as changed, but the Unit of Work class will only issue a single UPDATE command to the database.
5. Business Layer :
    a. BusinessEntity class Library : 
        i. I tried to follow a proper structure of communication, and one would never want to expose the database entities to the 
           end client to minimize risk.
        ii. I have used database entities in our business logic layer and use Business Entities as transfer objects to communicate between 
           business logic and Web API project.
        iii. Also all the DataAnotation attributes for validating data is applied on BusinessEntities so that any modification to DataModel 
            will not affect modifications to entities.
    b. BusinessService class Library :
        i. This layer will act as our business logic layer.
        ii. I am trying to segregate my business logic in an extra layer so that if in future I want to use WCF,MVC, Asp.net Web Pages 
            or any other application as my presentation layer then I can easily integrate my Business logic layer in it.
        iii. I wanted to make this layer testable, so I created an interface in and declare CURD operations that need to perform over Contact table.
        iv. I have decided not to expose db entities to MVC project, so I need something to map the db entities data to my business 
            entity classes. To achieve this I made use of AutoMapper.
6. So to explain architecture in simple way, for an example To get ContactDetail by id ( GetContactDetailsById ), We call repository 
   to get the product by id. Id comes as a parameter from the calling method to that service method. It returns the product entity 
   from the database. Note that it will not return the exact db entity, instead we’ll map it with our business entity using AutoMapper 
   and return it to calling method.
7. Lastly I created ContactDetailsController and implementedd Views for each action method.
8. I also like to point out few optimization that we can achieve like :
    a. Architecture is tightly coupled. IOC (Inversion of Control) needs to be there.
    b. Exception handling and logging.
    c. Unit tetsts.
    d. Security (Authentication and Authorization)
    Unfortunately as didn't buyout much time to put myself on this assignment, these points I am keeping in my backlog.
    
For any comments or clarification you feel, then please write me on 'nirmalsharma.it86@gmail.com'.

Thank You.
Kind Regards,
Nirmal.
    
    
