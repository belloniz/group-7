using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands;
using FastFoodFIAP.Domain.Commands.PedidoCommands;
using FastFoodFIAP.Domain.Commands.ProdutoCommands;
using FastFoodFIAP.Domain.Commands.PagamentoCommands;
using FastFoodFIAP.Domain.Commands;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Commands.ClienteCommands;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using FastFoodFIAP.Domain.Commands.AndamentoCommands;

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

            CreateMap<PedidoComboInputModel, PedidoCombo>();
            CreateMap<PedidoComboProdutoInputModel, PedidoComboProduto>();

            CreateMap<AndamentoInputModel, AndamentoCreateCommand>();
            CreateMap<AndamentoInputModel, AndamentoUpdateCommand>();

            CreateMap<PagamentoInputModel, AndamentoCreateCommand>();
            
        }
    }
}