using Eventful.DataAccess.Entities;
using System.Threading.Tasks;

namespace Eventful.DataAccess.Repositories
{
    public interface IGoogleApiRepository
    {
        Task<GoogleLocation> GetLocation(string address);
    }
}