using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RightWay.Application;
using RightWay.Application.Config;
using RightWay.Application.Validator;
using RightWay.Data;
using RightWay.RabbitMQ.Interface;
using RightWay.RabbitMQ.Service;

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
    {
        services.AddControllers(opt => opt.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer())));

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<RouteCalculationValidator>();
    }

    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureServiceCredentials<AppConfiguration>("Service", configuration);

        services.AddSingleton<IRabbitMQService, RabbitMQService>();
    }

    public static void ConfigureValidationInvalidModelStateResponseFactory(this IServiceCollection services)
        => services.Configure<ApiBehaviorOptions>(opt =>
        {
            opt.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState
                    .SelectMany(ms => ms.Value!.Errors.Select(error => new
                    {
                        Field = ms.Key,
                        Error = error.ErrorMessage
                    })).ToList();

                var responseObject = new
                {
                    Message = "Validation error(s) found.",
                    Errors = errors
                };

                return new BadRequestObjectResult(responseObject);
            };
        });

    private static void ConfigureServiceCredentials<T>(this IServiceCollection services, string sectionName, IConfiguration configuration) where T : class
        => services.AddSingleton(opt => configuration.GetSection(sectionName).Get<T>()!);
}