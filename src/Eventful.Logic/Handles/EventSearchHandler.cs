using Eventful.DataAccess.Repositories;
using Eventful.Logic.Queries;
using Eventful.Logic.Results;
using System.Threading.Tasks;
using AutoMapper;
using Eventful.Logic.Models;
using System.Collections.Generic;

namespace Eventful.Logic.Handles
{
    public class EventSearchHandler : IHandler<SearchQuery, SearchQueryResult>
    {
        private IGoogleApiRepository GoogleApiRepository { get; set; }
        private IEventfulApiRepository EventfulApiRepository { get; set; }

        public EventSearchHandler(IGoogleApiRepository googleApiRepository, IEventfulApiRepository eventfulApiRepository)
        {
            GoogleApiRepository = googleApiRepository;
            EventfulApiRepository = eventfulApiRepository;
        }

        public async Task<SearchQueryResult> DoWork(SearchQuery query)
        {
            var location = await GoogleApiRepository.GetLocation(query.Address);
            var events = await EventfulApiRepository.GetEvents(location, query.Radius, query.DateStart, query.DateEnd, query.Category);

            return new SearchQueryResult(Mapper.Map<List<Event>>(events));
        }
    }
}