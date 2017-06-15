using Eventful.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventful.Contract.V1.Requests;
using Eventful.Contract.V1.Responses;

namespace Eventful.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class EventsController : Controller
    {
        private IGoogleApiRepository _googleApiRepository;
        private IEventfulApiRepository _eventfulApiRepository;

        public EventsController(IGoogleApiRepository googleApiRepository, IEventfulApiRepository eventfulApiRepository)
        {
            _googleApiRepository = googleApiRepository;
            _eventfulApiRepository = eventfulApiRepository;
        }

        [HttpGet]
        public async Task<SearchEventsResponse> Search(SearchEventsRequest request)
        {
            var location = await _googleApiRepository.GetLocation(request.Address);
            var events = await _eventfulApiRepository.GetEvents(location);

            return new SearchEventsResponse(AutoMapper.Mapper.Map<List<Contract.V1.Models.Event>>(events));
        }
    }
}