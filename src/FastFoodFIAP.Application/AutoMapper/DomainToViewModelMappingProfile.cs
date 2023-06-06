using AutoMapper;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;

namespace FastFoodFIAP.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            AllowNullCollections = true;  
            
            CreateMap<CategoriaProduto, CategoriaProdutoViewModel>();

            //Produto
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
        }
        
    }
}