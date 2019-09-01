using FluentValidation;

namespace SV.CQRS.Api.Features.TodoItems.GetTodoItem
{
    public class ValidatorCollection : AbstractValidator<QueryRequest>
    {
        public ValidatorCollection()
        {
            this.RuleFor(x => x.Id).MaximumLength(36);
        }
    }
}