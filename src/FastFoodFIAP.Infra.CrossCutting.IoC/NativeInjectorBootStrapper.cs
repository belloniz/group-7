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
using FastFoodFIAP.Domain.Commands.PedidoCommands;
using FastFoodFIAP.Domain.Commands.AndamentoCommands;
using GenericPack.Domain;
using FastFoodFIAP.Domain.Events.AndamentoEvents;
using FastFoodFIAP.Domain.Events.PagamentoEvents;

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
            services.AddScoped<IAndamentoApp, AndamentoApp>();
            services.AddScoped<ICategoriaProdutoApp, CategoriaProdutoApp>();
            services.AddScoped<IProdutoApp, ProdutoApp>();
            services.AddScoped<IClienteApp, ClienteApp>();
            services.AddScoped<IPedidoApp, PedidoApp>();
            services.AddScoped<IFuncionarioApp, FuncionarioApp>();
            services.AddScoped<ISituacaoPedidoApp, SituacaoPedidoApp>();

            // Infra - Data           
            services.AddScoped<IAndamentoRepository, AndamentoRepository>();
            services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IOcupacaoRepository, OcupacaoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<ISituacaoPedidoRepository, SituacaoPedidoRepository>();

            services.AddScoped<AppDbContext>();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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

            services.AddScoped<IRequestHandler<PedidoCreateCommand, ValidationResult>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<PedidoUpdateCommand, ValidationResult>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<PedidoDeleteCommand, ValidationResult>, PedidoCommandHandler>();

            services.AddScoped<IRequestHandler<AndamentoCreateCommand, ValidationResult>, AndamentoCommandHandler>();
            services.AddScoped<IRequestHandler<AndamentoUpdateCommand, ValidationResult>, AndamentoCommandHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<AndamentoCreateEvent>, AndamentoEventHandler>();            
            services.AddScoped<INotificationHandler<PagamentoCreateEvent>, PagamentoEventHandler>();            
        }
    }
}
