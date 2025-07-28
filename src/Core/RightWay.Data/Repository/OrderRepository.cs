using RightWay.Domain.Entity;
using RightWay.Domain.Interface;

namespace RightWay.Data.Repository;

public class OrderRepository(AppDbContext context)
    : BaseRepository<Order>(context), IOrderRepository
{
}