using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SV.CQRS.Api.Features.TodoItems.AddTodoItem
{
    public class CommandRequest : IRequest<IActionResult>
    {
        /// <summary>
        /// Gets or Sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Name.
        /// </summary>
        public string Name { get; set; }
    }
}