# ASP.NET Rest API using Web API 2
- Main purpose is to demostrate Rest API using minimal configurations

## Requirements & Assumption
- Visual Studio 2017 Enterprise, .Net Framework 4.7.2, Web API 2 already installed 
- Integrated Local DB is used in order not to require MSSQL Server installation
- IIS Express running with port number 4870 is used for development. http://localhost:4870

## How to Run Solution & Tests
### Automated tests
Open visual studio 2017 command prompts using Administrator rights
Locate to the output folder of test project (eg: Aspnet_rest_api\aspnet_rest_api.Tests\bin\Debug)
Execute the command below
``` console
vstest.console.exe aspnet_rest_api.Tests.dll
```

### Manual API Calls using Postman
- Open the solution using Visual Studio 2017, locate to aspnet_rest_api project under aspnet_rest_api solution. Click run button on Visual Studion using IIS Express.
- Postman https://www.getpostman.com/ is used for the testing API calls. The collection is available in "postman_api_calls" directory. It can be imported for testing.

## List of API
##### Get all product IDs 
```
GET http://localhost:4870/api/products
```
Sample Response 
```json
{
    "products": [
        {
            "id": 1,
            "link": "http://localhost:4870/api/products/1"
        },
        {
            "id": 2,
            "link": "http://localhost:4870/api/products/2"
        }
    ],
    "id": "09bfc752-843e-4a67-a346-cd98a194646e",
    "timestamp": 1534617504
}
```

##### Get individual product details. Links are also available from all product Id API call's response
```
GET http://localhost:4870/api/products/{id}
```
Sample Response
```json
{
    "product": {
        "id": 1,
        "name": "Guitar",
        "quantity": 30,
        "sale_amount": 10
    },
    "id": "c69a1027-f3df-4018-9e2c-cc54e05144c7",
    "timestamp": 1534618031
}
```

##### Save products IDs 
```
PUT http://localhost:4870/api/products
```
Sample Payload
```json
[{
        "name": "Another Amp 3",
        "quantity": 14,
        "sale_amount": 26
    }, {
        "name": "Another Amp 4",
        "quantity": 11,
        "sale_amount": 22
    },
     {
        "name": "Another Amp 5",
        "quantity": 100,
        "sale_amount": 20
}]
```
Sample Response
```json
{
    "id": "6bfb3073-ed81-47e7-859b-bfa1013d5086",
    "timestamp": 1534617507
}
```

## Dependencies
- EF 6.2.0 for data access
- Automapper for mapping between DAO and DTOs
- Moq for mocking in unit test
- Newtonsoft Json.Net for serialization

## Configurations
- Database connection string can be changed in Web.config file's ProductContext element
