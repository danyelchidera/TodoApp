using Data.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _conString;

        public TaskRepository(IConfiguration config)
        {
            _conString = config.GetConnectionString("DefaultConnection");

        }
        public async Task CreateTask(Models.Task task)
        {
            task.Date = DateTime.Now;
            using(SqlConnection con = new SqlConnection(_conString))
            {
                var command = "INSERT INTO Tasks VALUES (@task, @date)";
  
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@task", task.TodoTask);
                cmd.Parameters.AddWithValue("@date", task.Date);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }

        public System.Threading.Tasks.Task DeleteMultpileDate(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task EditTask(Models.Task task)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task FindTask(string searchWord)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Models.Task>> GetAllTasks()
        {
            List<Models.Task> tasks = new List<Models.Task>();
            using (SqlConnection con = new SqlConnection(_conString))
            {
                var command = "SELECT * FROM Tasks";

                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                var res = await cmd.ExecuteReaderAsync();
                if(res.HasRows)
                {
                    while(res.Read())
                    {
                        tasks.Add(new Models.Task()
                        {
                            Id = Convert.ToInt32(res["Id"]),
                            TodoTask = res["Task"].ToString(),
                            Date = (DateTime)res["DateCreated"]
                        });
                    }
                }
                con.Close();
            }
            return tasks;
        }

        public System.Threading.Tasks.Task GetTaskById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
