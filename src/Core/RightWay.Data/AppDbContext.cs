using Microsoft.EntityFrameworkCore;
using RightWay.Data.EntityTypeConfiguration;
using RightWay.Domain.Entity;

namespace RightWay.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Address> Address { get; set; } = default!;
    public DbSet<Driver> Driver { get; set; } = default!;
    public DbSet<Order> Order { get; set; } = default!;
    public DbSet<Route> Route { get; set; } = default!;
    public DbSet<RouteOrder> RouteOrder { get; set; } = default!;
    public DbSet<Vehicle> Vehicle { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DriverEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RouteEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RouteOrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleEntityTypeConfiguration());
    }
}