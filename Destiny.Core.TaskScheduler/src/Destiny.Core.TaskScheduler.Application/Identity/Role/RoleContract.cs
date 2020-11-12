using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Destiny.Core.TaskScheduler.Domain.Models;
using Destiny.Core.TaskScheduler.Domain.Models.Authority;
using Destiny.Core.TaskScheduler.Dtos.Identity.Role;
using Destiny.Core.TaskScheduler.Shared.Entity;
using Destiny.Core.TaskScheduler.Shared.Enums;
using Destiny.Core.TaskScheduler.Shared.Extensions;
using Destiny.Core.TaskScheduler.Shared.Extensions.ResultExtensions;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using Destiny.Core.TaskScheduler.Shared.ResultMessageConst;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Application.Identity.Role
{
    public class RoleContract : IRoleContract
    {
        private readonly IEFCoreRepository<RoleMenuEntity, Guid> _roleMenuRepository;
        private readonly RoleManager<RoleEntity> _roleManager;

        public RoleContract(IEFCoreRepository<RoleMenuEntity, Guid> roleMenuRepository, RoleManager<RoleEntity> roleManager)
        {
            _roleMenuRepository = roleMenuRepository;
            _roleManager = roleManager;
        }

        /// <summary>
        /// 创建角色及分配权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperationResponse> CreateAsync(RoleInputDto input)
        {
            input.NotNull(nameof(input));
            var role = input.MapTo<RoleEntity>();
            return (await _roleManager.CreateAsync(role)).ToOperationResponse();
            //return await _roleMenuRepository.UnitOfWork.UseTranAsync(async () =>
            // {
            //     var result = await _roleManager.CreateAsync(role);
            //     if (!result.Succeeded)
            //     {
            //         return result.ToOperationResponse();
            //     }
            //     if (input.MenuIds?.Any() == true)
            //     {
            //         ;
            //         if (await _roleMenuRepository.InsertAsync(input.MenuIds.Select(x => new RoleMenuEntity
            //         {
            //             MenuId = x,
            //             RoleId = role.Id,
            //         }).ToArray()) <= 0)
            //         {
            //             return new OperationResponse(ResultMessage.InsertFail, Shared.Enums.OperationEnumType.Error);
            //         }
            //     }
            //     return new OperationResponse(ResultMessage.InsertSuccess, OperationEnumType.Success);
            // });
        }

        public async Task<OperationResponse> AllocationRoleMenuAsync(RoleMenuInputDto dto)
        {
            dto.NotNull(nameof(dto));
            return await _roleMenuRepository.UnitOfWork.UseTranAsync(async () =>
            {
                await _roleMenuRepository.DeleteBatchAsync(x => x.RoleId == dto.Id);
                await _roleMenuRepository.InsertAsync(dto.MenuIds.Select(x => new RoleMenuEntity
                {
                    RoleId = dto.Id,
                    MenuId = x,
                }).ToArray());
                return new OperationResponse(ResultMessage.AllocationSucces, OperationEnumType.Success);
            });
        }

        /// <summary>
        /// 修改角色及分配权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperationResponse> UpdateAsync(RoleInputDto input)
        {
            input.NotNull(nameof(input));
            var role = await _roleManager.FindByIdAsync(input.Id.ToString());
            role = input.MapTo(role);
            return (await _roleManager.UpdateAsync(role)).ToOperationResponse();

            //return await _roleMenuRepository.UnitOfWork.UseTranAsync(async () =>
            //{
            //    var result = await _roleManager.UpdateAsync(role);
            //    if (!result.Succeeded)
            //    {
            //        return result.ToOperationResponse();
            //    }
            //    if (input.MenuIds?.Any() == true)
            //    {
            //        await _roleMenuRepository.DeleteBatchAsync(x => x.RoleId == input.Id);
            //        if (await _roleMenuRepository.InsertAsync(input.MenuIds.Select(x => new RoleMenuEntity
            //        {
            //            MenuId = x,
            //            RoleId = role.Id,
            //        }).ToArray()) <= 0)
            //        {
            //            return new OperationResponse(ResultMessage.InsertFail, Shared.Enums.OperationEnumType.Error);
            //        }
            //    }
            //    return new OperationResponse(ResultMessage.InsertSuccess, OperationEnumType.Success);
            //});
        }

        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            id.NotNull(nameof(id));
            var role = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
            return new OperationResponse(ResultMessage.DeleteSuccess, OperationEnumType.Success);
        }

        /// <summary>
        /// 分页获取角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IPageResult<RoleOutPutPageDto>> GetPageAsync(PageRequest request)
        {
            request.NotNull(nameof(request));
            return await _roleManager.Roles.AsNoTracking().ToPageAsync<RoleEntity, RoleOutPutPageDto>(request);
        }
    }
}
