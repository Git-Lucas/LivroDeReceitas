using AutoMapper;
using FluentValidation.Results;
using LivroDeReceitas.Domain.Exceptions;
using LivroDeReceitas.Domain.Login;
using LivroDeReceitas.Domain.Usuarios;
using LivroDeReceitas.Domain.Usuarios.DTOs;
using LivroDeReceitas.Infrastructure.Validators.Usuarios;

namespace LivroDeReceitas.Api.Services.Usuarios;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioData _usuarioData;
    private readonly IMapper _mapper;
    private readonly IPasswordEncryptor _passwordEncryptor;
    private readonly ITokenService _tokenService;

    public UsuarioService(IUsuarioData usuarioData, IMapper mapper, IPasswordEncryptor passwordEncryptor, ITokenService tokenService)
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
