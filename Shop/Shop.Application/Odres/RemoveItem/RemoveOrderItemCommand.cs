using Common.Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Odres.RemoveItem
{
    public record RemoveOrderItemCommand (long UserId, long ItemId) : IBaseCommand;
}
