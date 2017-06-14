using Eventful.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Eventful.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<List<Event>> Search()
        {
            string address = "Test Addresss";
            Location location = await _googleApiRepository.GetLocation(address);
            List<Event> events = await _eventfulApiRepository.GetEvents(location);

            return events;
        }
    }
}