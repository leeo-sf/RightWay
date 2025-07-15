using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWay.Data.EntityTypeConfiguration.Base;
using RightWay.Domain.Entity;

namespace RightWay.Data.EntityTypeConfiguration;

internal class OrderEntityTypeConfiguration
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("address");
        builder.ConfigureBaseEntity();
        builder.Property(c => c.Weight).IsRequired().HasColumnName("weight").HasComment("Peso");
        builder.Property(c => c.Height).IsRequired().HasColumnName("height").HasComment("Altura");
        builder.Property(c => c.PriorityLevel).IsRequired().HasConversion<string>().HasColumnName("priority_level").HasComment("Nível de prioridade");
        builder.Property(c => c.Status).IsRequired().HasConversion<string>().HasColumnName("status").HasComment("Status");
        builder.Property(c => c.AddressId).IsRequired().HasColumnName("address_id").HasComment("Endereço de entrega");
        builder.HasOne(c => c.Address).WithOne(c => c.Order).HasForeignKey<Address>(c => c.OrderId);
    }
}