using System.Collections.Generic;
using Eventful.Common.Entities;
using System.Threading.Tasks;

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
                    Name = "TestEvent1"
                },
                new Event{
                    Name = "TestEvent2"
                }
            };
        }
    }
}