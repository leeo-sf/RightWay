using RightWay.Domain.Entity;
using RightWay.Domain.Enum;

namespace RightWay.Domain.Interface;

public interface IOrderRepository
    : IBaseRepository<Order>
{
    Task<Order?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<List<Order>> GetOrdersByStatusAsync(OrderStatusEnum status, CancellationToken cancellationToken);
}