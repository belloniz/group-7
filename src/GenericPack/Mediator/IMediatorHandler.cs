using FluentValidation.Results;
using GenericPack.Messaging;


namespace GenericPack.Mediator
{    
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<CommandResult> SendCommand<T>(T command) where T : Command;
    }
}
