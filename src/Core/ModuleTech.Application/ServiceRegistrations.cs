using ModuleTech.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ModuleTech.Application;

public static class ServiceRegistrations
{
    public static void AddApplicationLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
      
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviorWithResponse<,>));
    }
}