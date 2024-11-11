using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCMiniProject.DataAccessLayer;

namespace DataAccessLayer.ServiceRegistrations;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AppDBContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddTransient<DBInitializer>();
        return services;
    }
}
