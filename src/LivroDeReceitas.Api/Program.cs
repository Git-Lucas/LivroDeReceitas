using AutoMapper;
using LivroDeReceitas.Api.Exceptions;
using LivroDeReceitas.Api.Services.AutoMapper;
using LivroDeReceitas.Api.Services.Usuarios;
using LivroDeReceitas.Domain.Interfaces.Data;
using LivroDeReceitas.Infrastructure.Data;
using LivroDeReceitas.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<EfSqlServerAdapter>();
builder.Services.AddScoped<IUsuarioData, UsuarioDataSqlServer>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped(x => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfiguration());
}).CreateMapper());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

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
