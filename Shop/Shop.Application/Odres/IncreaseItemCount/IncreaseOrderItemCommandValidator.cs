using FluentValidation;

namespace Shop.Application.Odres.IncreaseItemCount
{
    public class IncreaseOrderItemCommandValidator : AbstractValidator<IncreaseOrderItemCommand>
    {
        public IncreaseOrderItemCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از صفر باشد.");
        }
    }
}
