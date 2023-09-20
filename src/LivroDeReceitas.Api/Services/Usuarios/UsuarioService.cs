using AutoMapper;
using LivroDeReceitas.Api.DTOs.Usuarios;
using LivroDeReceitas.Api.Exceptions;
using LivroDeReceitas.Api.Validators.Usuarios;
using LivroDeReceitas.Domain.Interfaces.Data;
using LivroDeReceitas.Domain.Models;

namespace LivroDeReceitas.Api.Services.Usuarios;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioData _usuarioData;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioData usuarioData, IMapper mapper)
    {
        _usuarioData = usuarioData;
        _mapper = mapper;
    }

    public async Task CreateUsuarioAsync(CreateUsuarioRequest usuarioRequest)
    {
        Validate(usuarioRequest);

        Usuario usuario = _mapper.Map<Usuario>(usuarioRequest);
        usuario.Senha = "cript";

        await _usuarioData.CreateAsync(usuario);
    }

    public void Validate(CreateUsuarioRequest usuarioRequest)
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
