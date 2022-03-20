using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncBreakfastMVC.DataAccess;
using AsyncBreakfastMVC.Tasks.Interfaces;
using AsyncBreakfastMVC.Tasks.Models;

namespace AsyncBreakfastMVC.Tasks.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBreakfastService _breakfastService;

        public OrderService(IUnitOfWork unitOfWork, IBreakfastService breakfastService)
        {
            _unitOfWork = unitOfWork;
            _breakfastService = breakfastService;
        }

        public async Task<Guid> CreateOrder()
        {
            var order = new Order();

            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync();
            await _breakfastService.QueueBreakfastOrder(order.Id);

            return order.Id;
        }

        public async Task<ICollection<Order>> GetAllOrdersAsync()
        {
            return await _unitOfWork.OrderRepository.GetAllOrdersAsync();
        }
    }
}