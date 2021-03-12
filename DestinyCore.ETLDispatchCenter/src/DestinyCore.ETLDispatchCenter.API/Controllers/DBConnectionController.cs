using DestinyCore.ETLDispatchCenter.Application.DBConnResource;
using DestinyCore.ETLDispatchCenter.AspNetCore.ApiBase;
using DestinyCore.ETLDispatchCenter.Dtos.DataDictionaryDto;
using DestinyCore.ETLDispatchCenter.Dtos.DBConnResourceDto;
using DestinyCore.ETLDispatchCenter.Shared.AjaxResult;
using DestinyCore.ETLDispatchCenter.Shared.Audit;
using DestinyCore.ETLDispatchCenter.Shared.Entity;
using DestinyCore.ETLDispatchCenter.Shared.Extensions;
using DestinyCore.ETLDispatchCenter.Shared.OperationResult;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DestinyCore.ETLDispatchCenter.API.Controllers
{
    /// <summary>
    /// 数据连接管理
    /// </summary>
    [Description("数据连接管理")]
    public class DBConnectionController : ApiControllerBase
    {
        private readonly IDBConnectionContract _dBConnectionContract;

        public DBConnectionController(IDBConnectionContract dBConnectionContract)
        {
            _dBConnectionContract = dBConnectionContract;
        }

        /// <summary>
        /// 添加数据连接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("添加数据连接")]
        [AuditLog]
        public async Task<AjaxResult> CreateAsync([FromBody] DBConnResourceInputDto input)
        {
            return (await _dBConnectionContract.CreateAsync(input)).ToAjaxResult();
        }
        /// <summary>
        /// 修改数据连接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Description("修改数据连接")]
        [AuditLog]
        public async Task<AjaxResult> UpdateAsync([FromBody] DBConnResourceInputDto input)
        {
            return (await _dBConnectionContract.UpdateAsync(input)).ToAjaxResult();
        }
        /// <summary>
        /// 表单加载数据连接
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Description("表单加载数据连接")]
        public async Task<AjaxResult> UpdateAsync(Guid? id)
        {
            return (await _dBConnectionContract.GetLoadAsync(id.Value)).ToAjaxResult();
        }
        /// <summary>
        /// 分页加载数据连接
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("分页加载数据连接")]
        public async Task<PageList<DBConnResourcePageOutPutDto>> GetPageLoadAsync([FromBody] PageRequest request)
        {
            return (await _dBConnectionContract.GetPageLoadAsync(request)).PageList();
        }
        /// <summary>
        /// 删除数据连接
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Description("删除数据连接")]
        [AuditLog]
        public async Task<AjaxResult> DeleteAsync(Guid? id)
        {
            await _dBConnectionContract.GetLoadMetaDataAsync(id.Value);
            return (await _dBConnectionContract.DeleteAsync(id.Value)).ToAjaxResult();
        }
        /// <summary>
        /// 数据连接下拉列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("数据连接下拉列表")]
        public async Task<AjaxResult> GetLoadSelectListItemAsync()
        {
            return (await _dBConnectionContract.GetLoadSelectListItemAsync()).ToAjaxResult();
        }

        /// <summary>
        /// 导入元数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("导入元数据")]
        public async Task<AjaxResult> ImportMetaDataAsync([FromBody] MetaDataImportInputDto input)
        {
            return (await _dBConnectionContract.ImportMetaDataAsync(input)).ToAjaxResult();
        }
        /// <summary>
        /// 获取元数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Description("获取元数据")]
        public async Task<AjaxResult> GetLoadMetaDataAsync(Guid Id)
        {
            return (await _dBConnectionContract.GetLoadMetaDataAsync(Id)).ToAjaxResult();
        }

    }
}
