using System.Collections.Generic;
using Eventful.Common.Entities;
using System.Threading.Tasks;

namespace Eventful.DataAccess
{
    public interface IEventfulApiRepository
    {
        Task<List<Event>> GetEvents(Location location);
    }
}
