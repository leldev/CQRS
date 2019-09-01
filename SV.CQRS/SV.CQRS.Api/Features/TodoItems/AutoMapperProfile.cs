using AutoMapper;
using SV.CQRS.Domain;

namespace SV.CQRS.Api.Features.TodoItems
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<TodoItem, TodoItemModel>().ReverseMap();
            this.CreateMap<TodoItem, AddTodoItem.CommandRequest>().ReverseMap();
        }
    }
}