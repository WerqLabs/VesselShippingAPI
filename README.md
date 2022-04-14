# Vessel Shipping API

## Pre requisites
- Visual Studio 2022
- .Net Core 6.0
- TDD XUnit, MOQ, 
- Nugget Packages Third Party: 
- XUnit 2.4.1, Moq 4.17.2, Swagger 6.3.0, System.Data.SqlClient 4.8.3
- MS SQL 12.0
- Working Internet to Connect to the Database Server


## How To Execute

- Enter the Connection string and API keys in the appsettings.json file to initiate connection with the Database.
- Load the project in Visual Studio 2022 Click on Play/Run Button to execute the API
- You could use the following URL to check the interactive documentation of the API (Swagger) [https://localhost:52084/Swagger](https://localhost:52084/Swagger)
- You’re required to get the Auth token only once by clicking on the Authorize button before executing any API sample.
- To deploy in an IIS server, you need a .NET Core 6.0 runtime installed on your machine.


## Guidelines
- ### Projects Structure
#### - VesselShippingLineApi
- This is main API project, which will run as service on the server.
- It has references of other library projects in the same solutions.

#### - VesselShippingLineApi.DataManagers
- It contains Business Logic required for specific scenarios.
- It also contains logic steps of background tasks (if any) required by API.
- It is mainly used to perform database operations.
#### - VesselShippingLineApi.Models
- This is a library project which represents Data Transfer Objects.
- It only contains databases entities, API request-response model.

![API Flow](https://raw.githubusercontent.com/werqlabs/VesselShippingAPI/main/VesselShippingAPI_Flow.png)
