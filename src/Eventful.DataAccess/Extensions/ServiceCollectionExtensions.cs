using Eventful.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Eventful.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEventfulDataAccessLayer(this IServiceCollection services)
        {
            services.AddTransient<IGoogleApiRepository, GoogleApiRepository>();
            services.AddTransient<IEventfulApiRepository, EventfulApiRepository>();
        }
    }
}
