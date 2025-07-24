using Microsoft.EntityFrameworkCore;
using TaskTracker.Repository.DbEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskTracker.Repository.DbContexts;

public partial class TaskTrackerAppContext : DbContext
{
    public TaskTrackerAppContext()
    {
    }

    public TaskTrackerAppContext(DbContextOptions<TaskTrackerAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TaskEntry> Tasks { get; set; }

    public virtual DbSet<TaskTagMapping> TaskTagMappings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Statuses__3214EC07567AD4E3");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tags__3214EC07F7BB8ED0");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TaskEntry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3214EC07BA5BC42B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Note)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__StatusId__60A75C0F");
        });

        modelBuilder.Entity<TaskTagMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskTagM__3214EC0747950958");

            entity.ToTable("TaskTagMapping");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Tag).WithMany(p => p.TaskTagMappings)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("FK__TaskTagMa__TagId__6477ECF3");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskTagMappings)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK__TaskTagMa__TaskI__6383C8BA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
