using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string TodoTask { get; set; }
        public DateTime Date { get; set; }
        public bool Check { get; set; }
    }
}
