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
                .Length(3, 100)
                .When(c => c.Nome != null)
                .WithMessage("O Nome do cliente deve ter entre 3 e 100 caracteres");

            RuleFor(cliente => cliente.Nome)                                               
                .NotNull()
                .When(c => c.Cpf == null)
                .WithMessage("O Nome é requerido para clientes sem CPF");
        }
        
        protected void ValidaEmail()
        {
            RuleFor(cliente => cliente.Email) 
                .EmailAddress()                                                           
                .When(c => c.Email != null)                 
                .WithMessage("O E-mail não possui um formato válido");
            
            RuleFor(cliente => cliente.Email)                                               
                .NotNull()
                .When(c => c.Cpf == null)
                .WithMessage("O E-mail é requerido para clientes sem CPF");

        }

        protected void ValidaCpf()
        {
            RuleFor(cliente => cliente.Cpf)
                .IsValidCPF()
                .When(cliente => cliente.Cpf != null)
                .WithMessage("O CPF não é válido");

            RuleFor(cliente => cliente.Cpf)                                               
                .NotNull()
                .When(c => c.Nome == null || c.Email == null)
                .WithMessage("O CPF é requerido para clientes sem um Nome e E-mail válidos");
        }


    }
}