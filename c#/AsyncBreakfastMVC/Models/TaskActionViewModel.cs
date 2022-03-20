using System;

namespace AsyncBreakfastMVC.Models
{
    public class TaskActionViewModel
    {
        public DateTime TimeStart { get; set; }
        public string Message { get; set; }
        public string ThreadId { get; set; }
    }
}