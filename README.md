# Social-Media-App
## General info
Api for the application that allows employees to communicate within the company, is modeled on social profiles, i.e. it contains all the necessary functions to conduct discussions between users or keeping track of the latest information. The goal of this project is to create Api with documentation and then use it to build one site in two application types, i.e. desktop and web.

## Technology for now:
- .Net 5.0
- ASP.NET Web API
- JWT
- MS Sql Server 
- xUnit

## Tools for now:
- Postman
- Git
- Sql Server Management Studio

# Documentation
## Prerequisites
Before using Web Api, make sure that you have .net 5.0 installed on your computer.
## Instalation
First, download the zip or clone repository.
```
git clone https://github.com/spacholski1225/Social-Media-App.git
```
After that run visual studio and set WebAPI as startup project or run console in folder with application and run
```
dotnet run
```
Then run postman or another program for testing API and make a request.

# IdentityController

Method
`public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)`
As a parameter takes request body it means Email and Password with a standard strong password. This method creates a new user and returned Ok or BadRequest. It depends from that if the user was created successfully. If the method returned Ok result additionally it generated jwt token.
