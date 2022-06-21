
namespace Data.Repositories.Abstractions
{
    public interface ITaskRepository
    {
        Task CreateTask(Models.Task task);
        Task DeleteTaskById(int id);
        Task<List<Models.Task>> GetAllTasks();
        Task GetTaskById(int id);
        Task EditTask(Models.Task task);
        Task FindTask(string searchWord);
        Task FindByDate(DateTime date);
        Task DeleteMultpileDate(List<int> ids);
    }
}
