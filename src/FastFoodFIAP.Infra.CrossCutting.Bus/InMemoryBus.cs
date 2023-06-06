using FluentValidation.Results;
using MediatR;
using GenericPack.Mediator;
using GenericPack.Messaging;

namespace FastFoodFIAP.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        //private readonly IEventStore _eventStore;


        //public InMemoryBus(IEventStore eventStore, IMediator mediator)
        public InMemoryBus(IMediator mediator)
        {
            //_eventStore = eventStore;
            _mediator = mediator;
        }

        //public async Task PublishEvent<T>(T @event) where T : Event
        //{
        //    if (!@event.MessageType.Equals("DomainNotification"))
        //        _eventStore?.Save(@event);

        //    await _mediator.Publish(@event);
        //}

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}