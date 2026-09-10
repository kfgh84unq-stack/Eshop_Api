using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.CategoryAgg
{
    public class Category:AggregateRoot
    {
        private Category()
        {
            
        }
        public Category(string title, string slug, SeoData seoData,ICategoryDomainService domainService)
        {
            slug = slug?.ToSlug();
            Guard(title, slug, domainService);

            Title = title;
            Slug = slug;
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public long? ParentId { get; private set; }
        public List<Category> Chils { get; private set; }
        public void Edit(string title, string slug, SeoData seoData,ICategoryDomainService domainService)
        {
            slug = slug?.ToSlug();
            Guard(title, slug, domainService);

            Title = title;
            Slug = slug;
            SeoData = seoData;
        }
        public void AddChild(string title, string slug, SeoData seoData,ICategoryDomainService domainService)
        {
            Chils.Add(new Category(title, slug, seoData, domainService)
            {
                ParentId = Id
            });
        }

        public void Guard(string title, string slug , ICategoryDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (slug != Slug)
                if (domainService.IsSlugExist(slug))
                    throw new SlugIsDuplicateException();
        }
    }
}
