using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Repositories.Generic.Implementations;
using BusinessLogicLayer.Services.Abstractions;
using BusinessLogicLayer.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.ServiceRegistrations;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {

        services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
        //services.AddScoped<IAttendanceService, AttendanceService>();
        //services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<IBasketItemService, BasketItemService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductImageService, ProductImageService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ISettingService, SettingService>();
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<ISubscribeService, SubscribeService>();
        services.AddScoped<ITagService, TagService>();
        

        services.AddAutoMapper(typeof(MappingProfile));

        return services;

    }
}
