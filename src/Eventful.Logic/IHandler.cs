using System.Threading.Tasks;

namespace Eventful.Logic
{
    public interface IHandler<in TInput, TOutput>
    {
        Task<TOutput> DoWork(TInput input);
    }

    public interface IHandler<in TInput>
    {
        Task DoWork(TInput input);
    }
}