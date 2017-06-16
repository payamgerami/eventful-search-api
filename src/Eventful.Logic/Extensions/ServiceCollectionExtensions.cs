using Eventful.Logic.Handles;
using Eventful.Logic.Queries;
using Eventful.Logic.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Eventful.Logic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEventfulLogicLayer(this IServiceCollection services)
        {
            services.AddSingleton<IHandlerFacade, HandlerFacade>();
            services.AddTransient<IHandler<SearchQuery, SearchQueryResult>, EventSearchHandler>();
        }
    }
}