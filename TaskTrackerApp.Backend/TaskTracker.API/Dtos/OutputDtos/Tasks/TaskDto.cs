using TaskTracker.API.Dtos.OutputDtos.Tags;

namespace TaskTracker.API.Dtos.OutputDtos.Tasks;

public class TaskDto
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? CompletedOn { get; set; }

    public DateTime ExpectedCompletionDate { get; set; }

    public int StatusId { get; set; }

    public List<TagDto> Tags { get; set; } = new List<TagDto>();
}