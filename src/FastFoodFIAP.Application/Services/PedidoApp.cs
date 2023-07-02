using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Commands.PedidoCommands;
using FastFoodFIAP.Domain.Interfaces;
using FluentValidation.Results;
using GenericPack.Mediator;

namespace FastFoodFIAP.Application.Services
{
    public class PedidoApp : IPedidoApp
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;


        public PedidoApp(IPedidoRepository pedidoRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Add(PedidoInputModel model)
        {
            var command = _mapper.Map<PedidoCreateCommand>(model);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Update(Guid id, PedidoInputModel model)
        {
            var command = _mapper.Map<PedidoUpdateCommand>(model);
            command.SetId(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var command = new PedidoDeleteCommand(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<List<PedidoViewModel>> GetAll()
        {
            return _mapper.Map<List<PedidoViewModel>>(await _pedidoRepository.GetAll());
        }

        public async Task<List<PedidoViewModel>> GetAllBySituacao(int situacaoId)
        {
            return _mapper.Map<List<PedidoViewModel>>(await _pedidoRepository.GetAllBySituacao(situacaoId));
        }

        public async Task<PedidoViewModel> GetById(Guid id)
        {
            return _mapper.Map<PedidoViewModel>(await _pedidoRepository.GetById(id));
        }        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }        
    }
}
