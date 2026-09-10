using Common.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Odres.DecreasItemCount
{
    public record DecreaseOrderItemCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}

