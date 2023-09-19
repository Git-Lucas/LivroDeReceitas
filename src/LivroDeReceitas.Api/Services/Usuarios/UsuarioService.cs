using LivroDeReceitas.Api.DTOs.Usuarios;
using LivroDeReceitas.Api.Validators.Usuarios;
using LivroDeReceitas.Domain.Interfaces.Data;

namespace LivroDeReceitas.Api.Services.Usuarios;

public class UsuarioService : BaseService
{
    public UsuarioService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task CreateUsuarioAsync(CreateUsuarioRequest usuarioRequest)
    {
        var validator = new UsuarioValidatorRequest();
        var result = validator.Validate(usuarioRequest);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage);
        }
    }
}
