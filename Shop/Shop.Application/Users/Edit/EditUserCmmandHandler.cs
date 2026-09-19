using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit
{
    internal class EditUserCmmandHandler : IBaseCommandHandler<EditUserCmmand>
    {
        private readonly IUserRepository _repository;
        private readonly IDomainUserService _userService;
        private readonly IFileService _fileService;

        public EditUserCmmandHandler(IUserRepository repository, IDomainUserService userService, IFileService fileService)
        {
            _repository = repository;
            _userService = userService;
            _fileService = fileService;
        }
        public async Task<OperationResult> Handle(EditUserCmmand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            var oldAvatar = user.Avatar;

            user.Edit(request.Name, request.Family, request.PhoneNamber, request.Email, request.Gender, _userService);
            if (request.Avatar != null)
            {
               var avatarName = await _fileService.SaveFileAndGenerateName(request.Avatar,Directories.UserAvatar);
                user.SetAvatar(avatarName);
            }

            DeleteOldAvatar(request.Avatar, oldAvatar);

            await _repository.Save();
            return OperationResult.Success();
        }
        private void DeleteOldAvatar(IFormFile? avatar, string oldAvatar)
        {
            if (avatar == null || oldAvatar == "avatar.png")
                return;
            _fileService.DeleteFile(Directories.UserAvatar, oldAvatar);
        }
    }
}
