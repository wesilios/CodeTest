using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AsyncBreakfastMVC.Models;
using AsyncBreakfastMVC.Tasks.Models;

namespace AsyncBreakfastMVC.Tasks
{
    public class BreakfastRecipe : IBreakfastRecipe
    {
        public Breakfast MakeBreakfast()
        {
            var breakfast = new Breakfast();
            breakfast.Coffee = PourCoffee(breakfast.Actions);
            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Coffee is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            breakfast.Egg = FryEggs(2, breakfast.Actions);
            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Eggs are ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            breakfast.Bacon = FryBacon(3, breakfast.Actions);
            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Bacon is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            breakfast.Toasts = ToastBread(2, breakfast.Actions);

            ApplyButter(breakfast.Toasts, breakfast.Actions);
            ApplyJam(breakfast.Toasts, breakfast.Actions);
            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Toast is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            breakfast.Juice = PourOrangeJuice(breakfast.Actions);
            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Orange Juice is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Breakfast is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return breakfast;
        }

        public async Task<Breakfast> MakeBreakfastAsync()
        {
            var breakfast = new Breakfast();
            breakfast.Coffee = PourCoffee(breakfast.Actions);
            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Coffee is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            var eggsTask = FryEggsAsync(2, breakfast.Actions);
            var baconTask = FryBaconAsync(3, breakfast.Actions);
            var toastTask = MakeToastWithButterAndJamAsync(2, breakfast.Actions);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    breakfast.Egg = eggsTask.Result;
                    breakfast.Actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Eggs are ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }

                if (finishedTask == baconTask)
                {
                    breakfast.Bacon = baconTask.Result;
                    breakfast.Actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Bacon is ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }

                if (finishedTask == toastTask)
                {
                    breakfast.Toasts = toastTask.Result;
                    breakfast.Actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Toast is ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }

                breakfastTasks.Remove(finishedTask);
            }

            breakfast.Juice = PourOrangeJuice(breakfast.Actions);
            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Orange Juice is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Breakfast is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return breakfast;
        }

        public async Task<Breakfast> MakeBreakfastMultiThreadAsync()
        {
            var breakfast = new Breakfast();
            var coffeeTask = Task.Run(() => PourCoffee(breakfast.Actions));
            var eggsTask = Task.Run(() => FryEggsAsync(2, breakfast.Actions));
            var baconTask = Task.Run(() => FryBaconAsync(3, breakfast.Actions));
            var toastTask = Task.Run(() => MakeToastWithButterAndJamAsync(2, breakfast.Actions));

            var breakfastTasks = new List<Task> { coffeeTask, eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == coffeeTask)
                {
                    breakfast.Coffee = coffeeTask.Result;
                    breakfast.Actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Coffee are ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }

                if (finishedTask == eggsTask)
                {
                    breakfast.Egg = eggsTask.Result;
                    breakfast.Actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Eggs are ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }

                if (finishedTask == baconTask)
                {
                    breakfast.Bacon = baconTask.Result;
                    breakfast.Actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Bacon is ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }

                if (finishedTask == toastTask)
                {
                    breakfast.Toasts = toastTask.Result;
                    breakfast.Actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Toast is ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }

                breakfastTasks.Remove(finishedTask);
            }

            breakfast.Juice = PourOrangeJuice(breakfast.Actions);
            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Orange Juice is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Breakfast is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return breakfast;
        }

        public Juice PourOrangeJuice(List<TaskActionViewModel> actions)
        {
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "PourOrangeJuice: Pouring orange juice",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            return new Juice();
        }

        public void ApplyJam(List<Toast> toasts, List<TaskActionViewModel> actions)
        {
            if (toasts == null || !toasts.Any()) throw new ArgumentNullException(nameof(toasts), "There is no toast");
            foreach (var toast in toasts)
            {
                actions.Add(new TaskActionViewModel
                {
                    TimeStart = DateTime.Now,
                    Message = "ApplyJam: Putting jam on the toast",
                    ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                });
                toast.HasJam = true;
            }
        }

        public void ApplyButter(List<Toast> toasts, List<TaskActionViewModel> actions)
        {
            if (toasts == null || !toasts.Any()) throw new ArgumentNullException(nameof(toasts), "There is no toast");
            foreach (var toast in toasts)
            {
                actions.Add(new TaskActionViewModel
                {
                    TimeStart = DateTime.Now,
                    Message = "ApplyButter: Putting butter on the toast",
                    ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                });
                toast.HasButter = true;
            }
        }

        public List<Toast> ToastBread(int slices, List<TaskActionViewModel> actions)
        {
            var toasts = new List<Toast>();
            for (var slice = 0; slice < slices; slice++)
            {
                actions.Add(new TaskActionViewModel
                {
                    TimeStart = DateTime.Now,
                    Message = "ToastBread: Putting a slice of bread in the toaster",
                    ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                });
                toasts.Add(new Toast());
            }

            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "ToastBread: Start toasting",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            Task.Delay(2000).Wait();
            // Console.WriteLine("Fire! Toast is ruined!");
            // throw new InvalidOperationException("The toaster is on fire");
            Task.Delay(1000).Wait();
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "ToastBread: Remove toast from toaster",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return toasts;
        }

        public Task<List<Toast>> ToastBreadAsync(int slices, List<TaskActionViewModel> actions)
        {
            return Task.FromResult(ToastBread(slices, actions));
        }

        public async Task<List<Toast>> MakeToastWithButterAndJamAsync(int slices,
            List<TaskActionViewModel> actions)
        {
            var toasts = await ToastBreadAsync(slices, actions);
            ApplyButter(toasts, actions);
            ApplyJam(toasts, actions);

            return toasts;
        }

        public Bacon FryBacon(int slices, List<TaskActionViewModel> actions)
        {
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = $"FryBacon: Putting {slices} slices of bacon in the pan",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryBacon: Cooking first side of bacon",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            Task.Delay(3000).Wait();
            for (var slice = 0; slice < slices; slice++)
            {
                actions.Add(new TaskActionViewModel
                {
                    TimeStart = DateTime.Now,
                    Message = "FryBacon: Flipping a slice of bacon",
                    ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                });
            }

            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryBacon: Cooking the second side of bacon",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            Task.Delay(3000).Wait();
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryBacon: Put bacon on plate",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return new Bacon(slices);
        }

        public Task<Bacon> FryBaconAsync(int slices, List<TaskActionViewModel> actions)
        {
            return Task.FromResult(FryBacon(slices, actions));
        }

        public Egg FryEggs(int howMany, List<TaskActionViewModel> actions)
        {
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryEggs: Warming the egg pan",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            Task.Delay(3000).Wait();
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = $"FryEggs: Cracking {howMany} eggs",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryEggs: Cooking the eggs ",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            Task.Delay(3000).Wait();
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryEggs: Put eggs on plate",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return new Egg(howMany);
        }

        public Task<Egg> FryEggsAsync(int howMany, List<TaskActionViewModel> actions)
        {
            return Task.FromResult(FryEggs(howMany, actions));
        }

        public Coffee PourCoffee(List<TaskActionViewModel> actions)
        {
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "PourCoffee: Pouring coffee",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return new Coffee();
        }
    }
}