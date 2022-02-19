using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncBreakfastMVC.DataAccess;
using AsyncBreakfastMVC.Tasks.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AsyncBreakfastMVC.Tasks
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBreakfastRecipe _breakfastRecipe;
        private readonly ILogger<OrderService> _logger;
        private readonly BackgroundWorkerQueue _backgroundWorkerQueue;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public OrderService(IUnitOfWork unitOfWork, IBreakfastRecipe breakfastRecipe, ILogger<OrderService> logger,
            BackgroundWorkerQueue backgroundWorkerQueue, IServiceScopeFactory serviceScopeFactory)
        {
            _unitOfWork = unitOfWork;
            _breakfastRecipe = breakfastRecipe;
            _logger = logger;
            _backgroundWorkerQueue = backgroundWorkerQueue;
            _serviceScopeFactory = serviceScopeFactory;
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

            _backgroundWorkerQueue.QueueBackgroundWorkItem(async token =>
            {
                _logger.LogInformation("Start cooking...");

                try
                {
                    var breakfast = await _breakfastRecipe.MakeBreakfastMultiThreadAsync();
                    using var scope = _serviceScopeFactory.CreateScope();
                    var scopeServices = scope.ServiceProvider;
                    var unitOfWork = scopeServices.GetRequiredService<IUnitOfWork>();

                    order = await unitOfWork.OrderRepository.First();
                    order.Breakfast = breakfast;
                    await unitOfWork.CommitAsync(token);
                    _logger.LogInformation("End cooking...");
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    throw;
                }
            });

            return order.Id;
        }

        public async Task<ICollection<Order>> GetAllOrdersAsync()
        {
            return await _unitOfWork.OrderRepository.GetAllOrdersAsync();
        }
    }
}