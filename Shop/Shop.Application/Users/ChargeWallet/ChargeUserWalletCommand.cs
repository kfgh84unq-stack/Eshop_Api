using Common.Application;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommand : IBaseCommand
    {
        public ChargeUserWalletCommand(long userId, int price, string discription, bool isFinally, WalletType type)
        {
            UserId = userId;
            Price = price;
            Description = discription;
            IsFinally = isFinally;
            Type = type;
        }

        public long UserId { get; internal set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public bool IsFinally { get; private set; }
        public WalletType Type { get; private set; }
    }
}
