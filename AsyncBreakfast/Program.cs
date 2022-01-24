using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("Eggs are ready");
                }
                
                if (finishedTask == baconTask)
                {
                    Console.WriteLine("Bacon is ready");
                }
                
                if (finishedTask == toastTask)
                {
                    Console.WriteLine("Toast is ready");
                }

                breakfastTasks.Remove(finishedTask);
            }

            var oj = PourOj();
            Console.WriteLine("Oj is ready");

            Console.WriteLine("Breakfast is ready!");
        }

        private static Juice PourOj()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }

            Console.WriteLine("Start toasting...");
            Task.Delay(2000).Wait();
            // Console.WriteLine("Fire! Toast is ruined!");
            // throw new InvalidOperationException("The toaster is on fire");
            Task.Delay(1000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Task<Toast> ToastBreadAsync(int slices)
        {
            return Task.FromResult(ToastBread(slices));
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }

            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static Task<Bacon> FryBaconAsync(int slices)
        {
            return Task.FromResult(FryBacon(slices));
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Task<Egg> FryEggsAsync(int howMany)
        {
            return Task.FromResult(FryEggs(howMany));
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }
    }
}