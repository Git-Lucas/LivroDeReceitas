using LivroDeReceitas.Domain.Models;

namespace LivroDeReceitas.Domain.Interfaces.Data;

public interface IUsuarioData
{
    Task<bool> ExistsByEmail(string email);
    Task CreateAsync(Usuario usuario);
}
