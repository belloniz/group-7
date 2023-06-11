using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FluentValidation.Results;
using GenericPack.Mediator;

namespace FastFoodFIAP.Application.Services
{
    public class CategoriaProdutoApp : ICategoriaProdutoApp
    {
        private readonly ICategoriaProdutoRepository _categoriaRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public CategoriaProdutoApp(ICategoriaProdutoRepository categoriaRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Add(CategoriaProdutoInputModel model)
        {
            var command = _mapper.Map<CategoriaProdutoCreateCommand>(model);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Update(int id, CategoriaProdutoInputModel model)
        {
            var command = _mapper.Map<CategoriaProdutoUpdateCommand>(model);
            command.SetId(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Remove(int id)
        {
            var command = new CategoriaProdutoDeleteCommand(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<CategoriaProdutoViewModel> GetById(int id)
        {
            return _mapper.Map<CategoriaProdutoViewModel>(await _categoriaRepository.GetById(id));
        }

        public async Task<IEnumerable<CategoriaProdutoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoriaProdutoViewModel>>(await _categoriaRepository.GetAll());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}