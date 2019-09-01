using FluentValidation;
using SV.CQRS.Domain;

namespace SV.CQRS.Api.Features.TodoItems.AddTodoItem
{
    public class ValidatorCollection : AbstractValidator<CommandRequest>
    {
        public ValidatorCollection()
        {
            this.RuleFor(x => x.Name).NotEmpty();
            this.RuleFor(x => x.Name).MaximumLength(TodoItem.MaxNameLength);
            this.RuleFor(x => x.Description).MaximumLength(TodoItem.MaxDescriptionLength);
        }
    }
}