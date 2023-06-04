using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Domain.Models;

namespace FastFoodFIAP.Application.AutoMapper
{
    public class InputModelToDomainMappingProfile:Profile
    {
        public InputModelToDomainMappingProfile()
        {            
            AllowNullCollections = true;  
            
            CreateMap<CategoriaProdutoInputModel, CategoriaProduto>();
            
        }
    }
}