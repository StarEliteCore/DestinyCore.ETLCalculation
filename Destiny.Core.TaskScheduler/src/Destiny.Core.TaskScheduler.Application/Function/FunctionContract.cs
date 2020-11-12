using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Destiny.Core.TaskScheduler.Domain.Models.Function;
using Destiny.Core.TaskScheduler.Dtos.Function;
using Destiny.Core.TaskScheduler.Shared.Entity;
using Destiny.Core.TaskScheduler.Shared.Enums;
using Destiny.Core.TaskScheduler.Shared.Exceptions;
using Destiny.Core.TaskScheduler.Shared.Extensions;
using Destiny.Core.TaskScheduler.Shared.Extensions.OrderExtensions;
using Destiny.Core.TaskScheduler.Shared.Extensions.ResultExtensions;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using Destiny.Core.TaskScheduler.Shared.ResultMessageConst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Application
{
    public class FunctionContract : IFunctionContract
    {
        private readonly IEFCoreRepository<FunctionEntity, Guid> _functionRepository;

        public FunctionContract(IEFCoreRepository<FunctionEntity, Guid> functionRepository)
        {
            _functionRepository = functionRepository;
        }

        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            id.NotEmpty(nameof(id));
            return await _functionRepository.DeleteAsync(id);
        }

        private IQueryable<FunctionEntity> Entities => _functionRepository.NoTrackEntities;

        public async Task<OperationResponse> InsertAsync(FunctionInputDto input)
        {
            input.NotNull(nameof(input));
            return await _functionRepository.InsertAsync(input, async f =>
             {
                 bool isExist = await this.Entities.Where(x => x.LinkUrl.ToLower() == input.LinkUrl.ToLower()).AnyAsync();
                 if (isExist)
                     throw new SuktAppException("此功能已存在!!!");
             });
        }

        public async Task<IPageResult<FunctionOutputPageDto>> GetFunctionPageAsync(PageRequest request)
        {
            request.NotNull(nameof(request));
            OrderCondition<FunctionEntity>[] orderConditions = new OrderCondition<FunctionEntity>[] { new OrderCondition<FunctionEntity>(o => o.CreatedAt, SortDirectionEnum.Descending) };
            request.OrderConditions = orderConditions;
            return await _functionRepository.NoTrackEntities.ToPageAsync<FunctionEntity, FunctionOutputPageDto>(request);
        }

        public async Task<OperationResponse> UpdateAsync(FunctionInputDto input)
        {
            input.NotNull(nameof(input));
            return await _functionRepository.UpdateAsync(input, async (f, e) =>
            {
                bool isExist = await this.Entities.Where(o => o.Id != f.Id && o.LinkUrl.ToLower() == f.LinkUrl.ToLower()).AnyAsync();
                if (isExist)
                {
                    throw new SuktAppException("此功能已存在!!!");
                }
            });
        }

        /// <summary>
        /// 获取功能下拉框列表
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResponse<IEnumerable<SelectListItem>>> GetFunctionSelectListItemAsync()
        {
            var functions = await _functionRepository.NoTrackEntities.OrderBy(o => o.Name).Select(x => new SelectListItem
            {
                Value = x.Id.ToString().ToLower(),
                Text = x.Name,
                Selected = false
            }).ToListAsync();
            return new OperationResponse<IEnumerable<SelectListItem>>(ResultMessage.DataSuccess, functions, OperationEnumType.Success);
        }
    }
}