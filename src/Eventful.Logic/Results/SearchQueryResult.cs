using Eventful.Logic.Models;
using System.Collections.Generic;

namespace Eventful.Logic.Results
{
    public class SearchQueryResult
    {
        public SearchQueryResult(IEnumerable<Event> events)
        {
            Events = events;
        }

        public IEnumerable<Event> Events { get; set; }
    }
}