using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightWay.Data.EntityTypeConfiguration.Base;
using RightWay.Domain.Entity;

namespace RightWay.Data.EntityTypeConfiguration;

internal class RouteEntityTypeConfiguration
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.ToTable("address");
        builder.ConfigureBaseEntity();

        builder.Property(c => c.Status).IsRequired().HasConversion<string>().HasColumnName("status").HasComment("Status");
    }
}