namespace TaskTracker.Repository.DbEntities;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TaskEntry> Tasks { get; set; } = new List<TaskEntry>();
}
