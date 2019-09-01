using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SV.CQRS.Api.Features.TodoItems.GetTodoItem
{
    public class QueryRequest : IRequest<IActionResult>
    {
        /// <summary>
        /// Gets or Sets Id.
        /// </summary>
        public string Id { get; set; }
    }
}