namespace TaskTracker.API.Dtos.InputDtos.Tasks;

public class TaskUpdationDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Note { get; set; }

    public DateTime ExpectedCompletionDate { get; set; }

    public int StatusId { get; set; }

    public List<int> TagIds { get; set; } = new List<int>();
}