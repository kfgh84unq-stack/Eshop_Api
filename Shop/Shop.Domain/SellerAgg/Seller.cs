using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.SellerAgg
{
    public class Seller:AggregateRoot
    {
        public Seller(long userId, string shopName, string nationalCode)
        {
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
        }

        private Seller()
        {
            
        }

        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public SellerStatus Status { get; private set; }
        public List<SellerInventory> Inventories { get; private set; }
        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }
        public void Edit (string shopName,string nationalCode)
        {
            Guard(shopName, nationalCode);

            ShopName = shopName;
            NationalCode = nationalCode;
        }
        public void AddInventory(SellerInventory inventory)
        {
            if (Inventories.Any(f=>f.ProductId==inventory.ProductId))
                throw new InvalidDomainDataException("محصول مورد نظر قبلا ثبت شده است.");

            Inventories.Add(inventory);
        }
        public void EditInventory(SellerInventory inventory)
        {
            var CurrentInventory=Inventories.FirstOrDefault(f=>f.Id == inventory.Id);
            if (CurrentInventory == null)
                throw new NullOrEmptyDomainDataException("کالا یافت نشد.");

            Inventories.Remove(CurrentInventory);
            Inventories.Add(inventory);
        }
       public void DeleteInventory( long inventoryId)
        {
            var CurrentInventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);
            if (CurrentInventory == null)
                throw new NullOrEmptyDomainDataException("کالا یافت نشد.");

            Inventories.Remove(CurrentInventory);
        }
        public void Guard(string shopName,string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی نامعتبر است.");
        }
    }
}
