using Common.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Odres.AddItem
{
    public class AddOrderItemCommand:IBaseCommand
    {
        public AddOrderItemCommand(long userId, long invevtoryId, int count)
        {
            UserId = userId;
            InvevtoryId = invevtoryId;
            Count = count;
        }

        public long UserId { get; set; }
        public long InvevtoryId { get; set; }
        public int Count { get; set; }
    }
}
