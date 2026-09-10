using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Odres.IncreaseItemCount
{
    public class IncreaseOrderItemCommandHandler : IBaseCommandHandler<IncreaseOrderItemCommand>
    {
        private readonly IOrdreRepository _repository;

        public IncreaseOrderItemCommandHandler(IOrdreRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(IncreaseOrderItemCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.IncreaseItemCount(request.ItemId,request.Count);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
