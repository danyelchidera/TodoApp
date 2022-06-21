using Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        public Task CreateTask(Task task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMultpileDate(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditTask(Task task)
        {
            throw new NotImplementedException();
        }

        public Task FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task FindTask(string searchWord)
        {
            throw new NotImplementedException();
        }

        public Task<List<Task>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Task GetTaskById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
