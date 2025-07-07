using AutoMapper;
using ToDoListAPI.Models;
using ToDoListAPI.Models.DTOs;

namespace ToDoListAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoTask, TaskResponse>().ReverseMap();
            CreateMap<CreateUpdateTaskDto, TodoTask>();
        }
    }
}
