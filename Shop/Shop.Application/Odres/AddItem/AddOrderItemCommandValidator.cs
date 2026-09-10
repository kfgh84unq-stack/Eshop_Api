using FluentValidation;

namespace Shop.Application.Odres.AddItem
{
    public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از صفر باشد.");
        }
    }
}
