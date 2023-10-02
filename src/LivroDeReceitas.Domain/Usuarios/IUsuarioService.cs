using LivroDeReceitas.Domain.Usuarios.DTOs;

namespace LivroDeReceitas.Domain.Usuarios;

public interface IUsuarioService
{
    Task<CreateUsuarioResponse> CreateUsuarioAsync(CreateUsuarioRequest usuarioRequest);
}
