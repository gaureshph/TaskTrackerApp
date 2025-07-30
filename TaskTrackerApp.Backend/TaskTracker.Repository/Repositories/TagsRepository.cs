using Microsoft.EntityFrameworkCore;
using TaskTracker.Repository.DbContexts;
using TaskTracker.Repository.DbEntities;

namespace TaskTracker.Repository.Repositories;

public class TagsRepository : ITagsRepository
{
    private readonly TaskTrackerAppContext taskTrackerAppContext;

    public TagsRepository(TaskTrackerAppContext taskTrackerAppContext)
    {
        this.taskTrackerAppContext = taskTrackerAppContext;
    }

    public async Task<List<Tag>> GetTagsAsync()
    {
        return await taskTrackerAppContext.Tags.ToListAsync();
    }

    public async Task<Tag> GetTagByIdAsync(int tagId)
    {
        return await taskTrackerAppContext.Tags.FindAsync(tagId);
    }

    public async Task CreateTagAsync(Tag tag)
    {
        taskTrackerAppContext.Entry(tag).Property(tag => tag.Id).IsTemporary = true;
        await taskTrackerAppContext.Tags.AddAsync(tag);
        await taskTrackerAppContext.SaveChangesAsync();
    }

    public async Task DeleteTagAsync(Tag tag)
    {
        taskTrackerAppContext.Tags.Remove(tag);
        await taskTrackerAppContext.SaveChangesAsync();
    }

    public async Task UpdateTagAsync(Tag tag)
    {
        taskTrackerAppContext.Tags.Attach(tag);
        await taskTrackerAppContext.SaveChangesAsync();
    }
}