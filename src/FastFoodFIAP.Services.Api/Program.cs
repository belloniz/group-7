using System.Reflection;
using System.Text.Json.Serialization;
using FastFoodFIAP.Services.Api.Configurations;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s => {
    s.EnableAnnotations();
});

// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
// if (app.Environment.IsDevelopment())
//     app.UseSwaggerUI(c =>{
//         c.SwaggerEndpoint("/swagger/v1/swagger.json", "FastFoodAPI");
//         c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
//     });
// else
//     app.UseSwaggerUI(c => {
//         c.RoutePrefix = "/swagger/index.html";
//     }); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
