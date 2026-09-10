using Common.Application;
using Shop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Products.RemoveImage
{
    public record RemoveImageProductCommand(long ImageId, long ProductId) : IBaseCommand;
}
