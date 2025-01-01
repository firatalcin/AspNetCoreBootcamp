using MarketService.Data.Contexts;
using MarketService.Data.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq();
});

builder.Services.AddDbContext<MarketContext>(opt =>
{
    opt.UseSqlServer("Server =(localdb)\\mssqllocaldb; Database=MarketDb; integrated security= true; ");
});
builder.Services.AddScoped<MarketRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
