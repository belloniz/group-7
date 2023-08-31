using FastFoodFIAP.Domain.CustomValidations;
using FluentValidation;

namespace FastFoodFIAP.Domain.Commands.PagamentoCommands.Validations
{
    public abstract class PagamentoValidations<T> : AbstractValidator<T> where T : PagamentoCommand
    {
        protected void ValidaId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O Id do pagamento não foi informado");
        }

        protected void ValidaSituacao()
        {
            RuleFor(c => c.SituacaoId)
                .NotNull()
                .WithMessage("O Id da situacao do pagamento não foi informado");
        }
    }
}
