using LivroDeReceitas.Domain.DTOs.Usuarios;

namespace LivroDeReceitas.Domain.Interfaces.Services;

public interface IUsuarioService
{
    Task<CreateUsuarioResponse> CreateUsuarioAsync(CreateUsuarioRequest usuarioRequest);
}
