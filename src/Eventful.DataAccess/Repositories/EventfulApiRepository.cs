using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventful.DataAccess.Entities;

namespace Eventful.DataAccess.Repositories
{
    public class EventfulApiRepository : IEventfulApiRepository
    {
        public async Task<List<Event>> GetEvents(Location location, float radius, DateTime dateStart, DateTime dateEnd, string category)
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