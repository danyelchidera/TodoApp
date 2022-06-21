using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstractions
{
    public interface ITaskRepository
    {
        Task CreateTask( Task task );
    }
}
