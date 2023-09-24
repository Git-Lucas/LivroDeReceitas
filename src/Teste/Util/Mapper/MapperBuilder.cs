using AutoMapper;
using LivroDeReceitas.Api.Services;

namespace Util.Mapper;

public class MapperBuilder
{
    public static IMapper Instance()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperConfiguration>();
        });

        return configuration.CreateMapper();
    }
}
