using FluentValidation;

namespace SV.CQRS.Api.Features.TodoItems.CompleteTodoItem
{
    public class ValidatorCollection : AbstractValidator<CommandRequest>
    {
        public ValidatorCollection()
        {
            this.RuleFor(x => x.Id).MaximumLength(36);
        }
    }
}