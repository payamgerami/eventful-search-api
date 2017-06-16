using Eventful.DataAccess.Entities;
using System.Threading.Tasks;

namespace Eventful.DataAccess.Repositories
{
    public interface IGoogleApiRepository
    {
        Task<Location> GetLocation(string address);
    }
}