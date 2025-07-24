using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Repository.Repositories;

namespace TaskTrackerApp.API.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly ITasksRepository tasksRepository;

    public TasksController(ITasksRepository tasksRepository)
    {
        this.tasksRepository = tasksRepository;
    }

    [HttpGet(Name = "GetTasks")]
    public async Task<IActionResult> GetTasks()
    {
        return Ok(await tasksRepository.GetTasksAsync());
    }
}
