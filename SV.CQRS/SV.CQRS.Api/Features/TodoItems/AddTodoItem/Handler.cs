using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SV.CQRS.Api.Persistence;
using SV.CQRS.Domain;

namespace SV.CQRS.Api.Features.TodoItems.AddTodoItem
{
    public class Handler : IRequestHandler<CommandRequest, IActionResult>
    {
        private readonly IRepository db;
        private readonly IMapper mapper;

        public Handler(IRepository db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Handle(CommandRequest request, CancellationToken cancellationToken)
        {
            var todoItem = this.mapper.Map<TodoItem>(request);
            var item = await this.db.CreateItemAsync(todoItem).ConfigureAwait(false);
            var todoItemDto = this.mapper.Map<TodoItemModel>(item);

            return new CreatedAtRouteResult("GetTodoItem", new { todoItemDto.Id }, todoItemDto);
        }
    }
}
