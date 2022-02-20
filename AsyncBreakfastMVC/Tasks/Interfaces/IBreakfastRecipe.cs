using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncBreakfastMVC.Models;
using AsyncBreakfastMVC.Tasks.Models;

namespace AsyncBreakfastMVC.Tasks.Interfaces
{
    public interface IBreakfastRecipe
    {
        Breakfast MakeBreakfast();
        Task<Breakfast> MakeBreakfastAsync();
        Task<Breakfast> MakeBreakfastMultiThreadAsync();
        Juice PourOrangeJuice(ICollection<TaskActionViewModel> actions);
        void ApplyJam(ICollection<Toast> toasts, ICollection<TaskActionViewModel> actions);
        void ApplyButter(ICollection<Toast> toasts, ICollection<TaskActionViewModel> actions);
        ICollection<Toast> ToastBread(int slices, ICollection<TaskActionViewModel> actions);
        Task<ICollection<Toast>> ToastBreadAsync(int slices, ICollection<TaskActionViewModel> actions);
        Task<ICollection<Toast>> MakeToastWithButterAndJamAsync(int slices, ICollection<TaskActionViewModel> actions);
        Bacon FryBacon(int slices, ICollection<TaskActionViewModel> actions);
        Task<Bacon> FryBaconAsync(int slices, ICollection<TaskActionViewModel> actions);
        Egg FryEggs(int howMany, ICollection<TaskActionViewModel> actions);
        Task<Egg> FryEggsAsync(int howMany, ICollection<TaskActionViewModel> actions);
        Coffee PourCoffee(ICollection<TaskActionViewModel> actions);
    }
}