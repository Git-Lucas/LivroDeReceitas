using AutoMapper;
using LivroDeReceitas.Api.Services.Usuarios;
using LivroDeReceitas.Domain.Usuarios;
using LivroDeReceitas.Infrastructure.Services.Usuarios;
using Util.Encryptor;
using Util.Mapper;
using Util.Repositories;
using Util.Token;

namespace Util.Services
{
    public class UsuarioServiceBuilder
    {
        public static IUsuarioService Instance(string email = "")
        {
            IUsuarioData usuarioData = UsuarioDataBuilder.Instance().ExistsByEmail(email).Build();
            IMapper mapper = MapperBuilder.Instance();
            PasswordEncryptor passwordEncryptor = PasswordEncryptorBuilder.Instance();
            TokenService tokenService = TokenServiceBuilder.Instance();

            return new UsuarioService(usuarioData, mapper, passwordEncryptor, tokenService);
        }
    }
}
