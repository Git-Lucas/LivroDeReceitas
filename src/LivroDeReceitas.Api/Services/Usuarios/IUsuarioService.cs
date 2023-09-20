using LivroDeReceitas.Api.DTOs.Usuarios;

namespace LivroDeReceitas.Api.Services.Usuarios;

public interface IUsuarioService
{
    Task<CreateUsuarioResponse> CreateUsuarioAsync(CreateUsuarioRequest usuarioRequest);
}
