namespace TaskTracker.Repository.DbEntities;

public partial class TaskEntry
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? CompletedOn { get; set; }

    public DateTime ExpectedCompletionDate { get; set; }

    public int StatusId { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<TaskTagMapping> TaskTagMappings { get; set; } = new List<TaskTagMapping>();
}
