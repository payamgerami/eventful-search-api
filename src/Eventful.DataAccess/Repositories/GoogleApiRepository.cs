using System.Threading.Tasks;
using Eventful.DataAccess.Entities;

namespace Eventful.DataAccess.Repositories
{
    public class GoogleApiRepository : IGoogleApiRepository
    {
        public async Task<Location> GetLocation(string address)
        {
            await Task.CompletedTask;
            return new Location
            {
                Latitude = 0,
                Longitude = 0
            };
        }
    }
}
