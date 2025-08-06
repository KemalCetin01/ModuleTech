using ModuleTech.Application.Core.Persistence.Repositories;
using ModuleTech.Application.Core.Persistence.Repositories.UserOtp;
using ModuleTech.Application.Core.Persistence.UoW;
using ModuleTech.Identity.Persistence.Repositories;
using ModuleTech.Persistence.Context;
using ModuleTech.Persistence.Repositories;
using ModuleTech.Persistence.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ozdisan.ECommerce.Services.Identity.Persistence.Repositories;

namespace ModuleTech.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection")));

        serviceCollection.AddScoped<IModuleTechUnitOfWork, ModuleTechUnitOfWork>();

        serviceCollection.AddScoped<IEmployeeRoleRepository, EmployeeRoleRepository>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IBusinessUserRepository, BusinessUserRepository>();
        serviceCollection.AddScoped<IUserEmployeeRepository, UserEmployeeRepository>();
        serviceCollection.AddScoped<IUserOTPRepository, UserOTPRepository>();
        serviceCollection.AddScoped<IUserResetPasswordRepository, UserResetPasswordRepository>();

    }
}
