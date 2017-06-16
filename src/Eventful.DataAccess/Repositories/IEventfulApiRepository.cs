using Eventful.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventful.DataAccess.Repositories
{
    public interface IEventfulApiRepository
    {
        Task<List<Event>> GetEvents(Location location, float radius, DateTime dateStart, DateTime dateEnd, string category);
    }
}