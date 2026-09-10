using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Odres.RemoveItem
{
    public class RemoveOrderItemCommandHandler : IBaseCommandHandler<RemoveOrderItemCommand>
    {
        private readonly IOrdreRepository _repository;

        public RemoveOrderItemCommandHandler(IOrdreRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            var currentItem = await _repository.GetCurrentOrder(request.UserId);
            if (currentItem == null)
                return OperationResult.NotFound();
            currentItem.RemoveItem(request.ItemId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
