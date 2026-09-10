using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem:BaseEntity
    {
        public OrderItem(long inventoryId, int count, int price)
        {
            GuardCount(count);
            GuardPrice(price);

            InventoryId = inventoryId;
            Count = count;
            Price = price;
        }

        public long OrderId { get; internal set; }
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int TotalPrice => Count * Price;

        public void ChangeCount(int newCount)
        { 
            GuardCount(newCount);
            Count= newCount;
        }
        public void SetPrice(int newPrice)
        {
            GuardPrice(newPrice);
            Price= newPrice;
        }
        public void IncreaseCount(int count)
        {
            Count += count;
        }
        public void DecreaseCount(int count)
        {
            if (Count == 1)
                return;

            if (Count - count < 0)
                return;

            Count += count;
        }
        public void GuardPrice(int price)
        {
            if (Price < 1)
                throw new InvalidDomainDataException("مبلغ کالا نامعتبر است.");
        }
        public void GuardCount(int count)
        {
            if (count < 1)
                throw new InvalidDomainDataException();
        }
    }
}
