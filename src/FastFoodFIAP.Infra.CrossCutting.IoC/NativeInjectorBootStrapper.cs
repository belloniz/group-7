using FastFoodFIAP.Application.AutoMapper;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Domain.Commands.ProdutoCommands;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Infra.Data.Repository;
using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using GenericPack.Mediator;
using FastFoodFIAP.Infra.CrossCutting.Bus;
using System.Reflection;

namespace FastFoodFIAP.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
         public static void RegisterServices(IServiceCollection services)
         {
            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            
             // Application            
             services.AddScoped<ICategoriaProdutoApp, CategoriaProdutoApp>();
             services.AddScoped<IProdutoApp, ProdutoApp>();

             // Infra - Data           
             services.AddTransient<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
             services.AddTransient<IProdutoRepository, ProdutoRepository>();
                                      
             // AutoMapper Settings
             services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(InputModelToDomainMappingProfile));

             // Domain - Commands
            services.AddScoped<IRequestHandler<ProdutoCreateCommand, ValidationResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<ProdutoUpdateCommand, ValidationResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<ProdutoDeleteCommand, ValidationResult>, ProdutoCommandHandler>();
             
         }
    }
}