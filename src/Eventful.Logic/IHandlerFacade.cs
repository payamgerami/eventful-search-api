using System.Threading.Tasks;

namespace Eventful.Logic
{
    public interface IHandlerFacade
    {
        Task<TOutput> Invoke<TInput, TOutput>(TInput input);

        Task Invoke<TInput>(TInput input);
    }
}
