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
        builder.Property(c => c.ZipCode).IsRequired().HasColumnName("zip_code").HasComment("CEP");
        builder.Property(c => c.PublicPlace).IsRequired().HasColumnName("public_place").HasComment("Logradouro");
        builder.Property(c => c.Neighborhood).IsRequired().HasColumnName("neighborhood").HasComment("Bairro");
        builder.Property(c => c.Number).IsRequired().HasColumnName("number").HasComment("Número");
        builder.Property(c => c.Uf).IsRequired().HasConversion<string>().HasColumnName("uf").HasComment("Estado");
        builder.Property(c => c.Latitude).IsRequired().HasColumnName("latitude").HasComment("Latitude");
        builder.Property(c => c.OrderId).IsRequired().HasColumnName("order_id").HasComment("Pedido");
        builder.HasOne(c => c.Order).WithOne(c => c.Address).HasForeignKey<Order>(c => c.AddressId);
        builder.HasOne(c => c.Route).WithOne(c => c.DepartureAddress).HasForeignKey<Route>(c => c.DepartureAddressId);
    }
}