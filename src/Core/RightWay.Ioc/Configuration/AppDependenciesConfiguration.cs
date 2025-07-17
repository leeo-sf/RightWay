using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RightWay.Data;
using RightWay.Domain;

namespace RightWay.Ioc.Configuration;

public static class AppDependenciesConfiguration
{
    public static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(configuration["ConnectionStrings:Database"]);
        });

    public static void AddMediatorConfiguration(this IServiceCollection services)
        => services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyReference).Assembly);
        });

    public static void AddControllersConfiguration(this IServiceCollection services)
        => services.AddControllers(opt =>
            opt.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer())));
}