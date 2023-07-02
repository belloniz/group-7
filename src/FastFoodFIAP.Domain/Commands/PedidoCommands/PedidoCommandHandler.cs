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
        IRequestHandler<PedidoCreateCommand, ValidationResult>,
        IRequestHandler<PedidoUpdateCommand, ValidationResult>,
        IRequestHandler<PedidoDeleteCommand, ValidationResult>
    {
        private readonly IPedidoRepository _repository;
        private readonly IAndamentoRepository _repositoryAndamento;

        public PedidoCommandHandler(IMediator mediator, IPedidoRepository repository, IAndamentoRepository repositoryAndamento)
        {
            _repository = repository;
            _repositoryAndamento = repositoryAndamento;
        }

        public async Task<ValidationResult> Handle(PedidoCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;            

            var pedido = new Pedido(Guid.NewGuid(),request.ClienteId);            
            
            foreach (var item in request.Combos)
                pedido.AddCombo(item.Quantidade, item.Produtos);

            pedido.AddDomainEvent(new AndamentoCreateEvent(pedido.Id, null, (int)Models.Enums.SituacaoPedido.Realizado, false));
            pedido.AddDomainEvent(new AndamentoCreateEvent(pedido.Id, null, (int)Models.Enums.SituacaoPedido.Recebido, true));            
        
            pedido.AddDomainEvent(new PagamentoCreateEvent(pedido.Id, "QRCODE", pedido.TotalPedido()));

            _repository.Add(pedido);            

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(PedidoUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var pedidoExiste = await _repository.GetById(request.Id);
            if (pedidoExiste is null)
            {
                AddError("O Pedido não existe.");
                return ValidationResult;
            }

            var pedido = new Pedido(request.Id, request.ClienteId);

            foreach (var item in request.Combos)
                pedido.AddCombo(item.Quantidade, item.Produtos);

            _repository.Update(pedido);            

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(PedidoDeleteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var pedidoExiste = await _repository.GetById(request.Id);
            if (pedidoExiste is null)
            {
                AddError("O Pedido não existe.");
                return ValidationResult;
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
