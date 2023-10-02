using AutoMapper;
using LivroDeReceitas.Api.Exceptions;
using LivroDeReceitas.Api.Services;
using LivroDeReceitas.Api.Services.Usuarios;
using LivroDeReceitas.Domain.Login;
using LivroDeReceitas.Domain.Usuarios;
using LivroDeReceitas.Infrastructure.Data;
using LivroDeReceitas.Infrastructure.Data.Repositories;
using LivroDeReceitas.Infrastructure.Mapper;
using LivroDeReceitas.Infrastructure.Services.Usuarios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddDbContext<EfSqlServerAdapter>();
builder.Services.AddScoped<IUsuarioData, UsuarioDataSqlServer>();
builder.Services.AddScoped<IPasswordEncryptor, PasswordEncryptor>();
builder.Services.AddScoped<ITokenService, TokenService>(option => 
    new TokenService(builder.Configuration.GetRequiredSection("Configurations:TokenKey").Value!));
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ILoginService, LoginService>();
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
