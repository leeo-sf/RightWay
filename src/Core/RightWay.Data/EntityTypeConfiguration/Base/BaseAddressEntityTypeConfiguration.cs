using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWay.Domain.Entity.Base;

namespace RightWay.Data.EntityTypeConfiguration.Base;

internal class BaseAddressEntityTypeConfiguration : IEntityTypeConfiguration<BaseAddress>
{
    public void Configure(EntityTypeBuilder<BaseAddress> builder)
    {
        builder.ToTable("base_address");
        builder.ConfigureBaseEntity();
        builder.Property(c => c.ZipCode).IsRequired().HasColumnName("zip_code").HasComment("CEP");
        builder.Property(c => c.PublicPlace).IsRequired().HasColumnName("public_place").HasComment("Logradouro");
        builder.Property(c => c.Neighborhood).IsRequired().HasColumnName("neighborhood").HasComment("Bairro");
        builder.Property(c => c.Locality).IsRequired().HasColumnName("locality").HasComment("Localidade");
        builder.Property(c => c.Uf).IsRequired().HasConversion<string>().HasColumnName("uf").HasComment("Estado");
        builder.Property(c => c.State).IsRequired().HasColumnName("state").HasComment("Estado");
        builder.Property(c => c.Region).IsRequired().HasColumnName("region").HasComment("Região");
        builder.Property(c => c.MunicipalCode).IsRequired().HasColumnName("municipal_code").HasComment("Código municipal");
        builder.Property(c => c.Latitude).IsRequired().HasColumnName("latitude").HasComment("Latitude");
        builder.Property(c => c.Longitude).IsRequired().HasColumnName("longitude").HasComment("Longitude");
        builder.Property(c => c.Latitude).IsRequired().HasColumnName("latitude").HasComment("Latitude");
        builder.HasMany(c => c.Addresses).WithOne(c => c.BaseAddress).HasForeignKey(c => c.BaseAddressId);
    }
}