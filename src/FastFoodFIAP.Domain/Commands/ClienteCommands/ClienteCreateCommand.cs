using FastFoodFIAP.Domain.Commands.ClienteCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.ClienteCommands
{
    public class ClienteCreateCommand : ClienteCommand
    {
        protected ClienteCreateCommand(){}

        public ClienteCreateCommand(string nome, string email, string cpf){
            Nome=nome;
            Email=email;
            Cpf=cpf;
        }

        public override bool IsValid()
        {
            ValidationResult = new ClienteValidationsCreate().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}