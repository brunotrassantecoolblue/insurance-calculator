using System.Threading.Tasks;

namespace Insurance.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}