namespace LivroDeReceitas.Domain.Interfaces.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
