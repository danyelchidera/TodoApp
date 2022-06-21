using Data.Repositories.Abstractions;
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
        public Data.Models.Task Task { get; set; }
        public IEnumerable<Data.Models.Task> Tasks { get; set; }

        public async void OnGet()
        {
            Tasks = await _repo.GetAllTasks();
        }

        public async Task<IActionResult> OnPostAdd()
        {
            await _repo.CreateTask(Task);
            Task = new Data.Models.Task();

            return RedirectToPage("Index");
        }

    }
}