using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands;
using FastFoodFIAP.Domain.Commands.ProdutoCommands;
using FastFoodFIAP.Domain.Models;

namespace FastFoodFIAP.Application.AutoMapper
{
    public class InputModelToDomainMappingProfile:Profile
    {
        public InputModelToDomainMappingProfile()
        {            
            AllowNullCollections = true;  
            
            //CategoriaProduto
            CreateMap<CategoriaProdutoInputModel, CategoriaProdutoCreateCommand>();
            CreateMap<CategoriaProdutoInputModel, CategoriaProdutoUpdateCommand>();

            //Produto
            CreateMap<ProdutoInputModel, ProdutoCreateCommand>();
            CreateMap<ProdutoInputModel, ProdutoUpdateCommand>();                    
            
        }
    }
}