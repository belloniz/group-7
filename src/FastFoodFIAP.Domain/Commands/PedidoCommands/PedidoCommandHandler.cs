using FastFoodFIAP.Domain.Events.AndamentoEvents;
using FastFoodFIAP.Domain.Events.PagamentoEvents;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using FluentValidation.Results;
using GenericPack.Messaging;
using MediatR;

namespace FastFoodFIAP.Domain.Commands.PedidoCommands
{
    public class PedidoCommandHandler: CommandHandler,
        IRequestHandler<PedidoCreateCommand, CommandResult>,
        IRequestHandler<PedidoUpdateCommand, CommandResult>,
        IRequestHandler<PedidoDeleteCommand, CommandResult>
    {
        private readonly IPedidoRepository _repository;

        public PedidoCommandHandler(IMediator mediator, IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(PedidoCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;            

            var pedido = new Pedido(Guid.NewGuid(),request.ClienteId);                            
            
            foreach (var item in request.Combos)
                pedido.AddCombo(item.Quantidade, item.Produtos);

            pedido.AddDomainEvent(new AndamentoCreateEvent(pedido.Id, null, (int)Models.Enums.SituacaoPedido.Realizado, true));
                        
            pedido.AddDomainEvent(new PagamentoCreateEvent(pedido));

            _repository.Add(pedido);            

            return await Commit(_repository.UnitOfWork, pedido.Id);
        }

        public async Task<CommandResult> Handle(PedidoUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var pedidoExiste = await _repository.GetById(request.Id);
            if (pedidoExiste is null)
            {
                AddError("O Pedido não existe.");
                return CommandResult;
            }

            var pedido = new Pedido(request.Id, request.ClienteId);

            foreach (var item in request.Combos)
                pedido.AddCombo(item.Quantidade, item.Produtos);

            _repository.Update(pedido);            

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<CommandResult> Handle(PedidoDeleteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var pedidoExiste = await _repository.GetById(request.Id);
            if (pedidoExiste is null)
            {
                AddError("O Pedido não existe.");
                return CommandResult;
            }                                  

            _repository.Remove(pedidoExiste);            

            return await Commit(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
