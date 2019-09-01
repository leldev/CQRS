using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SV.CQRS.Api.Features.TodoItems.UpdateItem
{
    public class CommandRequest : IRequest<IActionResult>
    {
        /// <summary>
        /// Gets or Sets Description.
        /// </summary>
        [FromBody]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets id.
        /// </summary>
        public string Id { get; set; }
    }
}