namespace FastFoodFIAP.Domain.Commands.AndamentoCommands.Validations
{
    public class AndamentoValidationsUpdate : AndamentoValidations<AndamentoUpdateCommand>
    {
        public AndamentoValidationsUpdate()
        {
            ValidaId();
            ValidaDataHoraFimNaoNula();
            ValidaDataHoraFimMaiorIgualInicio();
        }
    }
}
