using AutoMapper;
using FluentValidation.Results;
using LivroDeReceitas.Domain.DTOs.Usuarios;
using LivroDeReceitas.Domain.Entities;
using LivroDeReceitas.Domain.Exceptions;
using LivroDeReceitas.Domain.Interfaces.Data;
using LivroDeReceitas.Domain.Interfaces.Services;
using LivroDeReceitas.Infrastructure.Services.Usuarios;
using LivroDeReceitas.Infrastructure.Validators.Usuarios;

namespace LivroDeReceitas.Api.Services.Usuarios;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioData _usuarioData;
    private readonly IMapper _mapper;
    private readonly PasswordEncryptor _passwordEncryptor;
    private readonly TokenService _tokenService;

    public UsuarioService(IUsuarioData usuarioData, IMapper mapper, PasswordEncryptor passwordEncryptor, TokenService tokenService)
    {
        _usuarioData = usuarioData;
        _mapper = mapper;
        _passwordEncryptor = passwordEncryptor;
        _tokenService = tokenService;
    }

    public async Task<CreateUsuarioResponse> CreateUsuarioAsync(CreateUsuarioRequest createUsuarioRequest)
    {
        await Validate(createUsuarioRequest);

        Usuario usuarioEntity = _mapper.Map<Usuario>(createUsuarioRequest);
        usuarioEntity.Senha = _passwordEncryptor.Encrypt(createUsuarioRequest.Senha);
        await _usuarioData.CreateAsync(usuarioEntity);

        var token = _tokenService.GenerateToken(usuarioEntity.Email);

        return new CreateUsuarioResponse
        {
            Token = token
        };
    }

    public async Task Validate(CreateUsuarioRequest usuarioRequest)
    {
        var validator = new UsuarioValidatorRequest();
        var result = validator.Validate(usuarioRequest);

        var existsByEmail = await _usuarioData.ExistsByEmail(usuarioRequest.Email);
        if (existsByEmail)
        {
            result.Errors.Add(new ValidationFailure("Email", "O e-mail informado já está cadastrado"));
        }

        if (!result.IsValid)
        {
            var messageErrors = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidatorErrors(messageErrors);
        }
    }
}
