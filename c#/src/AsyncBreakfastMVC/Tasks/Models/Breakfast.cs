using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using AsyncBreakfastMVC.Models;

namespace AsyncBreakfastMVC.Tasks.Models;

public class Breakfast : BaseModel<Guid>
{
    public Coffee Coffee { get; set; }
    public Egg Egg { get; set; }
    public Bacon Bacon { get; set; }
    public ICollection<Toast> Toasts { get; set; }
    public Juice Juice { get; set; }

    public Breakfast()
    {
        Actions = new List<TaskActionViewModel>();
    }

    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public string ActionData { get; set; }

    [NotMapped]
    public ICollection<TaskActionViewModel> Actions
    {
        get => string.IsNullOrEmpty(ActionData)
            ? null
            : JsonSerializer.Deserialize<ICollection<TaskActionViewModel>>(ActionData);
        set => ActionData = JsonSerializer.Serialize(value);
    }
}