using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Domain.Commands.AndamentoCommands;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FluentValidation.Results;
using GenericPack.Mediator;

namespace FastFoodFIAP.Application.Services
{
    public class AndamentoApp:IAndamentoApp
    {
        private readonly IAndamentoRepository _andamentoRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public AndamentoApp(IAndamentoRepository andamentoRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _andamentoRepository = andamentoRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Add(AndamentoInputModel model)
        {
            var command = _mapper.Map<AndamentoCreateCommand>(model);
            return await _mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Update(int id, AndamentoInputModel model)
        {
            var command = _mapper.Map<AndamentoUpdateCommand>(model);
            command.SetId(id);
            return await _mediator.SendCommand(command);
        }
    }
}
