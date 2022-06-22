using Data.Repositories.Abstractions;
using Data.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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

        public Task DeleteMultpleTasks(List<int> ids)
        {
            var tvp = new DataTable();
            tvp.Columns.Add("Id", typeof(int));

            foreach (var id in ids)
                tvp.Rows.Add(new { id });

            using (var connection = new SqlConnection(_conString))
            {
                var delete = new SqlCommand("deleteSelectedTask", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                delete
                  .Parameters
                  .AddWithValue("@ids", tvp)
                  .SqlDbType = SqlDbType.Structured;

                delete.ExecuteNonQuery();
            }

            
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

        public async Task EditTask(TaskViewModel task)
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                var command = "UPDATE Tasks SET Task=@task WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@task", task.TodoTask);
                cmd.Parameters.AddWithValue("@id", task.Id);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
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

        public async Task<TaskViewModel> GetTaskById(int id)
        {
            TaskViewModel task = new TaskViewModel();
            using (SqlConnection con = new SqlConnection(_conString))
            {
                var command = "SELECT * FROM Tasks WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                var res = await cmd.ExecuteReaderAsync();
               if(res.HasRows)
                {
                    res.Read();
                    task.TodoTask = res["Task"].ToString();
                    task.Date = (DateTime)res["DateCreated"];
                    task.Id = Convert.ToInt32(res["Id"]);
                }
                
                con.Close();
            }
            return task;
        }
    }
}
