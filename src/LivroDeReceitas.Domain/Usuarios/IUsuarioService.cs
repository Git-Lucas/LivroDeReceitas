using LivroDeReceitas.Domain.Usuarios.DTOs.Usuarios;

namespace LivroDeReceitas.Domain.Usuarios;

public interface IUsuarioService
{
    Task<CreateUsuarioResponse> CreateUsuarioAsync(CreateUsuarioRequest usuarioRequest);
}
