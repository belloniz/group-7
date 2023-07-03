using System.Threading;
using System.Threading.Tasks;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Interfaces.Services;
using FastFoodFIAP.Domain.Models;
using MediatR;


namespace FastFoodFIAP.Domain.Events.PagamentoEvents
{
    public class PagamentoEventHandler :
        INotificationHandler<PagamentoCreateEvent>
    {

        private readonly IPagamentoRepository _repository;
        private readonly IGatewayPagamento _gateway;

        public PagamentoEventHandler(IPagamentoRepository repository, IGatewayPagamento gateway)
        {
            _repository = repository;
            _gateway = gateway;
        }

        public Task Handle(PagamentoCreateEvent notification, CancellationToken cancellationToken)
        {
            //Simulador gateway de pagamento
            var qrCode = _gateway.SolicitarQrCode(notification.Id, notification.Descricao, notification.Valor);

            var pagamento = new Pagamento(Guid.NewGuid(), qrCode, notification.Valor, notification.PedidoId);
            
            _repository.Add(pagamento);            

            return Task.CompletedTask;
        }        
    }
}
