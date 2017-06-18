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
        private IMapper _mapper;
        private IGoogleApiRepository _googleApiRepository;
        private IEventfulApiRepository _eventfulApiRepository;

        public EventSearchHandler(IMapper mapper, IGoogleApiRepository googleApiRepository, IEventfulApiRepository eventfulApiRepository)
        {
            _mapper = mapper;
            _googleApiRepository = googleApiRepository;
            _eventfulApiRepository = eventfulApiRepository;
        }

        public async Task<SearchQueryResult> DoWork(SearchQuery query)
        {
            var location = await _googleApiRepository.GetLocation(query.Address);

            var events = await _eventfulApiRepository.GetEvents(
                location.Latitude,
                location.Longitude,
                query.Radius,
                query.DateStart,
                query.DateEnd,
                query.Category);

            return new SearchQueryResult(_mapper.Map<List<Event>>(events));
        }
    }
}