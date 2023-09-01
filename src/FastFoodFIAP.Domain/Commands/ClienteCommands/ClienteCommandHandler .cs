using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FluentValidation.Results;
using GenericPack.Messaging;
using MediatR;

namespace FastFoodFIAP.Domain.Commands.ClienteCommands
{
    public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<ClienteCreateCommand, CommandResult>
    {

        private readonly IClienteRepository _repository;
        public ClienteCommandHandler(IMediator mediator, IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(ClienteCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;            
            
            var cliente = new Cliente(Guid.NewGuid(), request.Nome, request.Email, request.Cpf);            
            
            _repository.CadastrarNovoCliente(cliente);            

            return await Commit(_repository.UnitOfWork, cliente.Id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}