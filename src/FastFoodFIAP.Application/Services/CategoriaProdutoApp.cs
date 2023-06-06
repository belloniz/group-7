using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;

namespace FastFoodFIAP.Application.Services
{
    public class CategoriaProdutoApp : ICategoriaProdutoApp
    {

        private readonly ICategoriaProdutoRepository _categoriaRepository;
        private readonly IMapper _mapper;

        
        public CategoriaProdutoApp(ICategoriaProdutoRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public CategoriaProdutoViewModel Add(CategoriaProdutoInputModel model)
        {
            var categoria = _mapper.Map<CategoriaProduto>(model);
            _categoriaRepository.Add(categoria);
            _categoriaRepository.UnitOfWork.Commit();

            return _mapper.Map<CategoriaProdutoViewModel>(categoria);
        }

       public bool Update(int id, CategoriaProdutoInputModel model)
        {
            var categoria = _categoriaRepository.GetById(id);

            if (categoria is null)
                return false;

            categoria = _mapper.Map<CategoriaProduto>(model);                
            _categoriaRepository.Update(categoria);
            _categoriaRepository.UnitOfWork.Commit();

            return true;                    
        }

        public bool Remove(int id)
        {
            var categoria = _categoriaRepository.GetById(id);

            if (categoria is null)
                return false;

            _categoriaRepository.Remove(categoria);
            _categoriaRepository.UnitOfWork.Commit();
            return true;            
        }

        public CategoriaProdutoViewModel GetById(int id)
        {
            return _mapper.Map<CategoriaProdutoViewModel>(_categoriaRepository.GetById(id));
        }

        public List<CategoriaProdutoViewModel> GetAll()
        {
            return _mapper.Map<List<CategoriaProdutoViewModel>>(_categoriaRepository.GetAll());        
        }

         public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}