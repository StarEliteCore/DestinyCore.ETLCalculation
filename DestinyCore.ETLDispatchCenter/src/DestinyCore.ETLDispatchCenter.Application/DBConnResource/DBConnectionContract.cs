using DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource;
using DestinyCore.ETLDispatchCenter.Dtos.DBConnResourceDto;
using DestinyCore.ETLDispatchCenter.Shared.Entity;
using DestinyCore.ETLDispatchCenter.Shared.Enums;
using DestinyCore.ETLDispatchCenter.Shared.Extensions;
using DestinyCore.ETLDispatchCenter.Shared.Extensions.ResultExtensions;
using DestinyCore.ETLDispatchCenter.Shared.OperationResult;
using DestinyCore.ETLDispatchCenter.Shared.ResultMessageConst;
using System;
using System.Threading.Tasks;

namespace DestinyCore.ETLDispatchCenter.Application.DBConnResource
{
    public class DBConnectionContract : IDBConnectionContract
    {
        private readonly IEFCoreRepository<DBConnection, Guid> _dbconnectionRepository = null;

        public DBConnectionContract(IEFCoreRepository<DBConnection, Guid> dbconnectionRepository)
        {
            _dbconnectionRepository = dbconnectionRepository;
        }
        /// <summary>
        /// 添加数据连接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperationResponse> CreateAsync(DBConnResourceInputDto input)
        {
            input.NotNull(nameof(input));
            return await _dbconnectionRepository.InsertAsync(new DBConnection(input.ConnectionName, input.Memo, input.Host, input.Port, input.UserName, input.PassWord, input.DBType, input.MaxConnSize));
        }
        /// <summary>
        /// 添加数据连接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperationResponse> UpdateAsync(DBConnResourceInputDto input)
        {
            input.NotNull(nameof(input));
            var entity = await _dbconnectionRepository.GetByIdAsync(input.Id);
            entity.Update(input.ConnectionName, input.Memo, input.Host, input.Port, input.UserName, input.PassWord, input.DBType, input.MaxConnSize);
            return await _dbconnectionRepository.UpdateAsync(entity);
        }
        /// <summary>
        /// 表单加载
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OperationResponse> GetLoadAsync(Guid id)
        {
            return new OperationResponse(ResultMessage.DataSuccess, await _dbconnectionRepository.GetByIdToDtoAsync<DBConnResourceLoadOutPutDto>(id), OperationEnumType.Success);
        }
        /// <summary>
        /// 分页加载
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IPageResult<DBConnResourcePageOutPutDto>> GetPageLoadAsync(PageRequest request)
        {
            return await _dbconnectionRepository.NoTrackEntities.ToPageAsync<DBConnection, DBConnResourcePageOutPutDto>(request);
        }
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            return await _dbconnectionRepository.DeleteAsync(id);
        }
    }
}
