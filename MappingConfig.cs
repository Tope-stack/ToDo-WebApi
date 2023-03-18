using AutoMapper;
using ToDo.Models;
using ToDo.Models.Dtos;

namespace ToDo
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TodoDto, Todo>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
