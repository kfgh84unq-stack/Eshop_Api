using AngleSharp.Io;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Application.Odres.RemoveItem;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;
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
    internal class EditProductCommandHasdler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IProductDomainService _domainService;
        private readonly IFileService _fileService;

        public EditProductCommandHasdler(IProductRepository repository, IProductDomainService domainService, IFileService fileService)
        {
            _repository = repository;
            _domainService = domainService;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
           var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var oldImage= product.ImageName;
            product.Edit(request.Title, request.Description, request.CategoryId, request.SubCategoryId,
                request.SecandarySubCategoryId, request.Slug, request.SeoData, _domainService);
            if(request.ImageFile != null)
            {
                var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
                product.SetProductImage(imageName);
            }

            var spesifications = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                spesifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });
            product.SetSpecification(spesifications);

            await _repository.Save();
            RemoveOldImage(request.ImageFile, oldImage);
            return OperationResult.Success();
        }
        private void RemoveOldImage(IFormFile imageFile ,string oldImageName)
        {
            if(imageFile != null)
            {
                _fileService.DeleteFile(Directories.ProductImages, oldImageName);
            }
        }
    }
}
