using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SV.CQRS.Api.Features.TodoItems
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : Controller
    {
        private readonly IMediator mediator;

        public TodoItemsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TodoItemModel), 201)]
        public async Task<IActionResult> AddTodoItem([FromBody]AddTodoItem.CommandRequest command)
        {
            return await this.mediator.Send(command).ConfigureAwait(false);
        }

        [HttpPut("{id}/complete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CompleteTodoItem([FromRoute]CompleteTodoItem.CommandRequest command)
        {
            return await this.mediator.Send(command).ConfigureAwait(false);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTodoItem([FromRoute]DeleteTodoItem.CommandRequest command)
        {
            return await this.mediator.Send(command).ConfigureAwait(false);
        }

        [HttpGet("{id}", Name = "GetTodoItem")]
        [ProducesResponseType(typeof(TodoItemModel), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTodoItem([FromRoute]GetTodoItem.QueryRequest query)
        {
            return await this.mediator.Send(query).ConfigureAwait(false);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<TodoItemModel>), 200)]
        public async Task<IActionResult> GetTodoItems([FromQuery]GetTodoItems.QueryRequest query)
        {
            return await this.mediator.Send(query).ConfigureAwait(false);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTodoItem([FromRoute]UpdateItem.CommandRequest command)
        {
            return await this.mediator.Send(command).ConfigureAwait(false);
        }
    }
}