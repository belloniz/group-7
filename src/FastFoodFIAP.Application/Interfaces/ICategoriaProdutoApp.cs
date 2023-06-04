using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface ICategoriaProdutoApp: IDisposable
    {

        List<CategoriaProdutoViewModel> GetAll();
        CategoriaProdutoViewModel GetById(int id);
        CategoriaProdutoViewModel Add(CategoriaProdutoInputModel categoriaInputModel);
        bool Update(int id, CategoriaProdutoInputModel categoriaInputModel);
        bool Remove(int id);        
    }
}