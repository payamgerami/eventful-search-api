using Eventful.Common.Entities;
using System.Threading.Tasks;

namespace Eventful.DataAccess
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
