using System.Data;
using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;

namespace FastFoodFIAP.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            AllowNullCollections = true;  
            
            CreateMap<CategoriaProduto, CategoriaProdutoViewModel>();

            CreateMap<Cliente, ClienteViewModel>();

            CreateMap<Imagem, ImagemViewModel>();

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(c => c.Categoria,
                    map => map.MapFrom(m => m.CategoriaNavegation));
            
            CreateMap<Pedido, PedidoViewModel>();
            CreateMap<PedidoCombo, PedidoItemViewModel>();
            CreateMap<PedidoComboProduto, ComboViewModel>();
        }
        
    }
}
