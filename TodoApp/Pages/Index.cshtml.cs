using Data.Repositories.Abstractions;
using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApp.Pages
{
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {
        private readonly ITaskRepository _repo;
        public TaskViewModel Task { get; set; }
        public string SearchQuery { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Date;

        public IndexModel(ITaskRepository repo)
        {
            _repo = repo;
        }
        
        public IList<TaskViewModel> Tasks { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if(string.IsNullOrEmpty(SearchQuery))
            {
                Tasks = await _repo.GetAllTasks();
            }
            else
            {
                Tasks = await _repo.FindTasks(SearchQuery);
            }
            
           
            return Page();
        }

        public async Task<IActionResult> OnPostSearchByDate()
        {
            var d = Date;
            
            return Page();
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
            var ids = new List<int>();
            foreach(var task in Tasks)
            {
                if(task.Check)
                    ids.Add(task.Id);
            }
            await _repo.DeleteMultpleTasks(ids);
            return RedirectToPage("Index");
        }

    }
}