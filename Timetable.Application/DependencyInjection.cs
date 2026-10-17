using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Timetable.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            // Pipeline для валідації
            cfg.AddBehavior(typeof(MediatR.IPipelineBehavior<,>), typeof(Common.Mediator.ValidationBehavior<,>));
        });

        return services;
    }
}