using Eventful.Contract.V1.Models;
using System.Collections.Generic;

namespace Eventful.Contract.V1.Responses
{
    public class SearchEventsResponse
    {
        public SearchEventsResponse()
        {
            Events = new List<Event>();
        }

        public SearchEventsResponse(List<Event> events)
        {
            Events = events;
        }

        public List<Event> Events { get; set; }
    }
}
