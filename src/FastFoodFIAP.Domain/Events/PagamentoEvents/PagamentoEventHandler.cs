using System.Threading;
using System.Threading.Tasks;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using MediatR;


namespace FastFoodFIAP.Domain.Events.PagamentoEvents
{
    public class PagamentoEventHandler :
        INotificationHandler<PagamentoCreateEvent>
    {

        private readonly IPagamentoRepository _repository;
        public PagamentoEventHandler(IPagamentoRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(PagamentoCreateEvent notification, CancellationToken cancellationToken)
        {
            var pagamento = new Pagamento(Guid.NewGuid(), notification.QrCode, notification.Valor, notification.PedidoId);
            
            _repository.Add(pagamento);            

            return Task.CompletedTask;
        }        
    }
}
