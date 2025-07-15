using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWay.Data.EntityTypeConfiguration.Base;
using RightWay.Domain.Entity;

namespace RightWay.Data.EntityTypeConfiguration;

internal class DriverEntityTypeConfiguration
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.ToTable("address");
        builder.ConfigureBaseEntity();
        builder.Property(c => c.Name).IsRequired().HasColumnName("name").HasComment("Nome");
        builder.Property(c => c.DriverLincenseNumber).IsRequired().HasColumnName("driver_lincense_number").HasComment("Número da carteira de motorista");
        builder.Property(c => c.Phone).IsRequired().HasColumnName("phone").HasComment("Telefone");
    }
}