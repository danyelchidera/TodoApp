using Data.Repositories.Abstractions;
using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApp.Pages
{
    [BindProperties]
    public class EditTodoModel : PageModel
    {
        private readonly ITaskRepository _repo;
        public TaskViewModel Task { get; set; }
        public EditTodoModel(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Task =  await _repo.GetTaskById(id);
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            await _repo.EditTask(Task);
            return RedirectToPage("Index");
        }
    }
}
