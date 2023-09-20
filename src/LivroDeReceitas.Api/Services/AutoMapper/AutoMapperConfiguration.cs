using AutoMapper;
using LivroDeReceitas.Api.DTOs.Usuarios;
using LivroDeReceitas.Domain.Models;

namespace LivroDeReceitas.Api.Services.AutoMapper
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
