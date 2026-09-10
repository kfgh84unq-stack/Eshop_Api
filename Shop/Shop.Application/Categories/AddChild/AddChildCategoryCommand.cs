using Common.Application;
using Common.Domain.ValueObjects;
using Shop.Application.Categories.Edit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Categories.AddChild
{
    public record AddChildCategoryCommand(long ParentId, string Title, string Slug, SeoData SeoData) : IBaseCommand;
}
