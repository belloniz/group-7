using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FluentValidation.Results;
using GenericPack.Messaging;
using MediatR;

namespace FastFoodFIAP.Domain.Commands.AndamentoCommands
{
    public class AndamentoCommandHandler : CommandHandler,
        IRequestHandler<AndamentoCreateCommand, ValidationResult>,
        IRequestHandler<AndamentoUpdateCommand, ValidationResult>
    {

        private readonly IAndamentoRepository _repository;
        public AndamentoCommandHandler(IMediator mediator, IAndamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(AndamentoCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            //######################################
            //Validar se o pedido existe
            //Validar se a situação (id) existe
            //Validar se a situação já existe para o pedido            
            //Validar se o andamento segue a ordem da situação
            //Validar se o funcionário existe

            var andamento = new Andamento(request.Id, request.PedidoId, request.FuncionarioId, request.SituacaoId, request.DataHoraInicio, null, request.Atual);

            _repository.Add(andamento);

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AndamentoUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var andamentoExiste = await _repository.GetById(request.Id);
            if (andamentoExiste is null)
            {
                AddError("O Andamento não existe.");
                return ValidationResult;
            }            
            
            var andamento = new Andamento(andamentoExiste.Id, andamentoExiste.PedidoId, andamentoExiste.FuncionarioId, andamentoExiste.SituacaoId, andamentoExiste.DataHoraInicio, request.DataHoraFim, request.Atual);

            _repository.Update(andamento);

            return await Commit(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
