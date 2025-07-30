using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using TaskTracker.Repository.DbEntities;
using TaskTracker.Repository.Repositories;
using TaskTracker.API.Dtos.InputDtos.Tasks;
using TaskTracker.API.Dtos.OutputDtos.Tasks;

namespace TaskTrackerApp.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ITasksRepository tasksRepository;

    public TasksController(IMapper mapper, ITasksRepository tasksRepository)
    {
        this.mapper = mapper;
        this.tasksRepository = tasksRepository;
    }

    [HttpGet(Name = "GetTasks")]
    public async Task<IActionResult> GetTasks()
    {
        var tasks = await tasksRepository.GetTasksAsync();
        var taskDtos = mapper.Map<List<TaskDto>>(tasks);

        return Ok(taskDtos);
    }

    [HttpGet("{taskId}", Name = "GetTaskById")]
    public async Task<IActionResult> GetTaskById(int taskId)
    {
        var task = await tasksRepository.GetTaskByIdAsync(taskId);
        if (task == null)
        {
            return NotFound();
        }

        var taskDto = mapper.Map<TaskDto>(task);

        return Ok(taskDto);
    }

    [HttpPost(Name = "CreateTask")]
    public async Task<IActionResult> CreateTask([FromBody] TaskCreationDto taskCreationDto)
    {
        var taskEntry = mapper.Map<TaskEntry>(taskCreationDto);
        taskEntry.CreatedOn = DateTime.Now;

        await tasksRepository.CreateTaskAsync(taskEntry);

        return CreatedAtAction("GetTaskById", new { taskId = taskEntry.Id }, taskEntry);
    }

    [HttpPut("{taskId}", Name = "UpdateTask")]
    public async Task<IActionResult> UpdateTask(int taskId, [FromBody] TaskUpdationDto taskUpdationDto)
    {
        var taskEntry = await tasksRepository.GetTaskByIdAsync(taskId);

        if (taskEntry == null)
        {
            return NotFound();
        }

        taskEntry.ModifiedOn = DateTime.Now;
        if (taskEntry.StatusId != 2 && taskUpdationDto.StatusId == 2)
        {
            taskEntry.CompletedOn = DateTime.Now;
        }

        await tasksRepository.UpdateTaskAsync(taskEntry);

        return NoContent();
    }

    [HttpPatch("{taskId}", Name = "UpdateStatus")]
    public async Task<IActionResult> UpdateStatus(int taskId, [FromBody] JsonPatchDocument<TaskUpdationDto> patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest();
        }

        var taskEntry = await tasksRepository.GetTaskByIdAsync(taskId);

        if (taskEntry == null)
        {
            return NotFound();
        }

        var updationDto = mapper.Map<TaskEntry, TaskUpdationDto>(taskEntry);

        patchDoc.ApplyTo(updationDto, error =>
        {
            var path = error.Operation?.path ?? "UnknownPath";
            ModelState.AddModelError(path, error.ErrorMessage);
        });

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        taskEntry = mapper.Map<TaskUpdationDto, TaskEntry>(updationDto);

        await tasksRepository.UpdateTaskAsync(taskEntry);

        return NoContent();
    }

    [HttpDelete("{taskId}", Name = "DeleteTask")]
    public async Task<IActionResult> DeleteTask(int taskId)
    {
        var taskEntry = await tasksRepository.GetTaskByIdAsync(taskId);
        if (taskEntry == null)
        {
            return NotFound();
        }

        await tasksRepository.DeleteTaskAsync(taskEntry);

        return NoContent();
    }
}
