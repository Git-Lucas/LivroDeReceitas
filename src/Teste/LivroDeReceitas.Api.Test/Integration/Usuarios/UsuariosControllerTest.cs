namespace LivroDeReceitas.Api.Test.Integration.Usuarios
{
    public class UsuariosControllerTest
    {
        [Fact]
        public async Task CreateUsuarioAsyncSuccess()
        {
            UsuariosController usuarioController = UsuariosControllerInstance();
            CreateUsuarioRequest createUsuarioRequest = CreateUsuarioRequestBuilder.Build();

            var result = await usuarioController.CreateUsuarioAsync(createUsuarioRequest);

            var okObjectResult = Assert.IsType<CreatedResult>(result);
            dynamic model = Assert.IsAssignableFrom<dynamic>(okObjectResult.Value);
            Assert.NotNull(model.GetType().GetProperty("Token").GetValue(model, null));
        }

        public UsuariosController UsuariosControllerInstance()
        {
            IUsuarioService usuarioService = UsuarioServiceBuilder.Instance();
            return new UsuariosController(usuarioService);
        }
    }
}
