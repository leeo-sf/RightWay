using RightWay.Domain.Interface;

namespace RightWay.Data.Repository;

public class BaseRepository<T>(AppDbContext context)
    : IBaseRepository<T> where T : class
{
    protected readonly AppDbContext _context = context;

    public virtual async Task CreateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        _context.AddRange(entities);
        await _context.SaveChangesAsync(cancellationToken);
    }
}