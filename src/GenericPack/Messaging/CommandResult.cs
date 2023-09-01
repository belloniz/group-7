using FluentValidation.Results;

namespace GenericPack.Messaging;

public class CommandResult
{
    public ValidationResult ValidationResult { get; set; }
    public Object? Id { get; set; }

    public CommandResult()
    {
        ValidationResult = new ValidationResult();
    }
}
