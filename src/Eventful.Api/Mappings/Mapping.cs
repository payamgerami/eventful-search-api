using AutoMapper;

namespace Eventful.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contract.V1.Requests.SearchEventsRequest, Logic.Queries.SearchQuery>();
            CreateMap<Logic.Results.SearchQueryResult, Contract.V1.Responses.SearchEventsResponse>();
            CreateMap<Logic.Models.Event, Contract.V1.Responses.EventResponse>();
            CreateMap<DataAccess.Entities.EventfulEvent, Logic.Models.Event>();
        }
    }
}