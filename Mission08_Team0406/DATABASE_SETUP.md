# Database Setup Instructions

## Overview
This project uses Entity Framework Core with SQLite to manage tasks using the Repository Pattern.

## Models Created
1. **TaskItem** - Main task entity with:
   - TaskId (Primary Key)
   - Task (Required)
   - DueDate (Optional)
   - Quadrant (Required, 1-4)
   - CategoryId (Foreign Key)
   - Completed (Boolean)

2. **Category** - Category entity with:
   - CategoryId (Primary Key)
   - CategoryName (Required)
   - Pre-seeded with: Home, School, Work, Church

## Database Creation Steps

### Step 1: Restore NuGet Packages
```bash
dotnet restore
```

### Step 2: Create Initial Migration
```bash
dotnet ef migrations add InitialCreate
```

### Step 3: Update Database
```bash
dotnet ef database update
```

This will create a `Tasks.sqlite` file in your project root with:
- Tasks table
- Categories table (pre-populated with Home, School, Work, Church)

## Repository Pattern
The project implements the Repository Pattern with:
- `ITaskRepository` - Interface defining repository methods
- `TaskRepository` - Implementation using ApplicationDbContext
- Registered in Program.cs as a scoped service

## Connection String
Located in `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=Tasks.sqlite"
}
```

## Usage Example
Inject `ITaskRepository` into your controllers/services:
```csharp
public class HomeController : Controller
{
    private readonly ITaskRepository _repository;

    public HomeController(ITaskRepository repository)
    {
        _repository = repository;
    }

    // Use _repository.GetAllTasks(), _repository.AddTask(), etc.
}
```
