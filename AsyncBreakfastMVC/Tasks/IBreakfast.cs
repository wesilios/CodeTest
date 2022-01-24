using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncBreakfastMVC.Models;
using AsyncBreakfastMVC.Tasks.Models;

namespace AsyncBreakfastMVC.Tasks
{
    public interface IBreakfast
    {
        IEnumerable<TaskActionViewModel> MakeBreakFast();
        Task<IEnumerable<TaskActionViewModel>> MakeBreakFastAsync();
        Task<IEnumerable<TaskActionViewModel>> MakeBreakFastMultiThreadAsync();
        Juice PourOrangeJuice(List<TaskActionViewModel> actions);
        void ApplyJam(Toast toast, List<TaskActionViewModel> actions);
        void ApplyButter(Toast toast, List<TaskActionViewModel> actions);
        Toast ToastBread(int slices, List<TaskActionViewModel> actions);
        Task<Toast> ToastBreadAsync(int slices, List<TaskActionViewModel> actions);
        Task<Toast> MakeToastWithButterAndJamAsync(int slices, List<TaskActionViewModel> actions);
        Bacon FryBacon(int slices, List<TaskActionViewModel> actions);
        Task<Bacon> FryBaconAsync(int slices, List<TaskActionViewModel> actions);
        Egg FryEggs(int howMany, List<TaskActionViewModel> actions);
        Task<Egg> FryEggsAsync(int howMany, List<TaskActionViewModel> actions);
        Coffee PourCoffee(List<TaskActionViewModel> actions);
    }
}