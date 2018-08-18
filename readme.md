# ASP.NET Rest API using Web API 2

## Assumption
- Developer has Visual Studio 2017, .Net Framework 4.7.2, Web API 2 installed 
- Main purpose is to demostrate Rest API using minimal configurations
- Local DB is used to reduce dedicated MSSQL Server requirement 
- IIS Express is used


## How to run tests

Open visual studio 2017 command prompts using Administrator rights
Locate to the output folder of test project (eg: Aspnet_rest_api\aspnet_rest_api.Tests\bin\Debug)
Execute the command below
``` console
vstest.console.exe aspnet_rest_api.Tests.dll
```