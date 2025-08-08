using RightWay.Domain.Entity;

namespace RightWay.Domain.Interface;

public interface IOrderRepository
    : IBaseRepository<Order>
{
    Task<Order?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<List<Order>> AwaitingSeparationAsync(CancellationToken cancellationToken);
}