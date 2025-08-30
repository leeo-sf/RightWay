using Microsoft.EntityFrameworkCore;
using RightWay.Domain.Entity;
using RightWay.Domain.Interface;

namespace RightWay.Data.Repository;

public class AddressRepository(AppDbContext context)
    : IAddressRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<Address>?> GetExistingAddressesAsync(
        List<(string ZipCode, int Number, string PublicPlace, int MunicipalCode)> orders, CancellationToken cancellationToken)
        => await _context.Address
            .Include(x => x.BaseAddress)
            .Where(o => orders.Any(
                p => p.ZipCode == o.BaseAddress.ZipCode &&
                p.PublicPlace == o.BaseAddress.PublicPlace &&
                p.Number == o.Number &&
                p.MunicipalCode == o.BaseAddress.MunicipalCode &&
                o.BaseAddress.Latitude != null && o.BaseAddress.Longitude != null))
        .ToListAsync();
}
