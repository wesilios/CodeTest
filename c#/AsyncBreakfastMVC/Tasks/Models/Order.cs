using System;

namespace AsyncBreakfastMVC.Tasks.Models
{
    public class Order : BaseModel<Guid>
    {
        public Breakfast Breakfast { get; set; }
    }
}