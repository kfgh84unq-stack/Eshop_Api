using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Create
{
    internal class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IDomainUserService _userService;

        public CreateUserCommandHandler(IUserRepository repository, IDomainUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = Sha256Hasher.Hash(request.Password);
            var user = new User(request.Name, request.Family, request.PhoneNamber, request.Email, hashedPassword,
                request.Gender, _userService);

            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
