using LivroDeReceitas.Domain.Exceptions;
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

    public async Task<bool> ExistsByEmail(string email) =>
        await _context.Usuarios
            .AnyAsync(x => x.Email.Equals(email));

    public async Task<Usuario> GetByEmailESenhaAsync(string email, string senha)
    {
        var result = await _context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Senha.Equals(senha));

        if (result is null)
        {
            throw new InvalidLoginError("Usuário ou senha inválidos.");
        }

        return result;
    }
}
