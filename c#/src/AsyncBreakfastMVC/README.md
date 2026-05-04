# AsyncBreakfastMVC

ASP.NET Core MVC sample project that demonstrates synchronous, asynchronous, and background task processing by simulating the process of making breakfast.

The application shows how different breakfast preparation workflows behave, including sequential execution, async execution, multi-threaded async execution, and background order processing.

## Features

- ASP.NET Core MVC web application
- Breakfast preparation simulation
- Comparison between synchronous and asynchronous workflows
- Background order processing with a hosted service
- SQLite database integration
- Entity Framework Core migrations
- Serilog logging
- MVC views for breakfast actions and order history

## Project Structure

```text
    AsyncBreakfastMVC 
    ├── Controllers 
    │ ├── HomeController.cs 
    │ └── OrderController.cs 
    ├── DataAccess 
    │ ├── DataContext.cs 
    │ ├── IUnitOfWork.cs 
    │ ├── UnitOfWork.cs 
    │ └── Repositories
    ├── Migrations 
    ├── Models 
    │ ├── ErrorViewModel.cs 
    │ └── TaskActionViewModel.cs 
    ├── Tasks 
    │ ├── Interfaces 
    │ ├── Models 
    │ └── Services 
    ├── Views 
    │ ├── Home 
    │ ├── Order 
    │ └── Shared 
    ├── wwwroot 
    ├── appsettings.json 
    ├── serilogs.json 
    ├── Program.cs 
    └── AsyncBreakfastMVC.csproj
```


## Main Concepts

### Breakfast simulation

The application simulates breakfast preparation steps such as:

- Pouring coffee
- Frying eggs
- Frying bacon
- Toasting bread
- Applying butter and jam
- Pouring orange juice

Each step records:

- Start time
- Thread ID
- Message describing the action

These records are displayed in MVC views.

## Pages

### Home

Default landing page.


### Make Breakfast

Compares regular breakfast preparation with async breakfast preparation.


### Async Make Breakfast

Compares async breakfast preparation with multi-threaded async breakfast preparation.

### Orders

Displays created breakfast orders.


### Create Order

Creates a new background breakfast order.


## Technologies Used

- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Serilog
- Hosted background services

## Requirements

- .NET SDK 8.0 or newer
- SQLite support through Entity Framework Core

## Configuration

Database connection is configured in `appsettings.json`:

```json 
{ 
  "ConnectionStrings": 
    { 
      "Sqlite": "Data Source=asyncBreakfast.db"
    }
}
```

Logging configuration is stored in:

```text
 serilogs.json
```

## Database

The application uses SQLite and Entity Framework Core migrations.

The database file is created as:

```
asyncBreakfast.db
```

On application startup, pending migrations are applied automatically.

## How to Run

From the repository root:

```bash
 dotnet run --project src/AsyncBreakfastMVC
```

Then open the application in your browser using the URL shown in the terminal, for example:

```text
https://localhost:5001
or
http://localhost:5000
```

The exact port depends on the local launch settings.

## Useful Routes

- `/Orders`: Displays created breakfast orders.
- `/CreateOrder`: Creates a new background breakfast order.

## Logging

The application uses Serilog.

Logs are written based on the configuration in `serilogs.json`. A `logs` directory may be created during runtime.

## Notes

This project is intended as a learning/demo application for async programming patterns in ASP.NET Core MVC.
