
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IFuncionarioApp : IDisposable
    {
        Task<List<FuncionarioViewModel>> GetAll();
    }
}