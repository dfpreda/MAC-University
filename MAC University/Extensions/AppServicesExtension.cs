using MAC.Data.UnitOfWork;
using MAC.Services.DataService;
using MAC.Services.DataService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MAC.Extensions
{
    public static class AppServicesExtension
    {
        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseCrudDataService<,>), typeof(BaseCrudDataService<,>));
            services.AddScoped<IClassDataService, ClassDataService>();
            services.AddAutoMapper(typeof(MAC.Data.DTO.Bootstrap));
        }
    }
}
