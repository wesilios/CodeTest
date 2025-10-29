using System;
using System.Threading.Tasks;

namespace AsyncBreakfastMVC.Tasks.Interfaces;

public interface IBreakfastService
{
    Task QueueBreakfastOrder(Guid orderId);
}