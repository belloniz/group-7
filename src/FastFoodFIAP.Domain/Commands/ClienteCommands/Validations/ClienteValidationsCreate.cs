namespace FastFoodFIAP.Domain.Commands.ClienteCommands.Validations
{
    public class ClienteValidationsCreate:ClienteValidations<ClienteCreateCommand>
    {
        public ClienteValidationsCreate(){            
            ValidaNome();
            ValidaEmail();
            ValidaCpf();
        }
    }
}