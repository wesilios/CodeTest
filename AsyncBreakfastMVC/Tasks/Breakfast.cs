using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AsyncBreakfastMVC.Models;
using AsyncBreakfastMVC.Tasks.Models;

namespace AsyncBreakfastMVC.Tasks
{
    public class Breakfast : IBreakfast
    {
        public IEnumerable<TaskActionViewModel> MakeBreakFast()
        {
            var actions = new List<TaskActionViewModel>();
            PourCoffee(actions);
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Coffee is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            FryEggs(2, actions);
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Eggs are ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            FryBacon(3, actions);
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Bacon is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            var toast = ToastBread(2, actions);
            
            ApplyButter(toast, actions);
            ApplyJam(toast, actions);
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Toast is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            PourOrangeJuice(actions);
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Orange Juice is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Breakfast is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return actions;
        }

        public async Task<IEnumerable<TaskActionViewModel>> MakeBreakFastAsync()
        {
            var actions = new List<TaskActionViewModel>();
            PourCoffee(actions);
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Coffee is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            
            var eggsTask = FryEggsAsync(2, actions);
            var baconTask = FryBaconAsync(3, actions);
            var toastTask = MakeToastWithButterAndJamAsync(2, actions);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Eggs are ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }
                
                if (finishedTask == baconTask)
                {
                    actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Bacon is ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }
                
                if (finishedTask == toastTask)
                {
                    actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Toast is ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }

                breakfastTasks.Remove(finishedTask);
            }

            PourOrangeJuice(actions);
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Orange Juice is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Breakfast is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return actions;
        }

        public async Task<IEnumerable<TaskActionViewModel>> MakeBreakFastMultiThreadAsync()
        {
            var actions = new List<TaskActionViewModel>();

            var coffeeTask = Task.Run(() => PourCoffee(actions));
            var eggsTask = Task.Run(() => FryEggsAsync(2, actions));
            var baconTask = Task.Run(() => FryBaconAsync(3, actions));
            var toastTask = Task.Run(() => MakeToastWithButterAndJamAsync(2, actions));

            var breakfastTasks = new List<Task> { coffeeTask, eggsTask, baconTask, toastTask};
            while (breakfastTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == coffeeTask)
                {
                    actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Coffee are ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }
                
                if (finishedTask == eggsTask)
                {
                    actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Eggs are ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }
                
                if (finishedTask == baconTask)
                {
                    actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Bacon is ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }
                
                if (finishedTask == toastTask)
                {
                    actions.Add(new TaskActionViewModel
                    {
                        TimeStart = DateTime.Now,
                        Message = "Toast is ready",
                        ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                    });
                }

                breakfastTasks.Remove(finishedTask);
            }

            PourOrangeJuice(actions);
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Orange Juice is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "Breakfast is ready",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return actions;
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

        public void ApplyJam(Toast toast, List<TaskActionViewModel> actions)
        {
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "ApplyJam: Putting jam on the toast",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
        }

        public void ApplyButter(Toast toast, List<TaskActionViewModel> actions)
        {
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "ApplyButter: Putting butter on the toast",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
        }

        public Toast ToastBread(int slices, List<TaskActionViewModel> actions)
        {
            for (var slice = 0; slice < slices; slice++)
            {
                actions.Add(new TaskActionViewModel
                {
                    TimeStart = DateTime.Now,
                    Message = "ToastBread: Putting a slice of bread in the toaster",
                    ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
                });
            }

            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "ToastBread: Start toasting...",
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

            return new Toast();
        }

        public Task<Toast> ToastBreadAsync(int slices, List<TaskActionViewModel> actions)
        {
            return Task.FromResult(ToastBread(slices, actions));
        }

        public async Task<Toast> MakeToastWithButterAndJamAsync(int slices, List<TaskActionViewModel> actions)
        {
            var toast = await ToastBreadAsync(slices, actions);
            ApplyButter(toast, actions);
            ApplyJam(toast, actions);

            return toast;
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
                Message = "FryBacon: Cooking first side of bacon...",
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
                Message = "FryBacon: Cooking the second side of bacon...",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            Task.Delay(3000).Wait();
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryBacon: Put bacon on plate",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return new Bacon();
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
                Message = "FryEggs: Warming the egg pan...",
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
                Message = "FryEggs: Cooking the eggs ...",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });
            Task.Delay(3000).Wait();
            actions.Add(new TaskActionViewModel
            {
                TimeStart = DateTime.Now,
                Message = "FryEggs: Put eggs on plate",
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString()
            });

            return new Egg();
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