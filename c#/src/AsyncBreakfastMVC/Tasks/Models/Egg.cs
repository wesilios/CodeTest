using System;

namespace AsyncBreakfastMVC.Tasks.Models;

public class Egg : BaseModel<Guid>
{
    public int Total { get; }
    public Guid BreakfastId { get; set; }
    public Breakfast Breakfast { get; set; }

    public Egg()
    {
    }

    public Egg(int total)
    {
        Total = total;
    }
}