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
                Latitude = (float)32.746682,
                Longitude = (float)-117.162741
            };
        }
    }
}
