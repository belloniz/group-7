using FastFoodFIAP.Application.AutoMapper;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Domain.Commands.ProdutoCommands;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Infra.Data.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using GenericPack.Mediator;
using FastFoodFIAP.Infra.CrossCutting.Bus;
using System.Reflection;
using FastFoodFIAP.Domain.Commands.CategoriaProdutoCommands;
using FastFoodFIAP.Domain.Commands.ClienteCommands;
using FastFoodFIAP.Infra.Data.Context;
using FastFoodFIAP.Domain.Commands.PedidoCommands;
using FastFoodFIAP.Domain.Commands.AndamentoCommands;
using FastFoodFIAP.Domain.Commands.PagamentoCommands;
using FastFoodFIAP.Domain.Events.AndamentoEvents;
using FastFoodFIAP.Domain.Events.PagamentoEvents;
using FastFoodFIAP.Domain.Interfaces.Services;
using FastFoodFIAP.Infra.MercadoPago;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GenericPack.Messaging;
using System.Data;

namespace FastFoodFIAP.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Setting DBContexts
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Connectionstring")));

            services.AddScoped<AppDbContext>();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddScoped<IDbConnection, Npgsql.NpgsqlConnection>();

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
            services.AddScoped<IPagamentoApp, PagamentoApp>();
            services.AddScoped<IFuncionarioApp, FuncionarioApp>();
            services.AddScoped<ISituacaoPedidoApp, SituacaoPedidoApp>();
            services.AddScoped<IFuncionarioApp, FuncionarioApp>();
            services.AddScoped<ISituacaoPagamentoApp, SituacaoPagamentoApp>();

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
            services.AddScoped<ISituacaoPagamentoRepository, SituacaoPagamentoRepository>();

            // AutoMapper Settings
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(InputModelToDomainMappingProfile));

            // Domain - Commands
            services.AddScoped<IRequestHandler<CategoriaProdutoCreateCommand, CommandResult>, CategoriaProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<CategoriaProdutoUpdateCommand, CommandResult>, CategoriaProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<CategoriaProdutoDeleteCommand, CommandResult>, CategoriaProdutoCommandHandler>();

            services.AddScoped<IRequestHandler<ProdutoCreateCommand, CommandResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<ProdutoUpdateCommand, CommandResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<ProdutoDeleteCommand, CommandResult>, ProdutoCommandHandler>();

            services.AddScoped<IRequestHandler<ClienteCreateCommand, CommandResult>, ClienteCommandHandler>();

            services.AddScoped<IRequestHandler<PedidoCreateCommand, CommandResult>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<PedidoUpdateCommand, CommandResult>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<PedidoDeleteCommand, CommandResult>, PedidoCommandHandler>();

            services.AddScoped<IRequestHandler<AndamentoCreateCommand, CommandResult>, AndamentoCommandHandler>();
            services.AddScoped<IRequestHandler<AndamentoUpdateCommand, CommandResult>, AndamentoCommandHandler>();

            services.AddScoped<IRequestHandler<PagamentoUpdateCommand, CommandResult>, PagamentoCommandHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<AndamentoCreateEvent>, AndamentoEventHandler>();
            services.AddScoped<INotificationHandler<PagamentoCreateEvent>, PagamentoEventHandler>();

            //Infra - Services
            services.AddScoped<IGatewayPagamento, MercadoPagoService>();
            
            //Gateway de Pagamento
            services.AddHttpClient<IGatewayPagamento, MercadoPagoService>(
            client =>
            {
                // Set the base address of the named client.
                client.BaseAddress = new Uri("https://api.mercadopago.com/");
            });
        }
    }
}
