using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWay.Domain.Entity.Base;

namespace RightWay.Data.EntityTypeConfiguration.Base;

internal static class BaseEntityTypeConfiguration
{
    public static void ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseEntity
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id").IsRequired().HasComment("Identificador");
        builder.Property(e => e.CreatedIn).HasColumnName("created_in").IsRequired().HasComment("Data de criação");
        builder.Property(e => e.UpdatedIn).HasColumnName("updated_in").IsRequired().HasComment("Data de atualização");
    }
}