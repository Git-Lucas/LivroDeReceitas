using LivroDeReceitas.Api.DTOs.Usuarios;
using LivroDeReceitas.Api.Exceptions;
using LivroDeReceitas.Api.Validators.Usuarios;
using LivroDeReceitas.Domain.Interfaces.Data;

namespace LivroDeReceitas.Api.Services.Usuarios;

public class UsuarioService
{
    public UsuarioService()
    {
    }

    public async Task CreateUsuarioAsync(CreateUsuarioRequest usuarioRequest)
    {
        var validator = new UsuarioValidatorRequest();
        var result = validator.Validate(usuarioRequest);

        if (!result.IsValid)
        {
            var messageErrors = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidatorErrors(messageErrors);
        }
    }
}
