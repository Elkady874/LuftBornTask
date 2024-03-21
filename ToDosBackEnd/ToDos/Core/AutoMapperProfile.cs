using AutoMapper;
using ToDos.DTOs;
using ToDos.Entities;

namespace ToDos.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ToDoItemEntity,ToDo>()
                .ReverseMap();

            CreateMap<ToDoItemEntity, NewTodo>()
              .ReverseMap();
        }
    }
}
