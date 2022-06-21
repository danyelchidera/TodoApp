
using Data.ViewModel;

namespace Data.Repositories.Abstractions
{
    public interface ITaskRepository
    {
        Task CreateTask(TaskViewModel task);
        Task DeleteTaskById(int id);
        Task<List<TaskViewModel>> GetAllTasks();
        Task GetTaskById(int id);
        Task EditTask(TaskViewModel task);
        Task FindTask(string searchWord);
        Task FindByDate(DateTime date);
        Task DeleteMultpileDate(List<int> ids);
    }
}
