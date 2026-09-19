using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand> 
    {
        public CreateUserCommandValidator()
        {
            RuleFor(r => r.PhoneNamber)
                .ValidPhoneNumber();

            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("ایمیل نامعتبر است.");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage(ValidationMessages.required("پسورد"))
                .NotNull()
                .MinimumLength(4).WithMessage("طول پسورد باید بزرگتر از 4 باشد.");

        }
    }
}
