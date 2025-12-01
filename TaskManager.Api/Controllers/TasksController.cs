using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models; // Add this if Models folder exists

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private static List<TaskItem> _tasks = new()
    {
        new() { Id = 1, Title = "Morning walk", Description = "15 min walk", IsCompleted = false, CreatedAt = DateTime.Now.AddDays(-2) },
        new() { Id = 2, Title = "Grocery shopping", Description = "Milk, eggs, bread", IsCompleted = true, CreatedAt = DateTime.Now.AddDays(-1) },
        new() { Id = 3, Title = "AZ-900 study", Description = "Cloud concepts", IsCompleted = false, CreatedAt = DateTime.Now }
    };

    [HttpGet]
    public ActionResult<List<TaskItem>> GetTasks() => Ok(_tasks);

    [HttpGet("{id:int}")]
    public ActionResult<TaskItem> GetTaskById(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return NotFound();

        return Ok(task);
    }
    [HttpPost]
    public ActionResult<TaskItem> CreateTask([FromBody] TaskItem newTask)
    {
        if (newTask == null)
            return BadRequest();

        var nextId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
        newTask.Id = nextId;
        newTask.CreatedAt = DateTime.Now;

        _tasks.Add(newTask);

        return CreatedAtAction(nameof(GetTaskById), new { id = newTask.Id }, newTask);
    }


}
