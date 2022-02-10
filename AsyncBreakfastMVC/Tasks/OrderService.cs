using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncBreakfastMVC.DataAccess;
using AsyncBreakfastMVC.Tasks.Models;
using Microsoft.Extensions.Logging;

namespace AsyncBreakfastMVC.Tasks
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBreakfastRecipe _breakfastRecipe;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IUnitOfWork unitOfWork, IBreakfastRecipe breakfastRecipe, ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _breakfastRecipe = breakfastRecipe;
            _logger = logger;
        }

        public async Task<Guid> CreateOrder()
        {
            var order = new Order
            {
                Id = new Guid(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync();

            await Task.Run(() => MakeBreakfastAsync(order)).ConfigureAwait(false);

            return order.Id;
        }

        public async Task<ICollection<Order>> GetAllOrdersAsync()
        {
            return await _unitOfWork.OrderRepository.GetAllOrdersAsync();
        }

        public async Task MakeBreakfastAsync(Order order)
        {
            _logger.LogInformation("Start cooking...");
            var breakfast = await _breakfastRecipe.MakeBreakfastMultiThreadAsync();

            order.Breakfast = breakfast;

            _logger.LogInformation("End cooking...");
            await _unitOfWork.CommitAsync();
        }
    }
}