using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SV.CQRS.Api.Features.TodoItems.DeleteTodoItem
{
    public class CommandRequest : IRequest<IActionResult>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the resource should be permanently deleted.
        /// </summary>
        [FromQuery]
        public bool? HardDelete { get; set; }

        /// <summary>
        /// Gets or Sets id.
        /// </summary>
        public string Id { get; set; }
    }
}