using FluentValidation;

namespace Shop.Application.Odres.DecreasItemCount
{
    public class DecreaseOrderItemCommandValidator : AbstractValidator<DecreaseOrderItemCommand>
    {
        public DecreaseOrderItemCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از صفر باشد.");
        }
    }
}

