using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.IdentityModel.Tokens.Experimental;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shop.Application.Categories.Create
{
    public record  CreateCategoryCommand(string Title, string Slug, SeoData SeoData) : IBaseCommand;
}
