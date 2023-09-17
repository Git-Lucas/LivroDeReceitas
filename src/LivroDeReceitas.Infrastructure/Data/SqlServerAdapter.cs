using LivroDeReceitas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LivroDeReceitas.Infrastructure.Data;

public class SqlServerAdapter : DbContext
{
    public IConfigurationRoot Config { get; }

    public SqlServerAdapter()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        Config = builder.Build();
    }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.GetConnectionString("DefaultConnection"));
    }
}