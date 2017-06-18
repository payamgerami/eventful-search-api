namespace Eventful.Api.Mappings
{
    public static class Mapping
    {
        public static void ConfigureMap()
        {
            AutoMapper.Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<Contract.V1.Requests.SearchEventsRequest, Logic.Queries.SearchQuery>();
                    cfg.CreateMap<Logic.Results.SearchQueryResult, Contract.V1.Responses.SearchEventsResponse>();
                    cfg.CreateMap<Logic.Models.Event, Contract.V1.Responses.EventResponse>();
                    cfg.CreateMap<DataAccess.Entities.EventfulEvent, Logic.Models.Event>();
                });
        }
    }
}