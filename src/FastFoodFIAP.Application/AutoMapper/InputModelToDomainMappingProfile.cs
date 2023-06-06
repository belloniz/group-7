using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Domain.Commands.ProdutoCommands;
using FastFoodFIAP.Domain.Models;

namespace FastFoodFIAP.Application.AutoMapper
{
    public class InputModelToDomainMappingProfile:Profile
    {
        public InputModelToDomainMappingProfile()
        {            
            AllowNullCollections = true;  
            
            CreateMap<CategoriaProdutoInputModel, CategoriaProduto>();

            //Produto
            CreateMap<ProdutoInputModel, ProdutoCreateCommand>();
            CreateMap<ProdutoInputModel, ProdutoUpdateCommand>();
            
        }
    }
}