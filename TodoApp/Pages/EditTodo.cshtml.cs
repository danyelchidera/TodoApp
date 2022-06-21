using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApp.Pages
{
    public class EditTodoModel : PageModel
    {

        public TaskViewModel Task{ get; set; }

        public void OnGet(int id)
        {
           
        }
    }
}
