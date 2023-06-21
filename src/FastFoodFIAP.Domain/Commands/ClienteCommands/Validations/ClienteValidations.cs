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
                .Must(ContemSimbolosDoEmail)
                .Length(4, 75)
                .When(cliente => !string.IsNullOrEmpty(cliente.Email))
                .WithMessage("Digite um e-mail válido");
        }

        private bool ContemSimbolosDoEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        protected void ValidaCpf()
        {
            RuleFor(cliente => cliente.Cpf)
                .NotEmpty()
                .Length(11)
                .When(cliente => !string.IsNullOrEmpty(cliente.Cpf.ToString()))
                .WithMessage("Digite um cpf válido com 11 números");
        }
    }
}