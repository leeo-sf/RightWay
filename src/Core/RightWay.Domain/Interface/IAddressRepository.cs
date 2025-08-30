using RightWay.Domain.Entity;

namespace RightWay.Domain.Interface;

public interface IAddressRepository
{
    Task<List<Address>?> GetExistingAddressesAsync(
        List<(string ZipCode, int Number, string PublicPlace, int MunicipalCode)> orders, CancellationToken cancellationToken);
}