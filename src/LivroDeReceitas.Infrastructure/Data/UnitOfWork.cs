using LivroDeReceitas.Domain.Interfaces.Data;

namespace LivroDeReceitas.Infrastructure.Data;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly EfSqlServerAdapter _context;

    public UnitOfWork(EfSqlServerAdapter context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
