using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncBreakfastMVC.Models;
using AsyncBreakfastMVC.Tasks.Models;

namespace AsyncBreakfastMVC.Tasks
{
    public interface IBreakfastRecipe
    {
        Breakfast MakeBreakfast();
        Task<Breakfast> MakeBreakfastAsync();
        Task<Breakfast> MakeBreakfastMultiThreadAsync();
        Juice PourOrangeJuice(List<TaskActionViewModel> actions);
        void ApplyJam(List<Toast> toasts, List<TaskActionViewModel> actions);
        void ApplyButter(List<Toast> toasts, List<TaskActionViewModel> actions);
        List<Toast> ToastBread(int slices, List<TaskActionViewModel> actions);
        Task<List<Toast>> ToastBreadAsync(int slices, List<TaskActionViewModel> actions);
        Task<List<Toast>> MakeToastWithButterAndJamAsync(int slices, List<TaskActionViewModel> actions);
        Bacon FryBacon(int slices, List<TaskActionViewModel> actions);
        Task<Bacon> FryBaconAsync(int slices, List<TaskActionViewModel> actions);
        Egg FryEggs(int howMany, List<TaskActionViewModel> actions);
        Task<Egg> FryEggsAsync(int howMany, List<TaskActionViewModel> actions);
        Coffee PourCoffee(List<TaskActionViewModel> actions);
    }
}