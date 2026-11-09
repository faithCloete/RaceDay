RaceDay - Event Management API
1. Project Overview
RaceDay is an event management system designed for running, walking and cycling events in South Africa.
The system provides an API that allows Organisers to manage events, categories and participant results, while Participants can register, enrol in events and view their results.
This project was developed using ASP.NET Core Web API and C#.
2. Technologies Used
C#
ASP.NET Core Web API (.NET 8)
Microsoft SQL Server
Entity Framework Core 8
Entity Framework Core Code First
Swagger / OpenAPI
xUnit
Entity Framework Core InMemory
GitHub Actions
3. Project Structure
The solution contains two main projects:
RaceDay.API: The ASP.NET Core Web API containing controllers, models, DTOs, database configuration and services.
RaceDay.Tests: The xUnit test project containing automated unit tests for the API controllers.
4. Database Setup
RaceDay uses Microsoft SQL Server with Entity Framework Core.
The application connects to a local SQL Server LocalDB instance.
The configured database connection string is stored in appsettings.json.
Example:
Server=(localdb)\MSSQLLocalDB;Database=RaceDay;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True
Ensure SQL Server LocalDB is installed and that the RaceDay database is available before running the API.
5. Running the Application
Requirements
Visual Studio 2022
.NET 8 SDK
SQL Server LocalDB
Instructions
Clone or download the repository.
Open RaceDay.sln in Visual Studio.
Restore the NuGet packages.
Ensure the database connection string is correctly configured.
Set RaceDay.API as the startup project.
Run the application.
Swagger UI can be used to view and test the API endpoints.
6. API Endpoints
Authentication
Method
Endpoint
Description
POST
/api/Auth/register
Register a new user
POST
/api/Auth/login
Log in a user
POST
/api/Auth/logout
Log out a user
Users
Method
Endpoint
Description
GET
/api/Users/me
View the logged-in user's profile
PUT
/api/Users/me
Update the logged-in user's profile
Events
Method
Endpoint
Description
GET
/api/Events
View available events
POST
/api/Events
Create an event
PUT
/api/Events/{id}
Update an event
DELETE
/api/Events/{id}
Delete an event
Categories
Method
Endpoint
Description
GET
/api/Categories
View event categories
POST
/api/Categories
Create a category
PUT
/api/Categories/{id}
Update a category
DELETE
/api/Categories/{id}
Delete a category
Enrolments
Method
Endpoint
Description
POST
/api/Enrolments
Enrol in an event
GET
/api/Enrolments
View enrolments for the Organiser's events
GET
/api/Enrolments/MyEnrolments
View the Participant's own enrolments
Results
Method
Endpoint
Description
POST
/api/Results
Record a participant's result
GET
/api/Results/my-results
View the Participant's own results
7. Authentication and Authorisation
RaceDay uses session-based authentication.
Users are assigned one of two roles:
RoleID 1: Organiser
RoleID 2: Participant
Organisers can manage their own events, categories and results.
Participants can browse events, enrol in events, view their enrolments and access their own results.
Passwords are securely hashed using ASP.NET Core's PasswordHasher.
Unauthorised requests are restricted through session and role checks.
8. Unit Testing
The RaceDay.Tests project uses:
xUnit
Microsoft.EntityFrameworkCore.InMemory
The automated tests cover:
User registration and login.
Duplicate email registration.
Event creation and access restrictions.
Category creation and organiser ownership.
Participant enrolments and duplicate enrolment prevention.
Result recording and participant result access.
To execute the tests:
Open the solution in Visual Studio.
Open Test Explorer.
Select Run All Tests.
Current test status: 18 automated tests passed during local testing.
9. Continuous Integration
The repository includes a GitHub Actions workflow at:
.github/workflows/dotnet.yml
The workflow is configured to restore dependencies, build the solution and execute the automated tests when changes are pushed to the configured branches or when pull requests are created.
10. Developer
Developed as part of the Diploma in Information Technology: Software Development programme at IIE Rosebank College