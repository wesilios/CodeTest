using System;

namespace AsyncBreakfastMVC.Tasks.Models;

public class Juice : BaseModel<Guid>
{
    public Guid BreakfastId { get; set; }
    public Breakfast Breakfast { get; set; }
}