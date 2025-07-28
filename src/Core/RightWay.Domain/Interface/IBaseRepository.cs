namespace RightWay.Domain.Interface;

public interface IBaseRepository<T>
    where T : class
{
    public Task CreateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
}