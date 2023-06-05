using FastFoodFIAP.Domain.Interfaces;
using GenericPack.Messaging;
using FluentValidation.Results;
using MediatR;

namespace FastFoodFIAP.Domain.Commands.ProdutoCommands
{
    public class ProdutoCommandHandler : CommandHandler,
        IRequestHandler<ProdutoCreateCommand, ValidationResult>,
        IRequestHandler<ProdutoUpdateCommand, ValidationResult>,
        IRequestHandler<ProdutoDeleteCommand, ValidationResult>
    {

        private readonly IProdutoRepository _repository;
        public ProdutoCommandHandler(IMediator mediator, IProdutoRepository repository)
        {
            _repository = repository;
        }

        public Task<ValidationResult> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Handle(ProdutoDeleteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}