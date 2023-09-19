namespace LivroDeReceitas.Domain.Base;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}
