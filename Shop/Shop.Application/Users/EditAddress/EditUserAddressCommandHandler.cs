using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditAddress
{
    public class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
    {
        private readonly IUserRepository _repository;

        public EditUserAddressCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
        {
           var user =await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            var address = new UserAddress(request.Name, request.Family, request.PhoneNumber, request.City, request.Shire,
                request.PostalCode, request.PostalAddress, request.NationalCode);

            user.EditAddress(address, request.AddressId);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
    
}
