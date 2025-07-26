using System.Threading.Tasks;
using System.Collections.Generic;
using TaskTracker.Repository.DbEntities;

namespace TaskTracker.Repository.Repositories;

public interface ITasksRepository
{
    Task<List<TaskEntry>> GetTasksAsync();

    Task<TaskEntry> GetTaskByIdAsync(int taskId);

    Task CreateTaskAsync(TaskEntry taskEntry);

    Task UpdateTaskAsync(TaskEntry taskEntry);

    Task DeleteTaskAsync(TaskEntry taskEntry);
}