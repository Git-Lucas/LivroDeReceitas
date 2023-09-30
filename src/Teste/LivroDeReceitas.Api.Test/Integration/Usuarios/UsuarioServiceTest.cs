namespace LivroDeReceitas.Api.Test.Integration.Usuarios;

public class UsuarioServiceTest
{
    [Fact]
    public async Task CreateUsuarioAsyncSuccess()
    {
        IUsuarioService usuarioService = UsuarioServiceBuilder.Instance();
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();

        CreateUsuarioResponse createUsuarioResponse = await usuarioService.CreateUsuarioAsync(createUsuarioRequest);

        Assert.NotNull(createUsuarioResponse);
        Assert.NotNull(createUsuarioResponse.Token);
    }

    [Fact]
    public async Task CreateUsuarioAsyncEmailAlreadyExists()
    {
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();
        IUsuarioService usuarioService = UsuarioServiceBuilder.Instance(createUsuarioRequest.Email);

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
        IUsuarioService usuarioService = UsuarioServiceBuilder.Instance();

        Func<Task> action = async () => await usuarioService.CreateUsuarioAsync(createUsuarioRequest);

        ValidatorErrors validatorErrors = await Assert.ThrowsAsync<ValidatorErrors>(action);
        Assert.Single(validatorErrors.MessageErrors);
        Assert.Equal("O campo 'Nome' é obrigatório", validatorErrors.MessageErrors.First());
    }
}