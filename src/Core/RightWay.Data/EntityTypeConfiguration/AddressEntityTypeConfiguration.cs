using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWay.Data.EntityTypeConfiguration.Base;
using RightWay.Domain.Entity;

namespace RightWay.Data.EntityTypeConfiguration;

internal class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");
        builder.ConfigureBaseEntity();
        builder.Property(c => c.Number).IsRequired().HasColumnName("number").HasComment("Número");
        builder.Property(c => c.Complement).HasColumnName("complement").HasComment("Complemento");
        builder.Property(c => c.OrderId).IsRequired().HasColumnName("order_id").HasComment("Pedido");
        builder.Property(c => c.RouteId).IsRequired().HasColumnName("route_id").HasComment("Rota");
        builder.HasOne(c => c.Order).WithOne(c => c.Address).HasForeignKey<Order>(c => c.AddressId);
        builder.HasOne(c => c.Route).WithOne(c => c.DepartureAddress).HasForeignKey<Route>(c => c.DepartureAddressId);
    }
}