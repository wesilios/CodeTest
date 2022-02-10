using System;

namespace AsyncBreakfastMVC.Tasks.Models
{
    public class BaseModel<T>
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        protected BaseModel()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}