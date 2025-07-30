using TaskTracker.Repository.DbEntities;

namespace TaskTracker.Repository.Repositories;

public interface ITagsRepository
{
    Task<List<Tag>> GetTagsAsync();

    Task<Tag> GetTagByIdAsync(int tagId);

    Task CreateTagAsync(Tag tag);

    Task UpdateTagAsync(Tag tag);

    Task DeleteTagAsync(Tag tag);
}