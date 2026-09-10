using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Sellers.Create
{
    public class CreateSellerCommand : IBaseCommand
    {
        public CreateSellerCommand(long userId, string shopName, string nationalCode)
        {
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
        }

        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
    }
    internal class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
    {
        private readonly ISellerRepository _repository;
        private readonly ISellerDomainService _domainService;
        public CreateSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
           var seller = new Seller(request.UserId, request.ShopName, request.NationalCode,_domainService);
            _repository.Add(seller);
            
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
