using FluentValidation;

namespace FastFoodFIAP.Domain.Commands.PedidoCommands.Validations
{
    public abstract class PedidoValidations<T> : AbstractValidator<T> where T : PedidoCommand    
    {
        protected void ValidaId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O Id do pedido não foi informado");
        }

        protected void ValidaCliente()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("O Id do Cliente não foi informado");
        }

        protected void ValidaExisteItens()
        {
            RuleFor(c => c.Combos.Count)
                .GreaterThan(0).WithMessage("O pedido deve possuir pelo menos uma combo");
        }        
    }
}
