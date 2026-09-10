using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Odres.DecreasItemCount
{
    public class DecreaseOrderItemCommandHandler : IBaseCommandHandler<DecreaseOrderItemCommand>
    {
        private readonly IOrdreRepository _repository;

        public DecreaseOrderItemCommandHandler(IOrdreRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DecreaseOrderItemCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.DecreaseItemCount(request.ItemId, request.Count);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}

