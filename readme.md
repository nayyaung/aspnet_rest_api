# ASP.NET Rest API using Web API 2

## Requirements & Assumption
- Developer has Visual Studio 2017, .Net Framework 4.7.2, Web API 2 installed 
- Main purpose is to demostrate Rest API using minimal configurations
- Integrated Local DB is used in order not to require MSSQL Server installation
- IIS Express running with port number 4870 is used for development. http://localhost:4870

## Dependencies
- EF 6.2.0 for data access
- Automapper for mapping between DAO and DTOs
- Moq for mocking in unit test
- Newtonsoft Json.Net for serialization

## How to run tests

### Automated tests
Open visual studio 2017 command prompts using Administrator rights
Locate to the output folder of test project (eg: Aspnet_rest_api\aspnet_rest_api.Tests\bin\Debug)
Execute the command below
``` console
vstest.console.exe aspnet_rest_api.Tests.dll
```

### Manual API Calls using Postman
- Postman https://www.getpostman.com/ is used for the testing API calls. The collection is available in "postman_api_calls" directory. It can be imported for testing.

## Configurations
- Database connection string can be changed in Web.config file's ProductContext element