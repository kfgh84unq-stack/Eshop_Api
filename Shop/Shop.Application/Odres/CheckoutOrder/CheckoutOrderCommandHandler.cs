using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Odres.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IBaseCommandHandler<CheckoutOrderCommand>
    {
        private readonly IOrdreRepository _repository;

        public CheckoutOrderCommandHandler(IOrdreRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            var newAddress = new OrderAddress(request.Name, request.Family,
                request.PhoneNumber, request.City, request.Shire, request.PostalCode, request.PostalAddress, request.NationalCode);

            currentOrder.CheckOut(newAddress);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
