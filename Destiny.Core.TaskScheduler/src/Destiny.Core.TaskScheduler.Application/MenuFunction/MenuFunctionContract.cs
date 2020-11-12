using Microsoft.EntityFrameworkCore;
using Destiny.Core.TaskScheduler.Domain.Models;
using Destiny.Core.TaskScheduler.Domain.Models.Function;
using Destiny.Core.TaskScheduler.Dtos.MenuFunction;
using Destiny.Core.TaskScheduler.Shared.Entity;
using Destiny.Core.TaskScheduler.Shared.Enums;
using Destiny.Core.TaskScheduler.Shared.Extensions;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using Destiny.Core.TaskScheduler.Shared.ResultMessageConst;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Application.MenuFunction
{
    public class MenuFunctionContract : IMenuFunctionContract
    {
        private readonly IEFCoreRepository<MenuFunctionEntity, Guid> _menuFunctionRepository;
        private readonly IEFCoreRepository<FunctionEntity, Guid> _functionRepository;

        public MenuFunctionContract(IEFCoreRepository<MenuFunctionEntity, Guid> menuFunctionRepository, IEFCoreRepository<FunctionEntity, Guid> functionRepository)
        {
            _menuFunctionRepository = menuFunctionRepository;
            _functionRepository = functionRepository;
        }
        /// <summary>
        /// 分配菜单功能
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperationResponse> AllocationMenuFunctionAsync(MenuFunctionInputDto input)
        {
            input.NotNull(nameof(input));
            return await _menuFunctionRepository.UnitOfWork.UseTranAsync(async () =>
            {
                await _menuFunctionRepository.DeleteBatchAsync(x => x.MenuId == input.Id);
                await _menuFunctionRepository.InsertAsync(input.FuncIds.Select(x => new MenuFunctionEntity
                {
                    MenuId = input.Id,
                    FunctionId = x
                }).ToArray());
                return new OperationResponse(ResultMessage.AllocationSucces, OperationEnumType.Success);
            });
        }
        /// <summary>
        /// 获取菜单功能
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperationResponse> GetLoadMenuFunctionAsync(Guid id)
        {

            var menuIds = await _menuFunctionRepository.NoTrackEntities.Where(x => x.MenuId == id).Select(x => x.MenuId).ToListAsync();
            return new OperationResponse(ResultMessage.LoadSucces, await _functionRepository.NoTrackEntities.Where(x => menuIds.Contains(x.Id)).Select(x => new MenuFunctionOutListDto
            {
                LinkUrl = x.LinkUrl,
                Description = x.Description,
                IsEnabled = x.IsEnabled,
                Name = x.Name,
            }).ToListAsync(), OperationEnumType.Success);

        }
    }
}
