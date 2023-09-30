using LivroDeReceitas.Domain.Usuarios;
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
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByEmail(string email)
    {
        return await _context.Usuarios.AnyAsync(x => x.Email.Equals(email));
    }
}
