using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncBreakfastMVC.Models;
using AsyncBreakfastMVC.Tasks.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CodeTest.AsyncBreakfastMVC
{
    public class BreakfastRecipeTests
    {
        [Fact]
        public void MakeBreakfastTest()
        {
            const int eggs = 2;
            const int baconSlices = 3;
            const int toasts = 2;

            var mogLogger = new Mock<ILogger<BreakfastRecipe>>();
            var breakfastRecipe = new BreakfastRecipe(mogLogger.Object);
            var breakfast = breakfastRecipe.MakeBreakfast();
            Assert.NotNull(breakfast);
            Assert.NotNull(breakfast.Coffee);
            Assert.NotNull(breakfast.Egg);
            Assert.NotNull(breakfast.Bacon);
            Assert.NotNull(breakfast.Toasts);
            Assert.NotNull(breakfast.Juice);
            Assert.Equal(eggs, breakfast.Egg.Total);
            Assert.Equal(baconSlices, breakfast.Bacon.Slices);
            Assert.Equal(toasts, breakfast.Toasts.Count());
            Assert.True(breakfast.Toasts.All(c => c.HasButter));
            Assert.True(breakfast.Toasts.All(c => c.HasJam));
            Assert.True(breakfast.Actions != null && breakfast.Actions.Count != 0);
        }

        [Fact]
        public async Task MakeBreakfastAsyncTest()
        {
            const int eggs = 2;
            const int baconSlices = 3;
            const int toasts = 2;

            var mogLogger = new Mock<ILogger<BreakfastRecipe>>();
            var breakfastRecipe = new BreakfastRecipe(mogLogger.Object);
            var breakfast = await breakfastRecipe.MakeBreakfastAsync();
            Assert.NotNull(breakfast);
            Assert.NotNull(breakfast.Coffee);
            Assert.NotNull(breakfast.Egg);
            Assert.NotNull(breakfast.Bacon);
            Assert.NotNull(breakfast.Toasts);
            Assert.NotNull(breakfast.Juice);
            Assert.Equal(eggs, breakfast.Egg.Total);
            Assert.Equal(baconSlices, breakfast.Bacon.Slices);
            Assert.Equal(toasts, breakfast.Toasts.Count());
            Assert.True(breakfast.Toasts.All(c => c.HasButter));
            Assert.True(breakfast.Toasts.All(c => c.HasJam));
            Assert.True(breakfast.Actions != null && breakfast.Actions.Count != 0);
        }
        
        [Fact]
        public async Task MakeBreakfastMultiThreadAsyncTest()
        {
            const int eggs = 2;
            const int baconSlices = 3;
            const int toasts = 2;

            var mogLogger = new Mock<ILogger<BreakfastRecipe>>();
            var breakfastRecipe = new BreakfastRecipe(mogLogger.Object);
            var breakfast = await breakfastRecipe.MakeBreakfastMultiThreadAsync();
            Assert.NotNull(breakfast);
            Assert.NotNull(breakfast.Coffee);
            Assert.NotNull(breakfast.Egg);
            Assert.NotNull(breakfast.Bacon);
            Assert.NotNull(breakfast.Toasts);
            Assert.NotNull(breakfast.Juice);
            Assert.Equal(eggs, breakfast.Egg.Total);
            Assert.Equal(baconSlices, breakfast.Bacon.Slices);
            Assert.Equal(toasts, breakfast.Toasts.Count());
            Assert.True(breakfast.Toasts.All(c => c.HasButter));
            Assert.True(breakfast.Toasts.All(c => c.HasJam));
            Assert.True(breakfast.Actions != null && breakfast.Actions.Count != 0);
        }

        [Fact]
        public void PourOrangeJuiceTest()
        {
            var mogLogger = new Mock<ILogger<BreakfastRecipe>>();
            var breakfastRecipe = new BreakfastRecipe(mogLogger.Object);
            var actions = new List<TaskActionViewModel>();
            var juice = breakfastRecipe.PourOrangeJuice(actions);
            Assert.NotNull(juice);
            Assert.True(actions.Count != 0);
        }
        
        [Fact]
        public void PourCoffeeTest()
        {
            var mogLogger = new Mock<ILogger<BreakfastRecipe>>();
            var breakfastRecipe = new BreakfastRecipe(mogLogger.Object);
            var actions = new List<TaskActionViewModel>();
            var coffee = breakfastRecipe.PourCoffee(actions);
            Assert.NotNull(coffee);
            Assert.True(actions.Count != 0);
        }
    }
}