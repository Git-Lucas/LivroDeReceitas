namespace LivroDeReceitas.Api.Test.Unit.Validators.Usuarios;

public class UsuarioValidatorRequestTest
{
    [Fact]
    public void ValidateSucces()
    {
        var usuarioValidatorRequest = new UsuarioValidatorRequest();
        var request = CreateUsuarioRequestBuilder.Build();

        var result = usuarioValidatorRequest.Validate(request);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateEmptyName()
    {
        var usuarioValidatorRequest = new UsuarioValidatorRequest();
        var request = CreateUsuarioRequestBuilder.Build();
        request.Nome = string.Empty;

        var result = usuarioValidatorRequest.Validate(request);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("O campo 'Nome' é obrigatório", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public void ValidateEmptyEmail()
    {
        var usuarioValidatorRequest = new UsuarioValidatorRequest();
        var request = CreateUsuarioRequestBuilder.Build();
        request.Email = string.Empty;

        var result = usuarioValidatorRequest.Validate(request);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("O campo 'Email' é obrigatório", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public void ValidateEmptySenha()
    {
        var usuarioValidatorRequest = new UsuarioValidatorRequest();
        var request = CreateUsuarioRequestBuilder.Build();
        request.Senha = string.Empty;

        var result = usuarioValidatorRequest.Validate(request);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("O campo 'Senha' é obrigatório", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public void ValidateEmptyTelefone()
    {
        var usuarioValidatorRequest = new UsuarioValidatorRequest();
        var request = CreateUsuarioRequestBuilder.Build();
        request.Telefone = string.Empty;

        var result = usuarioValidatorRequest.Validate(request);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("O campo 'Telefone' é obrigatório", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public void ValidateInvalidEmail()
    {
        var usuarioValidatorRequest = new UsuarioValidatorRequest();
        var request = CreateUsuarioRequestBuilder.Build();
        request.Email = "lucasgmail.com";

        var result = usuarioValidatorRequest.Validate(request);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("E-mail inválido", result.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void ValidateInvalidSenha(int lengthSenha)
    {
        var usuarioValidatorRequest = new UsuarioValidatorRequest();
        var request = CreateUsuarioRequestBuilder.Build(lengthSenha);

        var result = usuarioValidatorRequest.Validate(request);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("A senha deve ter no mínimo 6 caracteres", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public void ValidateInvalidTelefone()
    {
        var usuarioValidatorRequest = new UsuarioValidatorRequest();
        var request = CreateUsuarioRequestBuilder.Build();
        request.Telefone = "31 9 0199-1298";

        var result = usuarioValidatorRequest.Validate(request);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Equal("Telefone inválido", result.Errors.First().ErrorMessage);
    }
}
