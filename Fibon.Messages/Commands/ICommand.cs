using System.Threading.Tasks;

namespace Fibon.Messages
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }

    public class CalculateValueCommand : ICommand
    {
        public int Number { get; private set; }

        protected CalculateValueCommand()
        {
        }

        public CalculateValueCommand(int number)
        {
            Number = number;
        }

    }
}