using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SV.CQRS.Api.Features.TodoItems.CompleteTodoItem
{
    public class CommandRequest : IRequest<IActionResult>
    {
        /// <summary>
        /// Gets or Sets id.
        /// </summary>
        public string Id { get; set; }
    }
}