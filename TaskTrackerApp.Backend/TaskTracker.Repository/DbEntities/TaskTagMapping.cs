namespace TaskTracker.Repository.DbEntities;

public partial class TaskTagMapping
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int TagId { get; set; }

    public virtual Tag Tag { get; set; } = null!;

    public virtual TaskEntry Task { get; set; } = null!;
}
