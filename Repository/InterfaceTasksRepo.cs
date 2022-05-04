using dotnet_c_.Model;


namespace dotnet_c_.Repository
{
    public interface InterfaceTasksRepo
    {
        Task<IEnumerable<Tasks>> FindTasks();
        Task<Tasks> FindTasks(int id);

        void AddTask(Tasks task);
        void UpdateTask(Tasks task);
        void DeleteTask(Tasks task);
        Task<bool> SaveChangesAsync();

    }
}