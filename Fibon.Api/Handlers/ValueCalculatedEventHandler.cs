using System;
using System.Threading.Tasks;
using Fibon.Api.FibbonRepository;
using Fibon.Messages.Events;
using RawRabbit;

namespace Fibon.Api.Handlers
{
    public class ValueCalculatedEventHandler : IEventHandler<ValueCalculatedEvent>
    {
        private readonly IRepository _repository;
        
        public ValueCalculatedEventHandler(IRepository repository)
        {
            _repository = repository;
        }
        public Task HandleAsync(ValueCalculatedEvent @event)
        {
           _repository.Add(@event.Number, @event.Value);
           return Task.CompletedTask;
        }
    }
}