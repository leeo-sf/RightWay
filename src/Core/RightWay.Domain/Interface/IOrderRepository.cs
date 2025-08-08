using RightWay.Domain.Entity;

namespace RightWay.Domain.Interface;

public interface IOrderRepository
    : IBaseRepository<Order>
{
    Task<List<Order>> AwaitingSeparationAsync(CancellationToken cancellationToken);
}