using IDN.Services.BasicsService.Dtos.Identity.User;
using Microsoft.AspNetCore.Identity;
using Destiny.Core.TaskScheduler.Domain.Models;
using Destiny.Core.TaskScheduler.Dtos;
using Destiny.Core.TaskScheduler.Shared.Entity;
using Destiny.Core.TaskScheduler.Shared.Enums;
using Destiny.Core.TaskScheduler.Shared.Extensions;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using Destiny.Core.TaskScheduler.Shared.ResultMessageConst;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Application
{
    public class UserContract : IUserContract
    {
        private readonly UserManager<UserEntity> _userManager = null;
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IEFCoreRepository<UserRoleEntity, Guid> _userRoleRepository = null;

        public UserContract(UserManager<UserEntity> userManager, IUnitOfWork unitOfWork, IEFCoreRepository<UserRoleEntity, Guid> userroleRepository)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRoleRepository = userroleRepository;
        }

        public async Task<OperationResponse> InsertAsync(UserInputDto input)
        {
            input.NotNull(nameof(input));
            var user = input.MapTo<UserEntity>();
            var passwordHash = input.PasswordHash;
            var result = passwordHash.IsNullOrEmpty() ? await _userManager.CreateAsync(user) : await _userManager.CreateAsync(user, passwordHash);
            return result.ToOperationResponse();
            // return await _unitOfWork.UseTranAsync(async () =>
            //{

            //    if (!result.Succeeded)
            //        return result.ToOperationResponse();
            //    if (input.RoleIds?.Any() == true)
            //    {
            //        await _userRoleRepository.InsertAsync(input.RoleIds.Select(x => new UserRoleEntity
            //        {
            //            RoleId = x,
            //            UserId = user.Id,
            //        }).ToArray());
            //    }
            //    return new OperationResponse(ResultMessage.InsertSuccess, OperationEnumType.Success);
            //});
        }

        public async Task<OperationResponse> LoadUserFormAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userdto = user.MapTo<UserLoadFormOutputDto>();
            //userdto.RoleIds = await _userRoleRepository.NoTrackEntities.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
            return new OperationResponse(ResultMessage.LoadSucces, userdto, OperationEnumType.Success);
        }

        public async Task<OperationResponse> UpdateAsync(UserUpdateInputDto input)
        {
            input.NotNull(nameof(input));
            var user = await _userManager.FindByIdAsync(input.Id.ToString());
            user = input.MapTo(user);
            return (await _userManager.UpdateAsync(user)).ToOperationResponse();
            //return result;
            //return await _unitOfWork.UseTranAsync(async () =>
            //{

            //    if (!result.Succeeded)
            //        return result.ToOperationResponse();
            //    await _userRoleRepository.DeleteBatchAsync(x => x.UserId == input.Id);
            //    if (input.RoleIds?.Any() == true)
            //    {
            //        await _userRoleRepository.InsertAsync(input.RoleIds.Select(x => new UserRoleEntity
            //        {
            //            RoleId = x,
            //            UserId = user.Id,
            //        }).ToArray());
            //    }
            //    return new OperationResponse(ResultMessage.UpdateSuccess, OperationEnumType.Success);
            //});
        }

        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            id.NotNull(nameof(id));
            var user = await _userManager.FindByIdAsync(id.ToString());
            return await _unitOfWork.UseTranAsync(async () =>
            {
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                    return result.ToOperationResponse();
                await _userRoleRepository.DeleteBatchAsync(x => x.UserId == id);
                return new OperationResponse(ResultMessage.DeleteSuccess, OperationEnumType.Success);
            });
        }
    }
}
