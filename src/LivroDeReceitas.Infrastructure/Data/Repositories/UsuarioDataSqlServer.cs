using LivroDeReceitas.Domain.Interfaces.Data;
using LivroDeReceitas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceitas.Infrastructure.Data.Repositories;

public class UsuarioDataSqlServer : IUsuarioData
{
    private readonly EfSqlServerAdapter _context;

    public UsuarioDataSqlServer(EfSqlServerAdapter context)
    {
        _context = context;
    }

    public async Task CreateAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
    }

    public async Task<bool> ExistsByEmail(string email)
    {
        return await _context.Usuarios.AnyAsync(x => x.Email.Equals(email));
    }
}
