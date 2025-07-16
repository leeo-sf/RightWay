using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace RightWay.Ioc.Configuration;

public static class ApiVersioningConfiguration
{
    public static void AddVersioning(this IServiceCollection services)
        => services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1);
            opt.ApiVersionReader = new UrlSegmentApiVersionReader();
        })
        .AddApiExplorer(opt =>
        {
            opt.GroupNameFormat = "'v'VVV";
            opt.SubstituteApiVersionInUrl = true;
        });
}