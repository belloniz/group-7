using System.Threading.Tasks;
using FluentValidation.Results;
using GenericPack.Data;

namespace GenericPack.Messaging
{
    public abstract class CommandHandler
    {
        protected CommandResult CommandResult;

        protected CommandHandler()
        {
            CommandResult = new CommandResult();
        }

        protected void AddError(string mensagem)
        {
            CommandResult.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<CommandResult> Commit(IUnitOfWork uow, string message, Object? id)
        {
            if (!await uow.Commit()) AddError(message);
            CommandResult.Id = id;
            return CommandResult;
        }

        protected async Task<CommandResult> Commit(IUnitOfWork uow, Object? id = null)
        {
            return await Commit(uow, "There was an error saving data",id).ConfigureAwait(false);
        }
    }
}