using System.Collections.Generic;

namespace Eventful.Contract.V1.Responses
{
    public class SearchEventsResponse
    {
        public SearchEventsResponse(IEnumerable<EventResponse> events)
        {
            Events = events;
        }

        public IEnumerable<EventResponse> Events { get; set; }
    }
}