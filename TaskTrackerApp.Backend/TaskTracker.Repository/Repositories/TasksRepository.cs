using Microsoft.EntityFrameworkCore;
using TaskTracker.Repository.DbContexts;
using TaskTracker.Repository.DbEntities;

namespace TaskTracker.Repository.Repositories;

public class TasksRepository : ITasksRepository
{
    private readonly TaskTrackerAppContext taskTrackerAppContext;

    public TasksRepository(TaskTrackerAppContext taskTrackerAppContext)
    {
        this.taskTrackerAppContext = taskTrackerAppContext;
    }

    public async Task<List<TaskEntry>> GetTasksAsync()
    {
        return await taskTrackerAppContext.Tasks.ToListAsync();
    }

    public async Task<TaskEntry> GetTaskByIdAsync(int taskId)
    {
        return await taskTrackerAppContext.Tasks.FindAsync(taskId);
    }

    public async Task CreateTaskAsync(TaskEntry taskEntry)
    {
        await taskTrackerAppContext.Tasks.AddAsync(taskEntry);
        await taskTrackerAppContext.SaveChangesAsync();
    }

    public async Task UpdateTaskAsync(TaskEntry taskEntry)
    {
        taskTrackerAppContext.Tasks.Attach(taskEntry);
        await taskTrackerAppContext.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(TaskEntry taskEntry)
    {
        taskTrackerAppContext.Tasks.Remove(taskEntry);
        await taskTrackerAppContext.SaveChangesAsync();
    }    
}