using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Microsoft.IdentityModel.Tokens;
using Shop.Domain.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Shop.Domain.ProductAgg
{
    public class Product:AggregateRoot
    {
        private Product()
        {
            
        }
        public Product(string title, string imageName, string description, long categoryId,
            long subCategoryId, long secandarySubCategoryId, string slug, SeoData seoData, IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));

            slug = slug?.ToSlug();
            Guard(title, description, slug, domainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecandarySubCategoryId = secandarySubCategoryId;
            Slug = slug;
            SeoData = seoData;
        }

        public string Title { get;private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecandarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }
        public void Edit(string title, string description, long categoryId,
           long subCategoryId, long secandarySubCategoryId, string slug, SeoData seoData, IProductDomainService domainService)
        {
            slug = slug?.ToSlug();
            Guard(title, description, slug, domainService);
            Title = title;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecandarySubCategoryId = secandarySubCategoryId;
            Slug = slug;
        }
        public void SetProductImage(string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;
        }
        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image); 
        }
        public string RemoveImage(long id)
        {
            var image=Images.FirstOrDefault(x => x.Id == id);
            if (image == null)
                throw new NullOrEmptyDomainDataException("عکس یافت نشد.");
            Images.Remove(image);
            return image.ImageName;
        }
        public void SetSpecification(List<ProductSpecification> specifications)
        {
            Specifications.ForEach(s=>s.ProductId = Id);
            Specifications =specifications;
        }
        private void Guard(string title, string description, string slug, IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title,nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
            
            if(slug!=Slug)
                if(domainService.IsSlugExist(slug))
                    throw new SlugIsDuplicateException();
        }
    }
}
