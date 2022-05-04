using Microsoft.EntityFrameworkCore;
using dotnet_c_.Model;

namespace dotnet_c_.Data
{
  public class TaskContext : DbContext
  {
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }

    public DbSet<Tasks> Task {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        var task =  modelBuilder.Entity<Tasks>();
        task.ToTable("tb_tasks");
        task.HasKey(i => i.Id);
        task.Property(i => i.Id).HasColumnName("id").ValueGeneratedOnAdd();
        task.Property(i => i.Title).HasColumnName("title").IsRequired();
        task.Property(i => i.Description).HasColumnName("description");
        task.Property(i => i.CreatedAt).HasColumnName("createdAt").IsRequired();
        

    }
  }
}