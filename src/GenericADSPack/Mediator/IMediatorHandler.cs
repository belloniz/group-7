using FluentValidation.Results;
using GenericADSPack.Messaging;


namespace GenericADSPack.Mediator
{    
    public interface IMediatorHandler
    {
        //Task PublishEvent<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
