using Eventful.Contract.V1.Models;
using System.Collections.Generic;

namespace Eventful.Contract.V1.Responses
{
    public class SearchEventsResponse
    {
        public SearchEventsResponse(IEnumerable<Event> events)
        {
            Events = events;
        }

        public IEnumerable<Event> Events { get; set; }
    }
}