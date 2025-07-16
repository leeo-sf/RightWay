using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWay.Data.EntityTypeConfiguration.Base;
using RightWay.Domain.Entity;

namespace RightWay.Data.EntityTypeConfiguration;

internal class RouteOrderEntityTypeConfiguration : IEntityTypeConfiguration<RouteOrder>
{
    public void Configure(EntityTypeBuilder<RouteOrder> builder)
    {
        builder.ToTable("route_order");
        builder.ConfigureBaseEntity();
        builder.Property(e => e.RouteId).HasColumnName("route_id").IsRequired().HasComment("Rota");
        builder.Property(e => e.OrderId).HasColumnName("order_id").IsRequired().HasComment("Pedido");
        builder.Property(e => e.DeliveryOrder).HasColumnName("delivery_order").IsRequired().HasComment("Ordem de entrega");
        builder.HasOne(c => c.Route).WithMany(c => c.Orders).HasForeignKey(c => c.RouteId);
        builder.HasOne(c => c.Order).WithOne().HasForeignKey<RouteOrder>(c => c.OrderId);
    }
}