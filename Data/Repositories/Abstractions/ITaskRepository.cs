
using Data.ViewModel;

namespace Data.Repositories.Abstractions
{
    public interface ITaskRepository
    {
        Task CreateTask(TaskViewModel task);
        Task DeleteTaskById(int id);
        Task<List<TaskViewModel>> GetAllTasks();
        Task<TaskViewModel> GetTaskById(int id);
        Task EditTask(TaskViewModel task);
        Task<List<TaskViewModel>> FindTasks(string searchWord);
        Task FindByDate(DateTime date);
        Task DeleteMultpleTasks(List<int> ids);
    }
}
