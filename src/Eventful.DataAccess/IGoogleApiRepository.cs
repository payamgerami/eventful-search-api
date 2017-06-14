using Eventful.Common.Entities;
using System.Threading.Tasks;

namespace Eventful.DataAccess
{
    public interface IGoogleApiRepository
    {
        Task<Location> GetLocation(string address);
    }
}