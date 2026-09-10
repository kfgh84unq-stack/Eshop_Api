using AngleSharp.Io;
using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Application.Odres.RemoveItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Products.Edit
{
    public class EditProductCommand: IBaseCommand
    {
        public EditProductCommand(long productId, string title, IFormFile imageFile, string description, long categoryId,
            long subCategoryId, long secandarySubCategoryId, string slug, SeoData seoData, Dictionary<string, string> specifications)
        {
            ProductId = productId;
            Title = title;
            ImageFile = imageFile;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecandarySubCategoryId = secandarySubCategoryId;
            Slug = slug;
            SeoData = seoData;
            Specifications = specifications;
        }

        public long ProductId { get; private set; }
        public string Title { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecandarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public Dictionary<string, string> Specifications { get; private set; }
    }
}
