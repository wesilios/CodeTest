using System;

namespace AsyncBreakfastMVC.Tasks.Models;

public class Toast : BaseModel<Guid>
{
    public bool HasJam { get; set; }
    public bool HasButter { get; set; }
    public Guid BreakfastId { get; set; }
    public Breakfast Breakfast { get; set; }
}