namespace LivroDeReceitas.Infrastructure.Data;

public sealed class UnitOfWork : IDisposable
{
    private readonly EfSqlServerAdapter _context;

    public UnitOfWork(EfSqlServerAdapter context)
    {
        _context = context;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
