using AutoMapper;
using LivroDeReceitas.Domain.DTOs.Usuarios;
using LivroDeReceitas.Domain.Entities;

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
