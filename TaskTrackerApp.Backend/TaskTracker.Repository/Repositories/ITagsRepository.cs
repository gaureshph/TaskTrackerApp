using System.Threading.Tasks;
using System.Collections.Generic;
using TaskTracker.Repository.DbEntities;

namespace TaskTracker.Repository.Repositories;

public interface ITagsRepository
{
    Task<List<Tag>> GetTagsAsync();

    Task<Tag> GetTagByIdAsync(int tagId);

    Task CreateTagAsync(Tag tag);

    Task DeleteTagAsync(Tag tag);
}