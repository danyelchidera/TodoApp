using Data.Repositories.Abstractions;
using Data.ViewModel;
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
        public async Task CreateTask(TaskViewModel task)
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

        public Task DeleteMultpileDate(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTaskById(int id)
        {
         
            using (SqlConnection con = new SqlConnection(_conString))
            {
                var command = "DELETE FROM Tasks WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }

        public System.Threading.Tasks.Task EditTask(TaskViewModel task)
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

        public async Task<List<TaskViewModel>> GetAllTasks()
        {
            List<TaskViewModel> tasks = new List<TaskViewModel>();
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
                        tasks.Add(new TaskViewModel()
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
