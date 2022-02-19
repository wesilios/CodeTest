using System;

namespace AsyncBreakfastMVC.Tasks.Models
{
    public class Bacon : BaseModel<Guid>
    {
        public int Slices { get; }
        public Guid BreakfastId { get; set; }
        public Breakfast Breakfast { get; set; }

        public Bacon()
        {
        }

        public Bacon(int slices)
        {
            Slices = slices;
        }
    }
}