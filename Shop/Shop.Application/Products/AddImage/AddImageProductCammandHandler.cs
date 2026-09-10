using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.AddImage
{
    internal class AddImageProductCammandHandler : IBaseCommandHandler<AddImageProductCammand>
    {
        IProductRepository _repository;
        IFileService _fileService;

        public AddImageProductCammandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(AddImageProductCammand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile,Directories.ProductGalleryImages);
            var producuImage = new ProductImage(imageName, request.Sequence);
            product.AddImage(producuImage);

            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
