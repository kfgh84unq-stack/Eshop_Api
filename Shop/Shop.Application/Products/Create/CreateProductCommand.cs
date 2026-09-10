using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommand: IBaseCommand
    {
        public CreateProductCommand(string title, IFormFile imageFile, string description, long categoryId, long subCategoryId,
            long secandarySubCategoryId, string slug, SeoData seoData, Dictionary<string, string> specifications)
        {
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

        public string Title { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecandarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public Dictionary<string,string> Specifications { get; private set; }
    }
    internal class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductDomainService _domainService;
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public CreateProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService fileService)
        {
            _domainService = domainService;
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);

            var product = new Product(request.Title, imageName , request.Description , request.CategoryId , request.SubCategoryId ,
                request.SecandarySubCategoryId , request.Slug, request.SeoData, _domainService);
             _repository.Add(product);

            var spesifications = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                spesifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });

            product.SetSpecification(spesifications);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
