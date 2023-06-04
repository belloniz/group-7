using FastFoodFIAP.Application.AutoMapper;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Infra.Data.Repository;
using GenericPack.Data;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoodFIAP.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
         public static void RegisterServices(IServiceCollection services)
         {
            
             // Application            
             services.AddScoped<ICategoriaProdutoApp, CategoriaProdutoApp>();

             // Infra - Data           
             services.AddTransient<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
                                      
             // AutoMapper Settings
             services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(InputModelToDomainMappingProfile));
             
         }
    }
}