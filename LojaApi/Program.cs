using LojaApi.Application;
using LojaApi.Domain.Interfaces;
using LojaApi.Infraestructure.Context;
using LojaApi.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
     c =>
     {
         c.EnableAnnotations();
         c.SwaggerDoc("v1", new OpenApiInfo
         {
             Title = "Swagger Documentação Web API",
             Description = "Documentação da API",
             Contact = new OpenApiContact() { Name = "Rodrigo Brandão de Souza", Email = "rodrigotoo58@gmail.com" },
             License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
         });
         c.ResolveConflictingActions(x => x.First());
     }
);

builder.Services.AddMediatR( cfg => 
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(IoC).Assembly);
});

builder.Services.AddDbContext<LojaApiDbContext>(options =>
    options.UseInMemoryDatabase("LojaApiOnMemory"));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
