using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Categories.Edit
{
    public record EditCategoryCommand(long Id,string Title, string Slug, SeoData SeoData) : IBaseCommand;

}
