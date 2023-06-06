using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using FluentValidation.Results;
using GenericPack.Messaging;
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

        public async Task<ValidationResult> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;            

            var produto = new Produto(request.Id,request.Nome,request.Descricao, request.Preco, request.CategoriaId);            
            
            //produto.AddDomainEvent(new ProdutoCreateEvent(produto.Id, ....));

            _repository.Add(produto);            

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var produtoExiste = _repository.GetById(request.Id);
            if (produtoExiste is null)
            {
                AddError("O Produto não existe.");
                return ValidationResult;
            }                 

            var produto = new Produto(request.Id, request.Nome,request.Descricao, request.Preco, request.CategoriaId);                    

            //produto.AddDomainEvent(new ProdutoCreateEvent(produto.Id, ....));

            _repository.Update(produto);            

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ProdutoDeleteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var produtoExiste = _repository.GetById(request.Id);
            if (produtoExiste is null)
            {
                AddError("O Produto não existe.");
                return ValidationResult;
            }    

            var produto = new Produto(request.Id, request.Nome,request.Descricao, request.Preco, request.CategoriaId);                       

            //produto.AddDomainEvent(new ProdutoCreateEvent(produto.Id, ....));

            _repository.Remove(produto);            

            return await Commit(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}