using System;
using FluentValidation.Results;
using MediatR;

namespace GenericPack.Messaging
{
    public abstract class Command : Message, IRequest<CommandResult>, IBaseRequest
    {
        public DateTime Timestamp { get; private set; }
        public CommandResult CommandResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
            CommandResult = new CommandResult();
        }

        public virtual bool IsValid()
        {
            return CommandResult.ValidationResult.IsValid;
        }
    }


}

