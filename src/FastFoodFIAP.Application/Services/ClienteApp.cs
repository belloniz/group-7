using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Commands.ClienteCommands;
using FastFoodFIAP.Domain.Interfaces;
using FluentValidation.Results;
using GenericPack.Mediator;

namespace FastFoodFIAP.Application.Services
{
    public class ClienteApp : IClienteApp
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ClienteApp(IClienteRepository clienteRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ValidationResult> CadastrarNovoCliente(ClienteInputModel model)
        {
            var command = _mapper.Map<ClienteCreateCommand>(model);
            return await _mediator.SendCommand(command);
        }
        public async Task<ClienteViewModel> BuscarClientePorCpf(string cpf)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.BuscarClientePorCpf(cpf));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}