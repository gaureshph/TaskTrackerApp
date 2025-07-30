using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.Repository.DbEntities;

public partial class Tag
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TaskTagMapping> TaskTagMappings { get; set; } = new List<TaskTagMapping>();
}
