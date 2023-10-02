namespace LivroDeReceitas.Domain.Usuarios;

public interface IUsuarioData
{
    Task<bool> ExistsByEmail(string email);
    Task CreateAsync(Usuario usuario);
    Task<Usuario> GetByEmailESenhaAsync(string email, string senha);
}
