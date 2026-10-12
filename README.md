# Movie Catalogue API

A RESTful Movie Catalogue API developed using ASP.NET Core Web API, C#, Entity Framework Core and SQL Server.

## Technologies Used

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server Express
- Swagger
- SSMS
- GitHub

## Database

Database Name: MovieCatalogueDB

SQL Server Instance:
.\SQLEXPRESS

## Features

- Add a movie
- View all movies
- View movie by ID
- Update movie
- Delete movie
- Search movies by title
- Filter movies by genre
- Input validation
- 404 handling for missing movies

## API Endpoints

| Method | Endpoint | Purpose |
|---|---|---|
| GET | /api/Movies | Get all movies |
| GET | /api/Movies/{id} | Get movie by ID |
| POST | /api/Movies | Add movie |
| PUT | /api/Movies/{id} | Update movie |
| DELETE | /api/Movies/{id} | Delete movie |

## Search

GET /api/Movies?search=leo

## Genre Filter

GET /api/Movies?genre=Action

## Entity

Movie contains:

- Id
- Title
- Genre
- Language
- DurationMinutes
- ReleaseYear

## Database Migration

```powershell
Add-Migration InitialCreate
Update-Database
