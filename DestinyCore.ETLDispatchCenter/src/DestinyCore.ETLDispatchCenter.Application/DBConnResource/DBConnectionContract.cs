using DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource;
using DestinyCore.ETLDispatchCenter.Dtos;
using DestinyCore.ETLDispatchCenter.Dtos.DataDictionaryDto;
using DestinyCore.ETLDispatchCenter.Dtos.DBConnResourceDto;
using DestinyCore.ETLDispatchCenter.EntityFrameworkCore.SqlSugar;
using DestinyCore.ETLDispatchCenter.Shared;
using DestinyCore.ETLDispatchCenter.Shared.Entity;
using DestinyCore.ETLDispatchCenter.Shared.Enums;
using DestinyCore.ETLDispatchCenter.Shared.Extensions;
using DestinyCore.ETLDispatchCenter.Shared.Extensions.ResultExtensions;
using DestinyCore.ETLDispatchCenter.Shared.OperationResult;
using DestinyCore.ETLDispatchCenter.Shared.ResultMessageConst;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DestinyCore.ETLDispatchCenter.Application.DBConnResource
{
    public class DBConnectionContract : IDBConnectionContract
    {
        private readonly IAggregateRootRepository<DBConnection, Guid> _dbconnectionRepository = null;
        private readonly ISqlSugarDbContext _sqlSugarDbContext;

        public DBConnectionContract(IAggregateRootRepository<DBConnection, Guid> dbconnectionRepository, ISqlSugarDbContext sqlSugarDbContext)
        {
            _dbconnectionRepository = dbconnectionRepository;
            _sqlSugarDbContext = sqlSugarDbContext;
        }
        /// <summary>
        /// 添加数据连接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperationResponse> CreateAsync(DBConnResourceInputDto input)
        {
            input.NotNull(nameof(input));
            return await _dbconnectionRepository.InsertAsync(new DBConnection(input.ConnectionName, input.Memo, input.Host, input.Port, input.UserName, input.PassWord, input.DBType, input.MaxConnSize, input.DataBase));
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
            entity.Update(input.ConnectionName, input.Memo, input.Host, input.Port, input.UserName, input.PassWord, input.DBType, input.MaxConnSize, input.DataBase);
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
            request.NotNull(nameof(request));
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
        /// <summary>
        /// 获取数据连接下拉列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperationResponse<IEnumerable<SelectListItem>>> GetLoadSelectListItemAsync()
        {
            var list = await _dbconnectionRepository.NoTrackEntities.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ConnectionName,
                Selected = false,
            }).ToListAsync();
            return new OperationResponse<IEnumerable<SelectListItem>>(ResultMessage.DataSuccess, list, OperationEnumType.Success);
        }

        public async Task<OperationResponse> ImportMetaDataAsync(MetaDataImportInputDto input)
        {
            input.NotNull(nameof(input));
            var model = await _dbconnectionRepository.GetByIdAsync(input.Id);
            model.MetaDatas.ForEach(x =>
            {
                x.Delete();
            });
            model.ImportMetaData(input.MetaDatas.Select(x => new DBMetaData(x.MetaDataType, x.Name, Guid.Empty, x.Describe)).ToList());
            return await _dbconnectionRepository.UpdateAsync(model);
        }
        public async Task<OperationResponse> GetLoadMetaDataAsync(Guid Id)
        {
            var model = await _dbconnectionRepository.GetByIdAsync(Id);
            var connectionString = "";
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            //string file = Directory.GetFiles(@$"{basePath}\SuktCoreDB.txt").First();
            using StreamReader r = new StreamReader(@$"{basePath}\SuktCoreDB.txt");
            connectionString = r.ReadToEnd();
            var dbcontion = _sqlSugarDbContext.GetSqlSugarClient(new SqlSugar.ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = SqlSugar.DbType.MySql,
                IsAutoCloseConnection = false
            });
            var columns = await dbcontion.Ado.SqlQueryAsync<TreeOutPutDto>(@"
                SELECT COL.COLUMN_NAME as Title,COL.COLUMN_NAME as `Key`,COL.TABLE_NAME as Parent,10 as MetaDataType FROM INFORMATION_SCHEMA.COLUMNS COL Where COL.TABLE_SCHEMA=@TABLE_SCHEMA", new { TABLE_SCHEMA = "ETL.DispatchCenter" });
            var tables = await dbcontion.Ado.SqlQueryAsync<TreeOutPutDto>(@"
                SELECT TB.TABLE_NAME as `Title`,TB.TABLE_NAME as `Key`,TB.TABLE_SCHEMA as Parent,CASE TB.TABLE_TYPE
                WHEN 'BASE TABLE' THEN 0 WHEN 'VIEW' THEN 5 ELSE 0 END FROM INFORMATION_SCHEMA.TABLES TB Where TB.TABLE_SCHEMA=@TABLE_SCHEMA", new { TABLE_SCHEMA = "ETL.DispatchCenter" } /*new { TABLE_SCHEMA = model.DataBase }*/);
            tables.ForEach(x =>
            {
                var childrens = columns.Where(s => s.Parent == x.Key).ToList();
                x.Children.AddRange(childrens);
            });
            return new OperationResponse(ResultMessage.DataSuccess, tables, OperationEnumType.Success);
        }
    }
}
