using FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands;
using FluentValidation;

namespace FastFoodFIAP.Domain.Commands.AndamentoCommands.Validations
{
    public abstract class AndamentoValidations<T> : AbstractValidator<T> where T : AndamentoCommand
    {
        protected void ValidaId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0).WithMessage("O Id do andamento não foi informado");
        }        

        protected void ValidaDataHoraFimNaoNula()
        {
            RuleFor(c => c.DataHoraFim)
                .NotNull().WithMessage("A data e horário de finalização do andamento devem ser informados.");
        }

        protected void ValidaDataHoraFimMaiorIgualInicio()
        {
            RuleFor(c => c.DataHoraFim)
                .GreaterThan(c => c.DataHoraInicio)
                .When(c => c.DataHoraFim != null)
                .WithMessage("A data e horário de finalização do andamento devem ser informados.");
        }
    }
}
