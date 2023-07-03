using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Interfaces;
using FluentValidation.Results;
using GenericPack.Mediator;

namespace FastFoodFIAP.Application.Services
{
    public class FuncionarioApp : IFuncionarioApp
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public FuncionarioApp(IFuncionarioRepository funcionarioRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mediator = mediator;
            _mapper = mapper;
        }        

        public async Task<List<FuncionarioViewModel>> GetAll()
        {
            return _mapper.Map<List<FuncionarioViewModel>>(await _funcionarioRepository.GetAll());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}