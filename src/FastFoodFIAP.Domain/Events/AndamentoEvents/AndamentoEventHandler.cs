using System.Threading;
using System.Threading.Tasks;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using MediatR;


namespace FastFoodFIAP.Domain.Events.AndamentoEvents
{
    public class AndamentoEventHandler :
        INotificationHandler<AndamentoCreateEvent>
    {

        private readonly IAndamentoRepository _repository;
        public AndamentoEventHandler(IAndamentoRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AndamentoCreateEvent notification, CancellationToken cancellationToken)
        {
            var andamento = new Andamento(Guid.NewGuid(), notification.PedidoId, notification.FuncionarioId, notification.SituacaoId, 
            notification.DataHoraInicio, notification.DataHoraFim, notification.Atual);
            
            _repository.Add(andamento);            

            return Task.CompletedTask;
        }        
    }
}
