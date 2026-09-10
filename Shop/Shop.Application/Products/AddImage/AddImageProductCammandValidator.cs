using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddImage
{
    public class AddImageProductCammandValidator : AbstractValidator<AddImageProductCammand> 
    {
        public AddImageProductCammandValidator()
        {
            RuleFor(r => r.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();

            RuleFor(r => r.Sequence)
                .GreaterThan(0);
        }
    }
}
