using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface ICategoriaProdutoApp: IDisposable
    {

        List<CategoriaProdutoViewModel> GetAll();
        CategoriaProdutoViewModel GetById(int id);
        CategoriaProdutoViewModel Add(CategoriaProdutoInputModel model);
        bool Update(int id, CategoriaProdutoInputModel model);
        bool Remove(int id);        
    }
}