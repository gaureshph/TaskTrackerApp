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
}