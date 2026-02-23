# GameTournamentAPI

ASP.NET Core Web API for managing tournaments and games.

## Features

- CRUD operations for Tournaments
- CRUD operations for Games
- Entity Framework Core with SQL Server
- Code First approach with Migrations
- Async/await in Controllers, Services and Database calls
- DTO usage for Create, Update and Response
- Data validation using DataAnnotations
- 1-to-many relationship (Tournament -> Games)
- Clean project structure (Controllers, Services, Data, Models, Dtos)

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Dependency Injection
- Swagger

## Database

Uses EF Core Code First with migrations.
Connection string configured in appsettings.json.

## How to Run

1. Update connection string in appsettings.json
2. Run migrations
3. Start the project
4. Open Swagger at: https://localhost:{port}/swagger

---

Created as part of Web API course assignment.
