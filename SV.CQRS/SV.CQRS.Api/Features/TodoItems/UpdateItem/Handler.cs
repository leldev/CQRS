using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using SV.CQRS.Api.Persistence;
using SV.CQRS.Domain;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SV.CQRS.Api.Features.TodoItems.UpdateItem
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
            try
            {
                var todoItem = await this.db.GetItemAsync<TodoItem>(request.Id).ConfigureAwait(false);
                todoItem.Description = request.Description;

                await this.db.UpdateItemAsync(todoItem).ConfigureAwait(false);
            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw ex;
                }
            }

            return new NoContentResult();
        }
    }
}