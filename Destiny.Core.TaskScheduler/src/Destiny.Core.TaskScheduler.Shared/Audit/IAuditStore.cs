using MongoDB.Bson;
using Destiny.Core.TaskScheduler.Shared.Entity;
using Destiny.Core.TaskScheduler.Shared.Extensions.ResultExtensions;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Shared.Audit
{
    public interface IAuditStore : IScopedDependency
    {
        Task SaveAudit(AuditLog auditLog, List<AuditEntryInputDto> audit);
        Task<IPageResult<AuditLogOutputPageDto>> GetAuditLogPageAsync(PageRequest request);
        Task<OperationResponse> GetAuditEntryListByAuditLogIdAsync(ObjectId id);
        Task<OperationResponse> GetAuditEntryListByAuditEntryIdAsync(ObjectId id);
    }
}