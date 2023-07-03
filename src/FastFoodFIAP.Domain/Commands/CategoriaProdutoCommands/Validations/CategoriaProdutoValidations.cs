using FluentValidation;

namespace FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands.Validations
{
    public abstract class CategoriaProdutoValidations<T> : AbstractValidator<T> where T : CategoriaProdutoCommand
    {
        protected void ValidaId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O Id da categoria não foi informado");
        }

        protected void ValidaNome()
        {
            RuleFor(c => c.Nome)
                .Length(3, 50).WithMessage("O Nome da categoria deve ter entre 3 e 50 caracteres");
        }
    }
}