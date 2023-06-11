using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FluentValidation.Results;
using GenericPack.Messaging;
using MediatR;

namespace FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands
{
    public class CategoriaProdutoCommandHandler : CommandHandler,
        IRequestHandler<CategoriaProdutoCreateCommand, ValidationResult>,
        IRequestHandler<CategoriaProdutoUpdateCommand, ValidationResult>,
        IRequestHandler<CategoriaProdutoDeleteCommand, ValidationResult>
    {

        private readonly ICategoriaProdutoRepository _repository;
        public CategoriaProdutoCommandHandler(IMediator mediator, ICategoriaProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> Handle(CategoriaProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var categoria = new CategoriaProduto(request.Id, request.Nome);

            _repository.Add(categoria);

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CategoriaProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var categoriaExiste = await _repository.GetById(request.Id);
            if (categoriaExiste is null)
            {
                AddError("A Categoria não existe.");
                return ValidationResult;
            }

            var categoria = new CategoriaProduto(request.Id, request.Nome);

            _repository.Update(categoria);

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CategoriaProdutoDeleteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var categoriaExiste = await _repository.GetById(request.Id);
            if (categoriaExiste is null)
            {
                AddError("A Categoria não existe.");
                return ValidationResult;
            }

            var categoria = new CategoriaProduto(request.Id, request.Nome);

            _repository.Remove(categoria);

            return await Commit(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}