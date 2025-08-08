using Microsoft.EntityFrameworkCore;
using RightWay.Domain.Entity;
using RightWay.Domain.Enum;
using RightWay.Domain.Interface;

namespace RightWay.Data.Repository;

public class OrderRepository(AppDbContext context)
    : BaseRepository<Order>(context), IOrderRepository
{
    public async Task<Order?> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
        => await _context.Order
            .Where(x => x.Id == Id)
            .Include(x => x.Address.BaseAddress)
            .Include(x => x.Address)
            .AsNoTracking()
            .FirstOrDefaultAsync();

    public async Task<List<Order>> AwaitingSeparationAsync(CancellationToken cancellationToken)
        => await _context.Order
            .Where(x => x.Status == OrderStatusEnum.SEPARATION)
            .Include(x => x.Address)
            .Include(x => x.Address.BaseAddress)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}