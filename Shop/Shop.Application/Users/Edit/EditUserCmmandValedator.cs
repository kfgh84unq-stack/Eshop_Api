using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Edit
{
    public class EditUserCmmandValedator : AbstractValidator<EditUserCmmand>
    {
        public EditUserCmmandValedator()
        {
            RuleFor(r => r.PhoneNamber)
               .ValidPhoneNumber();

            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("ایمیل نامعتبر است.");

            RuleFor(r => r.Password)
                .MinimumLength(4).WithMessage("طول پسورد باید بزرگتر از 4 باشد.");

            RuleFor(f => f.Avatar)
               .JustImageFile();
        }
    }
}
