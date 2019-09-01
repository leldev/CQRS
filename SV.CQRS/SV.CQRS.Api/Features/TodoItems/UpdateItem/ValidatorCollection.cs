using FluentValidation;
using SV.CQRS.Domain;

namespace SV.CQRS.Api.Features.TodoItems.UpdateItem
{
    public class ValidatorCollection : AbstractValidator<CommandRequest>
    {
        public ValidatorCollection()
        {
            this.RuleFor(x => x.Id).MaximumLength(36);
            this.RuleFor(x => x.Description).MaximumLength(TodoItem.MaxDescriptionLength);
        }
    }
}