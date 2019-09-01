using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SV.CQRS.Api.Persistence;
using SV.CQRS.Domain;

namespace SV.CQRS.Api.Features.TodoItems.GetTodoItems
{
    public class Handler : IRequestHandler<QueryRequest, IActionResult>
    {
        private readonly IRepository db;
        private readonly IMapper mapper;

        public Handler(IRepository db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Handle(QueryRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<TodoItem> todoItems;

            if (request.IncludeDeleted ?? false)
            {
                todoItems = await this.db.GetItemsAsync<TodoItem>().ConfigureAwait(false);
            }
            else
            {
                todoItems = await this.db.GetItemsAsync<TodoItem>(x => x.IsDeleted == request.IncludeDeleted.Value).ConfigureAwait(false);
            }

            var todoItemsDto = this.mapper.Map<IList<TodoItemModel>>(todoItems);

            return new OkObjectResult(todoItemsDto);
        }
    }
}