using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Data.Repositories;
using TestEducationCenterUoW.Service.Interfaces;
using TestEducationCenterUoW.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TestEducationCenterUoW.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
