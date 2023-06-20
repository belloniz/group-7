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
using FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands;
using FastFoodFIAP.Domain.Commands.ClienteCommands;
using FastFoodFIAP.Infra.Data.Context;

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
            services.AddScoped<IClienteApp, ClienteApp>();

            // Infra - Data           
            services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddTransient<AppDbContext>();

            // AutoMapper Settings
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(InputModelToDomainMappingProfile));

            // Domain - Commands
            services.AddScoped<IRequestHandler<CategoriaProdutoCreateCommand, ValidationResult>, CategoriaProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<CategoriaProdutoUpdateCommand, ValidationResult>, CategoriaProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<CategoriaProdutoDeleteCommand, ValidationResult>, CategoriaProdutoCommandHandler>();

            services.AddScoped<IRequestHandler<ProdutoCreateCommand, ValidationResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<ProdutoUpdateCommand, ValidationResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<ProdutoDeleteCommand, ValidationResult>, ProdutoCommandHandler>();

            services.AddScoped<IRequestHandler<ClienteCreateCommand, ValidationResult>, ClienteCommandHandler>();
        }
    }
}