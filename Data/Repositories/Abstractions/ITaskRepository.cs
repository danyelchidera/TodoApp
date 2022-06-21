using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstractions
{
    public interface ITaskRepository
    {
        Task CreateTask(Task task);
        Task DeleteTaskById(int id);
        Task<List<Task>> GetAllTasks();
        Task GetTaskById(int id);
        Task EditTask(Task task);
        Task FindTask(string searchWord);
        Task FindByDate(DateTime date);
        Task DeleteMultpileDate(List<int> ids);
    }
}
