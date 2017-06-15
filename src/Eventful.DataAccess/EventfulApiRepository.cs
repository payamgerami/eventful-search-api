using System.Collections.Generic;
using Eventful.Common.Entities;
using System.Threading.Tasks;
using System;

namespace Eventful.DataAccess
{
    public class EventfulApiRepository : IEventfulApiRepository
    {
        public async Task<List<Event>> GetEvents(Location location)
        {
            await Task.CompletedTask;
            return new List<Event>
            {
                new Event{
                    Title = "TestEvent1",
                    Date = DateTime.UtcNow
                },
                new Event{
                    Title = "TestEvent2",
                    Date = DateTime.UtcNow
                }
            };
        }
    }
}