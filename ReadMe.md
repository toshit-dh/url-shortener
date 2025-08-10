# URL Shortener

A simple URL shortener API built with ASP.NET Core, Entity Framework Core, and MySQL.

## Features

* Shorten long URLs into short, shareable links
* Redirect short URLs to their original destinations
* API documentation via Swagger UI

## Technologies Used

* ASP.NET Core Web API
* Entity Framework Core (Pomelo MySQL provider)
* MySQL Database
* Swagger for API documentation

## Prerequisites

* .NET 6 SDK or later
* MySQL Server
* Visual Studio 2022 or VS Code

## Setup Instructions

1. **Clone the repository:**

   ```bash
   git clone https://github.com/yourusername/urlshortener.git
   cd urlshortener
   ```

2. **Configure the database connection:**
   Update `appsettings.json` with your MySQL connection string:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "server=localhost;database=urlshortenerdb;user=root;password=yourpassword"
     }
   }
   ```

3. **Apply migrations:**

   ```bash
   dotnet ef database update
   ```

4. **Run the application:**

   ```bash
   dotnet run
   ```

5. **Access the API:**

   * Swagger UI: `https://localhost:5001/swagger`
   * Example: `POST /api/url/create` with a JSON body `{ "originalUrl": "https://example.com" }`

