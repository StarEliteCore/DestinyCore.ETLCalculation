using MongoDB.Bson;
using DestinyCore.WorkNode.Shared.Entity;
using DestinyCore.WorkNode.Shared.Extensions.ResultExtensions;
using DestinyCore.WorkNode.Shared.OperationResult;
using System.Threading.Tasks;

namespace DestinyCore.WorkNode.Shared.Audit
{
    public interface IAuditStore : IScopedDependency
    {
        Task SaveAudit(AuditChangeInputDto auditLog);
        Task<IPageResult<AuditLogOutputPageDto>> GetAuditLogPageAsync(PageRequest request);
        Task<OperationResponse> GetAuditEntryListByAuditLogIdAsync(ObjectId id);
        Task<OperationResponse> GetAuditEntryListByAuditEntryIdAsync(ObjectId id);
    }
}
