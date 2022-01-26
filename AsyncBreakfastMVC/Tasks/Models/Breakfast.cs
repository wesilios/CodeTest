using System.Collections.Generic;
using AsyncBreakfastMVC.Models;

namespace AsyncBreakfastMVC.Tasks.Models
{
    public class Breakfast
    {
        public Coffee Coffee { get; set; }
        public Egg Egg { get; set; }
        public Bacon Bacon { get; set; }
        public List<Toast> Toasts { get; set; }
        public Juice Juice { get; set; }
        public List<TaskActionViewModel> Actions { get; set; }

        public Breakfast()
        {
            Actions = new List<TaskActionViewModel>();
        }
    }
}