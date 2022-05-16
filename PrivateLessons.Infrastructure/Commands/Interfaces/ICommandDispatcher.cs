using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Commands.Interfaces
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}
