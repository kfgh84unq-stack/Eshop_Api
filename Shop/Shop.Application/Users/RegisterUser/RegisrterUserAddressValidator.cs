using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.RegisterUser
{
    public class RegisrterUserAddressValidator :AbstractValidator<RegisrterUserAddress>
    {
        public RegisrterUserAddressValidator()
        {
            RuleFor(r => r.Password)
               .NotEmpty().WithMessage(ValidationMessages.required("پسورد"))
               .NotNull()
               .MinimumLength(4).WithMessage("طول پسورد باید بزرگتر از 4 باشد.");
        }
    }

}
