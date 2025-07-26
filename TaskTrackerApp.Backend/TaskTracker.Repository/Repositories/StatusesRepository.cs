using Microsoft.EntityFrameworkCore;
using TaskTracker.Repository.DbContexts;
using TaskTracker.Repository.DbEntities;

namespace TaskTracker.Repository.Repositories;

public class StatusesRepository : IStatusesRepository
{
    private readonly TaskTrackerAppContext taskTrackerAppContext;

    public StatusesRepository(TaskTrackerAppContext taskTrackerAppContext)
    {
        this.taskTrackerAppContext = taskTrackerAppContext;
    }

    public async Task<List<Status>> GetStatusesAsync()
    {
        return await taskTrackerAppContext.Statuses.ToListAsync();
    }
}