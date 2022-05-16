using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Commands.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
