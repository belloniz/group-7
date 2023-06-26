using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands;
using FastFoodFIAP.Domain.Commands.PedidoCommands;
using FastFoodFIAP.Domain.Commands.ProdutoCommands;
using FastFoodFIAP.Domain.Commands;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Commands.ClienteCommands;
using FastFoodFIAP.Domain.Models.PedidoAggregate;

namespace FastFoodFIAP.Application.AutoMapper
{
    public class InputModelToDomainMappingProfile:Profile
    {
        public InputModelToDomainMappingProfile()
        {            
            AllowNullCollections = true;

            //Cliente
            CreateMap<ClienteInputModel, ClienteCreateCommand>();
            
            //CategoriaProduto
            CreateMap<CategoriaProdutoInputModel, CategoriaProdutoCreateCommand>();
            CreateMap<CategoriaProdutoInputModel, CategoriaProdutoUpdateCommand>();

            //Produto
            CreateMap<ProdutoInputModel, ProdutoCreateCommand>();
            CreateMap<ProdutoInputModel, ProdutoUpdateCommand>(); 

            //Pedido
            CreateMap<PedidoInputModel, PedidoCreateCommand>();
            CreateMap<PedidoInputModel, PedidoUpdateCommand>();

            CreateMap<PedidoItemInputModel, PedidoCombo>();
            CreateMap<ComboInputModel, PedidoComboProduto>();
        }
    }
}