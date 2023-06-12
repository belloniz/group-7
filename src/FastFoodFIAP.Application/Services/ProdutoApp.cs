using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Commands.ProdutoCommands;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FluentValidation.Results;
using GenericPack.Mediator;

namespace FastFoodFIAP.Application.Services
{
    public class ProdutoApp : IProdutoApp
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ProdutoApp(IProdutoRepository produtoRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Add(ProdutoInputModel model)
        {
            var command = _mapper.Map<ProdutoCreateCommand>(model);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Update(int id, ProdutoInputModel model)
        {
            var command = _mapper.Map<ProdutoUpdateCommand>(model);
            command.SetId(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var command = new ProdutoDeleteCommand(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<List<ProdutoViewModel>> GetAll()
        {           
            return _mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.GetAll());
        }

        public async Task<ProdutoViewModel> GetById(int id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.GetById(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}