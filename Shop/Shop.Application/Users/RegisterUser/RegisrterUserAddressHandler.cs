using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.RegisterUser
{
    internal class RegisrterUserAddressHandler : IBaseCommandHandler<RegisrterUserAddress>
    {
        private readonly IUserRepository _repository;
        private readonly IDomainUserService _userService;
        public RegisrterUserAddressHandler(IUserRepository repository, IDomainUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<OperationResult> Handle(RegisrterUserAddress request, CancellationToken cancellationToken)
        {
           var user = User.RegisterUser(request.PhoneNamber.Value, request.Password,_userService);

            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }

}
