using Makarov_Mikhail_Kt_31_20_Lab1.interfaces.StudentInterfaces;
using Makarov_Mikhail_Kt_31_20_Lab1.Models;

namespace Makarov_Mikhail_Kt_31_20_Lab1.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentFilterService>();
            return services;
        }
    }
}
