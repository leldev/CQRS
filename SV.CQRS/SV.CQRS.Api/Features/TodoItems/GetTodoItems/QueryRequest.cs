using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SV.CQRS.Api.Features.TodoItems.GetTodoItems
{
    public class QueryRequest : IRequest<IActionResult>
    {
        /// <summary>
        /// Gets or sets a value indicating whether deleted items should be included in the results.
        /// </summary>
        public bool? IncludeDeleted { get; set; }
    }
}