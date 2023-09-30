using LivroDeReceitas.Domain.Usuarios;
using LivroDeReceitas.Domain.Usuarios.DTOs.Usuarios;

namespace LivroDeReceitas.Api.Test.Integration.Usuarios;

public class UsuarioServiceTest
{
    [Fact]
    public async Task CreateUsuarioAsyncSuccess()
    {
        UsuarioService usuarioService = BuildUsuarioService();
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();

        CreateUsuarioResponse createUsuarioResponse = await usuarioService.CreateUsuarioAsync(createUsuarioRequest);

        Assert.NotNull(createUsuarioResponse);
        Assert.NotNull(createUsuarioResponse.Token);
    }

    [Fact]
    public async Task CreateUsuarioAsyncEmailAlreadyExists()
    {
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();
        UsuarioService usuarioService = BuildUsuarioService(createUsuarioRequest.Email);

        Func<Task> action = async () => await usuarioService.CreateUsuarioAsync(createUsuarioRequest);

        ValidatorErrors validatorErrors = await Assert.ThrowsAsync<ValidatorErrors>(action);
        Assert.Single(validatorErrors.MessageErrors);
        Assert.Equal("O e-mail informado já está cadastrado", validatorErrors.MessageErrors.First());
    }

    [Fact]
    public async Task CreateUsuarioAsyncEmptyName()
    {
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();
        createUsuarioRequest.Nome = string.Empty;
        UsuarioService usuarioService = BuildUsuarioService();

        Func<Task> action = async () => await usuarioService.CreateUsuarioAsync(createUsuarioRequest);

        ValidatorErrors validatorErrors = await Assert.ThrowsAsync<ValidatorErrors>(action);
        Assert.Single(validatorErrors.MessageErrors);
        Assert.Equal("O campo 'Nome' é obrigatório", validatorErrors.MessageErrors.First());
    }

    public UsuarioService BuildUsuarioService(string email = "")
    {
        IUsuarioData usuarioData = UsuarioDataBuilder.Instance().ExistsByEmail(email).Build();
        IMapper mapper = MapperBuilder.Instance();
        PasswordEncryptor passwordEncryptor = PasswordEncryptorBuilder.Instance();
        TokenService tokenService = TokenServiceBuilder.Instance();

        return new UsuarioService(usuarioData, mapper, passwordEncryptor, tokenService);
    }
}