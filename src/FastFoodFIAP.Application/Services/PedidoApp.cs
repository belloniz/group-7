using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Commands.PedidoCommands;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using FastFoodFIAP.Domain.Models;
using FluentValidation.Results;
using GenericPack.Mediator;
using GenericPack.Messaging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Drawing;
using System;

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

        public async Task<CommandResult> Add(PedidoInputModel model)
        {
            var command = _mapper.Map<PedidoCreateCommand>(model);
            return await _mediator.SendCommand(command);
        }

        public async Task<CommandResult> Update(Guid id, PedidoInputModel model)
        {
            var command = _mapper.Map<PedidoUpdateCommand>(model);
            command.SetId(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<CommandResult> Remove(Guid id)
        {
            var command = new PedidoDeleteCommand(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<List<PedidoViewModel>> GetAll()
        {
            return _mapper.Map<List<PedidoViewModel>>(await _pedidoRepository.GetAll());
        }

        public async Task<List<PedidoViewModel>> GetAllAtivos()
        {
            return _mapper.Map<List<PedidoViewModel>>(await _pedidoRepository.GetAllAtivos());            
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

        public bool PagamentoAprovado(Guid id)
        {
            return _pedidoRepository.PagamentoAprovado(id);
        }
    }
}
