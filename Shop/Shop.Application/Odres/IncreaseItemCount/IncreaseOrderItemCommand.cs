using Common.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Odres.IncreaseItemCount
{
    public record IncreaseOrderItemCommand (long UserId,long ItemId,int Count) : IBaseCommand;
}
