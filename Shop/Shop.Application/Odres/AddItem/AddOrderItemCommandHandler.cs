using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Odres.AddItem
{
    public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
    {
        private readonly IOrdreRepository _repository;
        private readonly ISellerRepository _sellerRepository;

        public AddOrderItemCommandHandler(IOrdreRepository repository, ISellerRepository sellerRepository)
        {
            _repository = repository;
            _sellerRepository = sellerRepository;
        }

        public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _sellerRepository.GetInventoryById(request.InvevtoryId);

            if (inventory == null)
                return OperationResult.NotFound();

            if (inventory.Count < request.Count)
                return OperationResult.Error("تعداد مورد نظر موجود نمی باشد.");

            var order = await _repository.GetCurrentOrder(request.UserId);
            if (order == null)
                order = new Order(request.UserId);

            order.AddItem(new OrderItem(request.InvevtoryId, request.Count, inventory.Price));

            if(ItemCountBiggerThanInventoryCount(inventory,order))
                return OperationResult.Error("تعداد مورد نظر موجود نمی باشد.");

            await _repository.Save();
            return OperationResult.Success();
        }

        public bool ItemCountBiggerThanInventoryCount(InventoryResult inventory,Order order)
        {
            var oldItem=order.Items.First(r=>r.InventoryId==inventory.Id);
            if (oldItem.Count > inventory.Count)
                return true;
            return false;
        }
    }
}
