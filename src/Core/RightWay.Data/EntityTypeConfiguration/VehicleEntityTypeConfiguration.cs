using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWay.Data.EntityTypeConfiguration.Base;
using RightWay.Domain.Entity;

namespace RightWay.Data.EntityTypeConfiguration;

internal class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicle");
        builder.ConfigureBaseEntity();
        builder.Property(e => e.PlateNumber).HasColumnName("plate_number").IsRequired().HasComment("Número da placa");
        builder.Property(e => e.Model).HasColumnName("model").IsRequired().HasComment("Modelo do veículo");
        builder.Property(e => e.Capacity).HasColumnName("capacity").IsRequired().HasComment("Capacidade do veículo");
        builder.Property(e => e.DriverId).HasColumnName("driver_id").IsRequired().HasComment("Motorista");
        builder.Property(e => e.RouteId).HasColumnName("route_id").IsRequired().HasComment("Rota do veículo");
        builder.HasOne(c => c.Driver).WithOne(c => c.Vehicle).HasForeignKey<Driver>(c => c.VehicleId);
        builder.HasOne(c => c.Route).WithOne(c => c.Vehicle).HasForeignKey<Route>(c => c.VehicleId);
    }
}