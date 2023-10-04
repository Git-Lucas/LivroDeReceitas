namespace LivroDeReceitas.Api.Test.Unit.Usuarios;

public class UsuarioValidatorRequestTest
{
    [Fact]
    public async Task ValidateSucces()
    {
        UsuarioValidatorRequest usuarioValidatorRequest = UsuarioValidatorRequestBuilder.Instance();
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();

        var result = await usuarioValidatorRequest.ValidateAsync(createUsuarioRequest);

        Assert.True(result.IsValid);
    }

    [Fact]
    public async Task ValidateEmptyName()
    {
        UsuarioValidatorRequest usuarioValidatorRequest = UsuarioValidatorRequestBuilder.Instance();
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();
        createUsuarioRequest.Nome = string.Empty;

        var result = await usuarioValidatorRequest.ValidateAsync(createUsuarioRequest);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal($"O campo '{nameof(createUsuarioRequest.Nome)}' é obrigatório", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public async Task ValidateEmptyEmail()
    {
        UsuarioValidatorRequest usuarioValidatorRequest = UsuarioValidatorRequestBuilder.Instance();
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();
        createUsuarioRequest.Email = string.Empty;

        var result = await usuarioValidatorRequest.ValidateAsync(createUsuarioRequest);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal($"O campo '{nameof(createUsuarioRequest.Email)}' é obrigatório", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public async Task ValidateEmptySenha()
    {
        UsuarioValidatorRequest usuarioValidatorRequest = UsuarioValidatorRequestBuilder.Instance();
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();
        createUsuarioRequest.Senha = string.Empty;

        var result = await usuarioValidatorRequest.ValidateAsync(createUsuarioRequest);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal($"O campo '{nameof(createUsuarioRequest.Senha)}' é obrigatório", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public async Task ValidateEmptyTelefone()
    {
        UsuarioValidatorRequest usuarioValidatorRequest = UsuarioValidatorRequestBuilder.Instance();
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();
        createUsuarioRequest.Telefone = string.Empty;

        var result = await usuarioValidatorRequest.ValidateAsync(createUsuarioRequest);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal($"O campo '{nameof(createUsuarioRequest.Telefone)}' é obrigatório", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public async Task ValidateInvalidEmail()
    {
        UsuarioValidatorRequest usuarioValidatorRequest = UsuarioValidatorRequestBuilder.Instance();
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();
        createUsuarioRequest.Email = "lucasgmail.com";

        var result = await usuarioValidatorRequest.ValidateAsync(createUsuarioRequest);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("E-mail inválido", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public async Task ValidateExistingEmail()
    {
        CreateUsuarioRequest request = CreateUsuarioRequestBuilder.Build();
        UsuarioValidatorRequest usuarioValidatorRequest = UsuarioValidatorRequestBuilder.Instance(request.Email);

        var result = await usuarioValidatorRequest.ValidateAsync(request);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("O e-mail informado já está cadastrado", result.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task ValidateInvalidSenha(int lengthSenha)
    {
        UsuarioValidatorRequest usuarioValidatorRequest = UsuarioValidatorRequestBuilder.Instance();
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build(lengthSenha);

        var result = await usuarioValidatorRequest.ValidateAsync(createUsuarioRequest);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("A senha deve ter no mínimo 6 caracteres", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public async Task ValidateInvalidTelefone()
    {
        UsuarioValidatorRequest usuarioValidatorRequest = UsuarioValidatorRequestBuilder.Instance();
        CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();
        createUsuarioRequest.Telefone = "31 9 0199-1298";

        var result = await usuarioValidatorRequest.ValidateAsync(createUsuarioRequest);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("Telefone inválido", result.Errors.First().ErrorMessage);
    }
}
