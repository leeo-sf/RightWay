using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWay.Data.EntityTypeConfiguration.Base;
using RightWay.Domain.Entity;

namespace RightWay.Data.EntityTypeConfiguration;

internal class RouteEntityTypeConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.ToTable("route");
        builder.ConfigureBaseEntity();
        builder.Property(e => e.EstimatedStart).HasColumnName("estimated_start").IsRequired().HasComment("Data estimada de partida");
        builder.Property(e => e.EstimatedEnd).HasColumnName("estimated_end").IsRequired().HasComment("Data estimada de finalização da rota");
        builder.Property(e => e.TotalDistanceKm).HasColumnName("total_distance_km").IsRequired().HasComment("Total da rota em KM");
        builder.Property(c => c.Status).IsRequired().HasConversion<string>().HasColumnName("status").HasComment("Status");
        builder.Property(e => e.DepartureAddressId).HasColumnName("departure_address_id").IsRequired().HasComment("Endereço de partida");
        builder.Property(e => e.VehicleId).HasColumnName("vehicle_id").IsRequired().HasComment("Veículo que será utilizado");
        builder.HasOne(c => c.DepartureAddress).WithOne(c => c.Route).HasForeignKey<Address>(c => c.RouteId);
        builder.HasOne(c => c.Vehicle).WithOne(c => c.Route).HasForeignKey<Vehicle>(c => c.RouteId);
        builder.HasMany(c => c.Orders).WithOne(c => c.Route).HasForeignKey(c => c.RouteId);
    }
}