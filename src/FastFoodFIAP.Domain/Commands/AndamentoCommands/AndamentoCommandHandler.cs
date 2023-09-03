using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FluentValidation.Results;
using GenericPack.Messaging;
using MediatR;

namespace FastFoodFIAP.Domain.Commands.AndamentoCommands
{
    public class AndamentoCommandHandler : CommandHandler,
        IRequestHandler<AndamentoCreateCommand, CommandResult>,
        IRequestHandler<AndamentoUpdateCommand, CommandResult>
    {

        private readonly IAndamentoRepository _repository;
        public AndamentoCommandHandler(IMediator mediator, IAndamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(AndamentoCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var andamentos = await _repository.GetAllByPedido(request.PedidoId);

            //Validar se já existe um andamento para o pedido com a mesma situação
            if (andamentos.Any(p => p.SituacaoId == request.SituacaoId))
            {
                AddError("O pedido já possui a mesma situação.");
                return CommandResult;
            }

            //Validar se o andamento segue a ordem da situação
            var andamentoAtual = andamentos.Where(p => p.Atual == true).FirstOrDefault();
            if (andamentoAtual != null)
            {
                if (andamentoAtual.SituacaoId > request.SituacaoId)
                {
                    AddError("A situação não corresponde a ordem de atendimento.");
                    return CommandResult;
                }
            }           

            var andamento = new Andamento(Guid.NewGuid(), request.PedidoId, request.FuncionarioId, request.SituacaoId, request.DataHoraInicio, null, request.Atual);
            _repository.Add(andamento);

            return await Commit(_repository.UnitOfWork, request.PedidoId);
        }

        public async Task<CommandResult> Handle(AndamentoUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var andamentoExiste = await _repository.GetById(request.Id);
            if (andamentoExiste is null)
            {
                AddError("O Andamento não existe.");
                return CommandResult;
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
