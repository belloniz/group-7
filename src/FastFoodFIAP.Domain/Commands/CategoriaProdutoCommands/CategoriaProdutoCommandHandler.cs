using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FluentValidation.Results;
using GenericPack.Messaging;
using MediatR;

namespace FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands
{
    public class CategoriaProdutoCommandHandler : CommandHandler,
        IRequestHandler<CategoriaProdutoCreateCommand, CommandResult>,
        IRequestHandler<CategoriaProdutoUpdateCommand, CommandResult>,
        IRequestHandler<CategoriaProdutoDeleteCommand, CommandResult>
    {

        private readonly ICategoriaProdutoRepository _repository;
        public CategoriaProdutoCommandHandler(IMediator mediator, ICategoriaProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(CategoriaProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var categoria = new CategoriaProduto(Guid.NewGuid(), request.Nome);

            _repository.Add(categoria);

            return await Commit(_repository.UnitOfWork, categoria.Id);
        }

        public async Task<CommandResult> Handle(CategoriaProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var categoriaExiste = await _repository.GetById(request.Id);
            if (categoriaExiste is null)
            {
                AddError("A Categoria não existe.");
                return CommandResult;
            }

            var categoria = new CategoriaProduto(request.Id, request.Nome);

            _repository.Update(categoria);

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<CommandResult> Handle(CategoriaProdutoDeleteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var categoriaExiste = await _repository.GetById(request.Id);
            if (categoriaExiste is null)
            {
                AddError("A Categoria não existe.");
                return CommandResult;
            }

            _repository.Remove(categoriaExiste);

            return await Commit(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}