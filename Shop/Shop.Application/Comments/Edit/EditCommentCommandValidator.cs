using Common.Application.Validation;
using FluentValidation;
using Shop.Application.Comments.Create;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public EditCommentCommandValidator()
        {
            RuleFor(r => r.Text)
                .NotNull()
                .MinimumLength(5).WithMessage(ValidationMessages.minLength("متن مورد", 5));
        }
    }
}
