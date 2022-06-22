using Data.Repositories.Abstractions;
using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApp.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ITaskRepository _repo;

        public IndexModel(ITaskRepository repo)
        {
            _repo = repo;
        }
        public TaskViewModel Task { get; set; }
        public IList<TaskViewModel> Tasks { get; set; }

        public async void OnGet()
        {
            Tasks = await _repo.GetAllTasks();
        }

        public async Task<IActionResult> OnPostAdd()
        {
            if(!string.IsNullOrEmpty(Task.TodoTask))
            {
                await _repo.CreateTask(Task);
            }
            
            Task = new TaskViewModel();

            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _repo.DeleteTaskById(id);

            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDeleteSelected()
        {
            
            var checkTasks = Tasks;
            return RedirectToPage("Index");
        }

    }
}