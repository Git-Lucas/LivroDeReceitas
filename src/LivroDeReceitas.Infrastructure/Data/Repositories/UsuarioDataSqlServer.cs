using LivroDeReceitas.Domain.Interfaces.Data;
using LivroDeReceitas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceitas.Infrastructure.Data.Repositories;

public class UsuarioDataSqlServer : IUsuarioData
{
    private readonly EfSqlServerAdapter _context;
    private readonly IUnitOfWork _unitOfWork;

    public UsuarioDataSqlServer(EfSqlServerAdapter context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> ExistsByEmail(string email)
    {
        return await _context.Usuarios.AnyAsync(x => x.Email.Equals(email));
    }
}
