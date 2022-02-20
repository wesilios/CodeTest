using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AsyncBreakfastMVC.Models;
using AsyncBreakfastMVC.Tasks.Interfaces;
using AsyncBreakfastMVC.Tasks.Models;
using Microsoft.Extensions.Logging;

namespace AsyncBreakfastMVC.Tasks.Services
{
    public class BreakfastRecipe : IBreakfastRecipe
    {
        private readonly ILogger<BreakfastRecipe> _logger;

        public BreakfastRecipe(ILogger<BreakfastRecipe> logger)
        {
            _logger = logger;
        }


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
                    _logger.LogInformation("Coffee are ready");
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
                    _logger.LogInformation("Eggs are ready");
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
                    _logger.LogInformation("Bacon is ready");
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
                    _logger.LogInformation("Toast is ready");
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
            _logger.LogInformation("Orange Juice is ready");
            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Orange Juice is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            _logger.LogInformation("Breakfast is ready");
            breakfast.Actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Breakfast is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            breakfast.UpdatedAt = DateTime.Now;
            return breakfast;
        }

        public Juice PourOrangeJuice(ICollection<TaskActionViewModel> actions)
        {
            _logger.LogInformation("PourOrangeJuice: Pouring orange juice");
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "PourOrangeJuice: Pouring orange juice",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            return new Juice();
        }

        public void ApplyJam(ICollection<Toast> toasts, ICollection<TaskActionViewModel> actions)
        {
            if (toasts == null || !toasts.Any()) throw new ArgumentNullException(nameof(toasts), "There is no toast");
            foreach (var toast in toasts)
            {
                _logger.LogInformation("ApplyJam: Putting jam on the toast");
                actions.Add(new TaskActionViewModel
                {
                    TimeStart = DateTime.Now,
                    Message = "ApplyJam: Putting jam on the toast",
                    ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                });
                toast.HasJam = true;
            }
        }

        public void ApplyButter(ICollection<Toast> toasts, ICollection<TaskActionViewModel> actions)
        {
            if (toasts == null || !toasts.Any()) throw new ArgumentNullException(nameof(toasts), "There is no toast");
            foreach (var toast in toasts)
            {
                _logger.LogInformation("ApplyButter: Putting butter on the toast");
                actions.Add(new TaskActionViewModel
                {
                    TimeStart = DateTime.Now,
                    Message = "ApplyButter: Putting butter on the toast",
                    ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                });
                toast.HasButter = true;
            }
        }

        public ICollection<Toast> ToastBread(int slices, ICollection<TaskActionViewModel> actions)
        {
            var toasts = new List<Toast>();
            for (var slice = 0; slice < slices; slice++)
            {
                _logger.LogInformation("ToastBread: Putting a slice of bread in the toaster");
                actions.Add(new TaskActionViewModel
                {
                    TimeStart = DateTime.Now,
                    Message = "ToastBread: Putting a slice of bread in the toaster",
                    ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                });
                toasts.Add(new Toast());
            }

            _logger.LogInformation("ToastBread: Start toasting");
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
            _logger.LogInformation("ToastBread: Remove toast from toaster");
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "ToastBread: Remove toast from toaster",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return toasts;
        }

        public Task<ICollection<Toast>> ToastBreadAsync(int slices, ICollection<TaskActionViewModel> actions)
        {
            return Task.FromResult(ToastBread(slices, actions));
        }

        public async Task<ICollection<Toast>> MakeToastWithButterAndJamAsync(int slices,
            ICollection<TaskActionViewModel> actions)
        {
            var toasts = await ToastBreadAsync(slices, actions);
            ApplyButter(toasts, actions);
            ApplyJam(toasts, actions);

            return toasts;
        }

        public Bacon FryBacon(int slices, ICollection<TaskActionViewModel> actions)
        {
            _logger.LogInformation($"FryBacon: Putting {slices} slices of bacon in the pan");
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = $"FryBacon: Putting {slices} slices of bacon in the pan",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            _logger.LogInformation("FryBacon: Cooking first side of bacon");
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryBacon: Cooking first side of bacon",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            Task.Delay(3000).Wait();
            for (var slice = 0; slice < slices; slice++)
            {
                _logger.LogInformation("FryBacon: Flipping a slice of bacon");
                actions.Add(new TaskActionViewModel
                {
                    TimeStart = DateTime.Now,
                    Message = "FryBacon: Flipping a slice of bacon",
                    ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                });
            }

            _logger.LogInformation("FryBacon: Cooking the second side of bacon");
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryBacon: Cooking the second side of bacon",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            Task.Delay(3000).Wait();
            _logger.LogInformation("FryBacon: Put bacon on plate");
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryBacon: Put bacon on plate",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return new Bacon(slices);
        }

        public Task<Bacon> FryBaconAsync(int slices, ICollection<TaskActionViewModel> actions)
        {
            return Task.FromResult(FryBacon(slices, actions));
        }

        public Egg FryEggs(int howMany, ICollection<TaskActionViewModel> actions)
        {
            _logger.LogInformation("FryEggs: Warming the egg pan");
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryEggs: Warming the egg pan",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            Task.Delay(3000).Wait();
            _logger.LogInformation($"FryEggs: Cracking {howMany} eggs");
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = $"FryEggs: Cracking {howMany} eggs",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            _logger.LogInformation("FryEggs: Cooking the eggs");
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryEggs: Cooking the eggs",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            Task.Delay(3000).Wait();
            _logger.LogInformation("FryEggs: Put eggs on plate");
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryEggs: Put eggs on plate",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return new Egg(howMany);
        }

        public Task<Egg> FryEggsAsync(int howMany, ICollection<TaskActionViewModel> actions)
        {
            return Task.FromResult(FryEggs(howMany, actions));
        }

        public Coffee PourCoffee(ICollection<TaskActionViewModel> actions)
        {
            _logger.LogInformation("PourCoffee: Pouring coffee");
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