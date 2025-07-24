namespace TaskTracker.Repository.DbEntities;

public partial class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TaskTagMapping> TaskTagMappings { get; set; } = new List<TaskTagMapping>();
}
