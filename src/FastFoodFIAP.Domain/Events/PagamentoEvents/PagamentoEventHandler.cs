using System.Threading;
using System.Threading.Tasks;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Interfaces.Services;
using FastFoodFIAP.Domain.Models;
using GenericPack.Messaging;
using MediatR;


namespace FastFoodFIAP.Domain.Events.PagamentoEvents
{
    public class PagamentoEventHandler :
        INotificationHandler<PagamentoCreateEvent>
    {

        private readonly IPagamentoRepository _repository;
        private readonly IPedidoRepository _repositoryPedido;
        private readonly IGatewayPagamento _gateway;

        public PagamentoEventHandler(IPedidoRepository repositoryPedido, IPagamentoRepository repository, IGatewayPagamento gateway)
        {
            _repositoryPedido = repositoryPedido;
            _repository = repository;
            _gateway = gateway;
        }

        public async Task Handle(PagamentoCreateEvent notification, CancellationToken cancellationToken)
        {
            var qrCode = await _gateway.SolicitarQrCodeAsync(notification.Pedido);

            var pagamento = new Pagamento(Guid.NewGuid(), qrCode, notification.Pedido.TotalPedido(), notification.Pedido.Id, (int)Models.Enums.SituacaoPagamento.Pendente);
            
            _repository.Add(pagamento);            

            return;
        }

    }
}
