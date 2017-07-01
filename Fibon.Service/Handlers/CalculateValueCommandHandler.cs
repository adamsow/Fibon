using System;
using System.Threading.Tasks;
using Fibon.Messages;
using Fibon.Messages.Events;
using RawRabbit;

namespace Fibon.Service.Handlers
{
    public class CalculateValueCommandHandler : ICommandHandler<CalculateValueCommand>
    {
        private IBusClient _busClient;
        public CalculateValueCommandHandler(IBusClient busClient)
        {
           _busClient = busClient; 
        }

        public async Task HandleAsync(CalculateValueCommand command)
        {
            int result = Fib(command.Number);

            await _busClient.PublishAsync(new ValueCalculatedEvent(command.Number, result));
        }

        private static int Fib(int n)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}