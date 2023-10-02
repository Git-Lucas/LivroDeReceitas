using AutoMapper;
using LivroDeReceitas.Domain.Usuarios;
using LivroDeReceitas.Domain.Usuarios.DTOs;

namespace LivroDeReceitas.Infrastructure.Mapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CreateUsuarioRequest, Usuario>()
                .ForMember(usuario => usuario.Senha, config => config.Ignore());
        }
    }
}
