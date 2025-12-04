
TaskManager API
A simple Task Manager REST API built with .NET Web API. In-memory storage for now (no database yet).

Tech stack:
- .NET SDK 10.0.100
- .NET Web API
- C#
- In-memory list for tasks

How to run locally:
- Clone this repository
- Open a terminal in the TaskManager.Api folder
- Run:
  - dotnet restore
  - dotnet run
- API will be available at: http://localhost:5232
- Live API:
https://sincere-courtesy-production-b979.up.railway.app/api/tasks

Available endpoints:
- GET /api/tasks — get all tasks 
- GET /api/tasks/{id} — get a task by id 
- POST /api/tasks — create a new task (JSON body with title, description, isCompleted) 

Next steps (planned):
- Add PUT/DELETE for full CRUD
- Add persistent storage (SQL or similar)
- Add Angular frontend and host together
