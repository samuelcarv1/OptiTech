using Microsoft.EntityFrameworkCore;
using OptiTech.API.Middlewares;
using OptiTech.Application.DTOs;
using OptiTech.Application.Interfaces.Repositories;
using OptiTech.Application.Interfaces.Services;
using OptiTech.Application.Mappings;
using OptiTech.Application.Services;
using OptiTech.Core.Entities;
using OptiTech.Core.Interfaces;
using OptiTech.Core.Services;
using OptiTech.Infrastructure.Data;
using OptiTech.Infrastructure.Messaging;
using OptiTech.Infrastructure.Messaging.Consumers;
using OptiTech.Infrastructure.Messaging.HostedServices;
using OptiTech.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryService, InventoryService>();

builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();

builder.Services.AddSingleton<InventoryUpdatedConsumer>();

builder.Services.AddScoped<IMapper<Product, ProductDto>, ProductMapper>();
builder.Services.AddScoped<IMapper<InventoryItem, InventoryItemDto>, InventoryMapper>();
builder.Services.AddHostedService<InventoryUpdatedConsumerHostedService>();

builder.Services.AddLogging();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
