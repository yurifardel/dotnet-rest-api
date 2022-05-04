using Microsoft.EntityFrameworkCore;
using dotnet_c_.Model;
using dotnet_c_.Data;

namespace dotnet_c_.Repository
{
  public class TasksRepo : InterfaceTasksRepo
  {

    private readonly TaskContext _context;

    public TasksRepo(TaskContext context)
    {
      _context = context;
    }
    public void AddTask(Tasks task)
    {
      _context.Add(task);
    }
    public async Task<IEnumerable<Tasks>> FindTasks()
    {
      return await _context.Task.ToListAsync();
    }
    public async Task<Tasks> FindTasks(int id)
    {
      return await _context.Task.Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public void UpdateTask(Tasks task)
    {
      _context.Update(task);
    }
    public void DeleteTask(Tasks task)
    {
      _context.Remove(task);
    }
    public async Task<bool> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}