using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using FluentValidation.Results;
using GenericPack.Messaging;
using MediatR;

namespace FastFoodFIAP.Domain.Commands.ProdutoCommands
{
    public class ProdutoCommandHandler : CommandHandler,
        IRequestHandler<ProdutoCreateCommand, CommandResult>,
        IRequestHandler<ProdutoUpdateCommand, CommandResult>,
        IRequestHandler<ProdutoDeleteCommand, CommandResult>
    {

        private readonly IProdutoRepository _repository;
        public ProdutoCommandHandler(IMediator mediator, IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;            

            var produto = new Produto(Guid.NewGuid(),request.Nome,request.Descricao, request.Preco, request.CategoriaId);            
            
            foreach (var url in request.ImagensUrl)
                produto.AddImagem(url);

            _repository.Add(produto);            

            return await Commit(_repository.UnitOfWork,produto.Id);
        }

        public async Task<CommandResult> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var produtoExiste = await _repository.GetById(request.Id);
            if (produtoExiste is null)
            {
                AddError("O Produto não existe.");
                return CommandResult;
            }

            var produto = new Produto(request.Id, request.Nome, request.Descricao, request.Preco, request.CategoriaId);

            foreach (var url in request.ImagensUrl)
                produto.AddImagem(url);

            _repository.Update(produto);            

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<CommandResult> Handle(ProdutoDeleteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var produtoExiste = await _repository.GetById(request.Id);
            if (produtoExiste is null)
            {
                AddError("O Produto não existe.");
                return CommandResult;
            }                        

            _repository.Remove(produtoExiste);            

            return await Commit(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}