using FastFoodFIAP.Domain.CustomValidations;
using FluentValidation;

namespace FastFoodFIAP.Domain.Commands.ClienteCommands.Validations
{
    public abstract class ClienteValidations<T> : AbstractValidator<T> where T : ClienteCommand
    {
        protected void ValidaId()
        {
            RuleFor(cliente => cliente.Id)
                .NotEqual(0)
                .WithMessage("O Id do cliente não foi informado");
        }

        protected void ValidaNome()
        {
            RuleFor(cliente => cliente.Nome)
                .Length(2, 35)
                .WithMessage("O Nome do cliente deve ter entre 2 e 35 caracteres");
        }
        
        protected void ValidaEmail()
        {
            RuleFor(cliente => cliente.Email)                                               
                .EmailAddress()
                .When(cliente => cliente.Email.Length > 0);
        }

        protected void ValidaCpf()
        {
            RuleFor(cliente => cliente.Cpf)
                .IsValidCPF()
                .When(cliente => cliente.Cpf.Length > 0);
        }


    }
}