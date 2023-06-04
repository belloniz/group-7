using AutoMapper;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Models;

namespace FastFoodFIAP.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            AllowNullCollections = true;  
            
            CreateMap<CategoriaProduto, CategoriaProdutoViewModel>();
        }
        
    }
}